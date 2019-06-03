using System;
using System.Collections.Generic;
using System.Linq;
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
                if (await EmailService.SendEmailAsync("info@philipp-moser.de", model.Message, model.Subject))
                {
                    return RedirectToAction("Index", "Pricing");
                } 
            }

            return View(model);
        }
    }
}