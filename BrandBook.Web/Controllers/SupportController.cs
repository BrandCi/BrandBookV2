using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Services.Email;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Frontend;

namespace BrandBook.Web.Controllers
{
    public class SupportController : FrontendControllerBase
    {
        public ActionResult Contact()
        {
            var model = new ContactFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {

                var message = new StringBuilder();

                message.Append("Name: " + model.Name + "<br />");
                message.Append("Email: " + model.Email + "<br />");
                message.Append("Subject: " + model.Subject + "<br />");
                message.Append("Message: " + model.Message);

                if (await EmailService.SendEmailAsync(message.ToString()))
                {
                    return RedirectToAction("Contact", "Support");
                } 
            }

            return View(model);
        }
    }
}