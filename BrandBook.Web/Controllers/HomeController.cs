using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class HomeController : FrontendControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}