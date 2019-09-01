using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Services.Email;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Frontend.Support;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendControllerBase
    {
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

            message.Append("Name: " + model.Name + "<br />");
            message.Append("Email: " + model.Email + "<br />");
            message.Append("Subject: " + model.Subject + "<br />");
            message.Append("Message: " + model.Message);

            if (await EmailService.SendEmailAsync(message.ToString()))
            {
                return RedirectToAction("Contact", "Support");
            }

            return View(model);
        }
    }
}