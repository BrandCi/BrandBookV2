using BrandBook.Web.Framework.Controllers;
using System.Web.Mvc;

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