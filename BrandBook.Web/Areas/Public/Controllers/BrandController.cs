using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class BrandController : PublicMvcControllerBase
    {

        public ActionResult Overview()
        {
            return View();
        }

    }
}
