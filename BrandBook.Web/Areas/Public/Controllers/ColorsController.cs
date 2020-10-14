using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class ColorsController : PublicMvcControllerBase
    {
        // GET: Public/Colors
        public ActionResult Index()
        {
            return View();
        }
    }
}