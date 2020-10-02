using BrandCi.Core;
using BrandCi.Core.Services.Authentication;
using BrandCi.Core.Services.Messaging;
using BrandCi.Core.ViewModels.Frontend.Legal;
using BrandCi.Core.ViewModels.Notification;
using BrandCi.Core.ViewModels.Notification.TemplateType;
using BrandCi.Infrastructure;
using BrandCi.Resources;
using BrandCi.Services.Authentication;
using BrandCi.Services.Notification;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using BrandCi.Web.Framework.Helpers;
using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BrandCi.Web.Controllers
{
    public class LegalController : FrontendMvcControllerBase
    {
        protected static new readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
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
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View(model: GetStaticLegalContent("Imprint"));
        }


        public ActionResult PrivacyPolicy()
        {
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View(model: GetStaticLegalContent("PrivacyPolicy"));
        }

        public ActionResult Cookie()
        {
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View(model: GetStaticLegalContent("CookiePolicy"));
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "frontend_privacyrequest");
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
                    UserId = User.Identity.GetUserId<int>(),
                    RequestType = model.Type,
                    Message = model.Message,
                    RequestDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                    RequestIp = Request.UserHostAddress,
                }
            };

            var applicant = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId<int>());
            if (applicant != null)
            {
                emailContent.General_PrivacyRequest.Email = applicant.Email;
            }


            var sentModel = new PrivacyRequestViewModel()
            {
                IsSent = false
            };

            if (_notificationService.SendNotification(emailContent))
            {
                sentModel.IsSent = true;
            }

            return View(sentModel);
        }



        #region Private Helpers
        private static string GetStaticLegalContent(string subFolder)
        {
            return GetStaticLegalContent(subFolder, CultureHelper.GetCurrentNeutralCulture());
        }


        private static string GetStaticLegalContent(string subFolder, string currentCulture)
        {
            var filePath = HostingEnvironment.ApplicationPhysicalPath + "/Content/LegalPages/" + subFolder + "/" + currentCulture + ".html";
            var staticContent = "";

            if (System.IO.File.Exists(filePath))
            {
                staticContent = System.IO.File.ReadAllText(filePath);
            }

            if (string.IsNullOrEmpty(staticContent) && currentCulture != "de")
            {
                staticContent = GetStaticLegalContent(subFolder, "de");
            }

            return staticContent;
        }
        #endregion
    }
}