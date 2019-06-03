using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Contact(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                // return RedirectToAction("ContactSuccess", "Support");
            }

            return View(model);
        }
    }
}