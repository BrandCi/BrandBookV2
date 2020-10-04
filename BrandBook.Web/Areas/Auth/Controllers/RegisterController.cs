using BrandBook.Core;
using BrandBook.Core.Domain.Company;
using BrandBook.Core.Domain.System.Notification;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Core.ViewModels.Auth;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Core.ViewModels.Notification.TemplateType;
using BrandBook.Infrastructure;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Web.Framework.Helpers;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class RegisterController : AuthMvcControllerBase
    {
        public UserAuthenticationService _userService;
        private SignInService _signInService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IReCaptchaService _recaptchaService;
        private readonly INotificationService _notificationService;
        private readonly int _trialSubscriptionPlanId;


        #region Constructor

        public RegisterController()
        {
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
            int.TryParse(ConfigurationManager.AppSettings["TrialSubscriptionPlanId"], out _trialSubscriptionPlanId);
        }

        public RegisterController(UserAuthenticationService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
            int.TryParse(ConfigurationManager.AppSettings["TrialSubscriptionPlanId"], out _trialSubscriptionPlanId);
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
                SubscriptionPlanId = _trialSubscriptionPlanId
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
                Type = NotificationTemplateType.User_AccountVerification,
                Receiver = userEmail,
                Subject = "Verify your E-Mail Address",
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                User_AccountVerification = new User_AccountVerification()
                {
                    Username = userName,
                    EmailAddress = userEmail,
                    TargetUrl = callbackUrl
                }
            };

            var adminInfo = new EmailTemplateViewModel()
            {
                Type = NotificationTemplateType.Admin_AccountCreationInformation,
                Subject = "New Account Creation",
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                Admin_AccountCreationInformation = new Admin_AccountCreationInformation()
                {
                    Username = userName,
                    Email = userEmail,
                    Promocode = promoCode
                }
            };

            _notificationService.SendNotification(adminInfo);

            return _notificationService.SendNotification(emailContent); ;
        }


    }
}