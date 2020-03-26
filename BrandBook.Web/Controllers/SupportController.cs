using BrandBook.Services.Email;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.Frontend.Support;
using log4net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendMvcControllerBase
    {
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
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

            var message = new StringBuilder();

            message.Append("<strong>Name:</strong> " + model.Name + "<br />");
            message.Append("<strong>Email:</strong> " + model.Email + "<br />");
            message.Append("<strong>Subject:</strong> " + model.Subject + "<br />");
            message.Append("<strong>Message:</strong> " + model.Message);

            _notificationService.SendNotification("brandci@philipp-moser.de", "Contact Request - BrandCi",
                message.ToString());

            
            return View(model);
        }
    }
}