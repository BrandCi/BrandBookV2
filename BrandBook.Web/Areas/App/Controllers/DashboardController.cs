using BrandBook.Web.Framework.Controllers;
using System.Web.Mvc;

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