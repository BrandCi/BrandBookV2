using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class ProductController : FrontendControllerBase
    {

        public ActionResult Overview()
        {
            return View();
        }

    }
}