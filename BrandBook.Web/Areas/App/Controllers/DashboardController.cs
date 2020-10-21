using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class DashboardController : AppMvcControllerBase
    {
        #region Actions
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}