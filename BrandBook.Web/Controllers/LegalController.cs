using System.Threading.Tasks;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.ViewModels.Frontend.Legal;
using BrandBook.Resources;
using BrandBook.Services.Authentication;
using log4net;

namespace BrandBook.Web.Controllers
{
    public class LegalController : FrontendMvcControllerBase
    {
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly IReCaptchaService _recaptchaService;

        public LegalController()
        {
            _recaptchaService = new ReCaptchaService();
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


            var sentModel = new PrivacyRequestViewModel()
            {
                IsSent = true
            };
            return View(model);
        }
    }
}