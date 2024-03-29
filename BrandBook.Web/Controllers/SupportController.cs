using BrandBook.Core.Domain.System.Notification;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.ViewModels.Frontend.Support;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Core.ViewModels.Notification.TemplateType;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Web.Framework.Helpers;
using log4net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendMvcControllerBase
    {
        protected static new readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly IReCaptchaService _recaptchaService;
        private readonly INotificationService _notificationService;

        public SupportController()
        {
            _recaptchaService = new ReCaptchaService();
            _notificationService = new NotificationService();
        }



        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            var model = new ContactFormViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactFormViewModel model)
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
                Type = NotificationTemplateType.General_ContactRequest,
                Subject = "BrandCi - Contact Request",
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                General_ContactRequest = new General_ContactRequest()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                }
            };

            _notificationService.SendNotification(emailContent);

            var sentModel = new ContactFormViewModel()
            {
                IsSent = true
            };

            return View(sentModel);
        }


        public ActionResult Faq()
        {
            return View();
        }


    }
}