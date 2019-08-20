using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class PricingController : FrontendControllerBase
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