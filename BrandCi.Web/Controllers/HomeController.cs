using BrandCi.Resources;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Controllers
{
    public class HomeController : FrontendMvcControllerBase
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