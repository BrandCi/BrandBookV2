using BrandBook.Services.Email;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.Frontend.Support;
using log4net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Core.Services.Authentication;
using BrandBook.Resources;
using BrandBook.Services.Authentication;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendMvcControllerBase
    {
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly IReCaptchaService _recaptchaService;

        public SupportController()
        {
            _recaptchaService = new ReCaptchaService();
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
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, Request.UserHostAddress, "registration");
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

            if (await EmailService.SendEmailAsync(message.ToString()))
            {
                return RedirectToAction("Contact", "Support");
            }
            else
            {
                var error = "This Email could not be sent. Please try again later.";

                ModelState.AddModelError("NotSent", error);
                Logger.Error(error);
            }

            return View(model);
        }
    }
}