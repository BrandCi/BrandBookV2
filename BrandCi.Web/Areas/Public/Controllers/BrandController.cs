using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Areas.Public.Controllers
{
    public class BrandController : PublicMvcControllerBase
    {

        public ActionResult Overview()
        {
            return View();
        }

    }
}
