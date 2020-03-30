using BrandBook.Core;
using BrandBook.Core.Domain.Company;
using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Subscriptions;
using BrandBook.Services.Users;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.Auth;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Core.ViewModels.Process.Notification;
using BrandBook.Core.ViewModels.Process.Notification.TemplateType;
using BrandBook.Resources;
using BrandBook.Services.Notification;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class RegisterController : AuthMvcControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IReCaptchaService _recaptchaService;
        private readonly INotificationService _notificationService;


        #region Constructor

        public RegisterController()
        {
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
        }

        public RegisterController(UserService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
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

        public UserService UserManager
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().GetUserManager<UserService>();
            }
            private set
            {
                _userService = value;
            }
        }


        // GET: Auth/Register
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "auth_registration");
                if (!isCaptchaValid)
                {
                    ModelState.AddModelError("GoogleCaptcha", @Translations.auth_register_validation_captcha_invalid);
                    return View(model);
                }
            }
            

            var company = new Company()
                {
                    Name = model.Username,
                    ContactEmail = model.Email,
                    UrlName = model.Username
                };

                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Company = company,
                    PrivacyPolicyAccepted = true,
                    IsActive = true
                };

                var result = await UserManager.CreateAsync(user, model.Password);


                if (!result.Succeeded) return View(model);


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


                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                var callbackUrl = Url.Action("ConfirmAccount", "Processes", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                
                if (ProceedVerificationEmail(user.Email, user.UserName, callbackUrl))
                {
                    return RedirectToAction("Success", "Register", new { area = "Auth" });
                }
                

                return View("Error");

        }


        public ActionResult Success()
        {
            return View();
        }


        private bool ProceedVerificationEmail(string userEmail, string userName, string callbackUrl)
        {
            var emailContent = new EmailTemplateViewModel()
            {
                Type = EmailTemplateType.User_AccountVerification,
                Receiver = userEmail,
                Subject = "Verify your E-Mail Address",
                User_AccountVerification = new User_AccountVerification()
                {
                    Username = userName,
                    EmailAddress = userEmail,
                    TargetUrl = callbackUrl
                }
            };
            
            return _notificationService.SendNotification(emailContent); ;
        }


    }
}