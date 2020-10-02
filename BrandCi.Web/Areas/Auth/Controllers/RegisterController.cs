using BrandCi.Core;
using BrandCi.Core.Domain.Company;
using BrandCi.Core.Domain.User;
using BrandCi.Core.Services.Authentication;
using BrandCi.Core.Services.Messaging;
using BrandCi.Core.Services.Subscriptions;
using BrandCi.Core.ViewModels.Auth;
using BrandCi.Core.ViewModels.Notification;
using BrandCi.Core.ViewModels.Notification.TemplateType;
using BrandCi.Infrastructure;
using BrandCi.Resources;
using BrandCi.Services.Authentication;
using BrandCi.Services.Notification;
using BrandCi.Services.Subscriptions;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BrandCi.Web.Areas.Auth.Controllers
{
    public class RegisterController : AuthMvcControllerBase
    {
        public UserAuthenticationService _userService;
        private SignInService _signInService;
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

        public RegisterController(UserAuthenticationService userService, SignInService signInService)
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "auth_registration");
                if (!isCaptchaValid)
                {
                    ModelState.AddModelError("GoogleCaptcha", @Translations.auth_register_validation_captcha_invalid);
                    return View(model);
                }
            }

            if (string.IsNullOrEmpty(model.PromotionCode) || model.PromotionCode != "nvse-eimv-wasd-vbwi")
            {
                ModelState.AddModelError("Promotioncode", "Please enter an valid Promotioncode");
                return View(model);
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
                IsActive = true,
                CreationDate = DateTime.Now,
                LastLogin = DateTime.Now,
                LastModified = DateTime.Now
            };

            var result = await UserManager.CreateAsync(user, model.Password);


            if (!result.Succeeded)
            {
                return View(model);
            }

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


            if (ProceedVerificationEmail(user.Email, user.UserName, callbackUrl, model.PromotionCode))
            {
                return RedirectToAction("Success", "Register", new { area = "Auth" });
            }


            return View("Error");

        }


        public ActionResult Success()
        {
            return View();
        }


        private bool ProceedVerificationEmail(string userEmail, string userName, string callbackUrl, string promoCode)
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

            var adminInfo = new EmailTemplateViewModel()
            {
                Type = EmailTemplateType.Admin_AccountCreationInformation,
                Subject = "New Account Creation",
                Admin_AccountCreationInformation = new Admin_AccountCreationInformation()
                {
                    Creationdate = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                    Username = userName,
                    Email = userEmail,
                    Promocode = promoCode,
                    RequestIp = Request.UserHostAddress
                }
            };

            _notificationService.SendNotification(adminInfo);

            return _notificationService.SendNotification(emailContent); ;
        }


    }
}