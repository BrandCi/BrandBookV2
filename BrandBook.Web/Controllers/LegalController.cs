using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class LegalController : Controller
    {
        // GET: Legal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Imprint()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}