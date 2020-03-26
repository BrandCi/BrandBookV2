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


    }
}