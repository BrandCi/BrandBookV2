using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Controllers
{
    public class PricingController : FrontendMvcControllerBase
    {
        // GET: Pricing
        public ActionResult Index()
        {
            ViewBag.Title = "Pricing";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }
    }
}