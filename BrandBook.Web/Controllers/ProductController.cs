using BrandBook.Core.Domain.System.Notification;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Frontend.Product;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Core.ViewModels.Notification.TemplateType;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using log4net;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class ProductController : FrontendMvcControllerBase
    {

        protected static new readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly IReCaptchaService _recaptchaService;
        private readonly INotificationService _notificationService;

        public ProductController()
        {
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
        }

        public ActionResult Overview()
        {
            ViewBag.Title = "Product Overview";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }

        public ActionResult Creation()
        {
            return View();
        }

        public ActionResult Documentation()
        {
            return View();
        }

        public ActionResult Collaboration()
        {
            return View();
        }

        public ActionResult Sharing()
        {
            return View();
        }

        public ActionResult Optimization()
        {
            return View();
        }

        public ActionResult ClosedBeta()
        {
            var model = new ClosedBetaViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ClosedBeta(ClosedBetaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                Type = NotificationTemplateType.General_RequestClosedBeta,
                Subject = "BrandCi - Closed Beta Request",
                General_RequestClosedBeta = new General_RequestClosedBeta()
                {
                    Email = model.Email,
                    RequestDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
                }
            };

            _notificationService.SendNotification(emailContent);

            var sentModel = new ClosedBetaViewModel()
            {
                IsSent = true
            };

            return View(sentModel);
        }

    }
}