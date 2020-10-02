using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Areas.App.Controllers
{
    public class DashboardController : AppMvcControllerBase
    {
        #region Actions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AngularTest()
        {
            return View();
        }
        #endregion
    }
}