using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class BrandController : PublicControllerBase
    {

        public ActionResult Overview()
        {
            return View();
        }

    }
}
