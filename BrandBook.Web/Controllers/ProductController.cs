using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class ProductController : FrontendMvcControllerBase
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

        public ActionResult ClosedBeta()
        {
            return View();
        }

    }
}