using System.Web.Mvc;
using BrandBook.Resources;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class HomeController : FrontendControllerBase
    {
        public ActionResult Index()
        {
            ViewBag.Title = Translations.frontend_navigation_homepage;
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }
    }
}