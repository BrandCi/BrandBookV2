using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class LegalController : FrontendControllerBase
    {
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
    }
}