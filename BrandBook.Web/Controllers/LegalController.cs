using System.Web.Mvc;
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