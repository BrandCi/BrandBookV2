using BrandBook.Core;
using BrandBook.Core.Domain.Company;
using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Subscriptions;
using BrandBook.Services.Users;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.Auth;
using BrandBook.Core.ViewModels.Auth.External;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Services.Authentication;
using BrandBook.Resources;


namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class LoginController : AuthMvcControllerBase
    {
        private SignInService _signInService;
        public UserAuthenticationService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SubscriptionService _subscriptionService;
        private readonly IReCaptchaService _recaptchaService;


        #region Constructor

        public LoginController()
        {
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
        }

        public LoginController(UserAuthenticationService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
        }

        #endregion



        public SignInService SignInService
        {
            get
            {
                return _signInService ?? HttpContext.GetOwinContext().Get<SignInService>();
            }
            private set
            {
                _signInService = value;
            }
        }

        public UserAuthenticationService UserManager
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().GetUserManager<UserAuthenticationService>();
            }
            private set
            {
                _userService = value;
            }
        }




        // GET: Auth/Login
        public ActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "auth_login");
                if (!isCaptchaValid)
                {
                    ModelState.AddModelError("GoogleCaptcha", @Translations.auth_login_validation_notloggedin);
                    return View(model);
                }
            }

            
            var user = _unitOfWork.AppUserRepository.FindByUsername(model.UserName);
            if (user != null && !user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Please verify your email to login.");
                return View(model);
            }

            var result = await SignInService.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);

            switch (result)
            {
                case SignInStatus.Success:
                    UpdateLastLoginDate(user);
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return RedirectToAction("Locked", "Processes", new { area = "Auth" });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", @Translations.auth_login_validation_notloggedin);
                    return View(model);
            }

        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult External(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action("ExternalCallback", "Login", new { ReturnUrl = returnUrl }));
        }


        [AllowAnonymous]
        public async Task<ActionResult> ExternalCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Index");
            }

            // If existing, log in with external account
            var result = await SignInService.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    // Promt to create new account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }




        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "App" });
            }

            if (ModelState.IsValid)
            {
                var company = new Company()
                {
                    Name = model.Email,
                    ContactEmail = model.Email,
                    UrlName = model.Email
                };



                var info = await AuthenticationManager.GetExternalLoginInfoAsync();

                if (info == null)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Company = company,
                    PrivacyPolicyAccepted = true,
                    IsActive = true
                };

                var result = await UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {

                        var initialSubscription = new Subscription()
                        {
                            Key = _subscriptionService.GenerateSubscriptionKey(),
                            AppUser = _unitOfWork.AppUserRepository.FindById(user.Id),
                            AppUserId = user.Id,
                            IsActive = true,
                            IsPaid = true,
                            StartDateTime = DateTime.Now,
                            SubscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(7),
                            SubscriptionPlanId = 7
                        };

                        _unitOfWork.SubscriptionRepository.Add(initialSubscription);
                        _unitOfWork.SaveChanges();

                        await UserManager.AddToRoleAsync(user.Id, "AppUser");


                        await SignInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }


            ViewBag.ReturnUrl = returnUrl;
            return View(model);


        }




        public ActionResult VersionInfo()
        {
            return View();
        }



        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Dashboard", new { area = "App" });
        }






        #region Helpers
        private const string XsrfKey = "XsrfId";


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void UpdateLastLoginDate(AppUser user)
        {
            user.LastLogin = DateTime.Now;
            _unitOfWork.AppUserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }


        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }



            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion



    }
}