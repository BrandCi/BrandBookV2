using System;
using System.Threading.Tasks;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Frontend.Legal;
using BrandBook.Core.ViewModels.Process.Notification;
using BrandBook.Core.ViewModels.Process.Notification.TemplateType;
using BrandBook.Infrastructure;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using log4net;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Controllers
{
    public class LegalController : FrontendMvcControllerBase
    {
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly IReCaptchaService _recaptchaService;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;

        public LegalController()
        {
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
            _unitOfWork = new UnitOfWork();
        }


        public ActionResult Imprint()
        {
            ViewBag.Title = "Imprint";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.Title = "Privacy Policy";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }

        public ActionResult Cookie()
        {
            ViewBag.Title = "Cookie Policy";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }

        [Authorize]
        public ActionResult PrivacyRequest()
        {
            var model = new PrivacyRequestViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PrivacyRequest(PrivacyRequestViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "frontend_contact");
                if (!isCaptchaValid)
                {
                    ModelState.AddModelError("GoogleCaptcha", @Translations.auth_register_validation_captcha_invalid);
                    return View(model);
                }
            }
            
            var emailContent = new EmailTemplateViewModel()
            {
                Type = EmailTemplateType.General_PrivacyRequest,
                Subject = "BrandCi - Privacy Request",
                General_PrivacyRequest = new General_PrivacyRequest()
                {
                    UserId = User.Identity.GetUserId(),
                    RequestType = model.Type,
                    Message = model.Message,
                    RequestDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                    RequestIp = Request.UserHostAddress,    
                }
            };

            var applicant = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());
            if (applicant != null)
            {
                emailContent.General_PrivacyRequest.Email = applicant.Email;
            }


            var sentModel = new PrivacyRequestViewModel()
            {
                IsSent = false
            };

            if(_notificationService.SendNotification(emailContent))
            {
                sentModel.IsSent = true;
            }

            return View(sentModel);
        }
    }
}