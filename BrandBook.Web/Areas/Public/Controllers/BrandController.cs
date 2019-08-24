using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

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
