using BrandBook.Services.Email;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.Frontend.Support;
using log4net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendControllerBase
    {
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
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