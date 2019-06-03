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

                StringBuilder message = new StringBuilder();

                message.Append("Name: " + model.Name + "\n");
                message.Append("Email: " + model.Email + "\n");
                message.Append("Subject: " + model.Subject + "\n");
                message.Append("Message: " + model.Message);

                if (await EmailService.SendEmailAsync("info@philipp-moser.de", message.ToString(), "Contact Form BrandBook"))
                {
                    return RedirectToAction("Contact", "Support");
                } 
            }

            return View(model);
        }
    }
}