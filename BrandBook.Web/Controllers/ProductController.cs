using BrandBook.Web.Framework.Controllers;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class ProductController : FrontendControllerBase
    {

        public ActionResult Overview()
        {
            ViewBag.Title = "Product Overview";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }

        public ActionResult Creation()
        {
            return View();
        }

        public ActionResult Documentation()
        {
            return View();
        }

        public ActionResult Collaboration()
        {
            return View();
        }

        public ActionResult Sharing()
        {
            return View();
        }

        public ActionResult Optimization()
        {
            return View();
        }

    }
}