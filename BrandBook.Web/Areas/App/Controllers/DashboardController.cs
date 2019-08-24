using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class DashboardController : AppControllerBase
    {
        // GET: App/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}