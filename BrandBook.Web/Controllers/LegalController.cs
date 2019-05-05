using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BrandBook.Infrastructure.Data;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class LegalController : FrontendControllerBase
    {
        public ActionResult Imprint()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Cookie()
        {
            return View();
        }
    }
}