using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class FontsController : PublicControllerBase
    {
        // GET: Public/Fonts
        public ActionResult Index()
        {
            return View();
        }
    }
}