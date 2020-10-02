using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class ColorsController : PublicMvcControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ColorsController()
        {
            this.unitOfWork = new UnitOfWork();
        }


        // GET: Public/Colors
        public ActionResult Index()
        {
            return View();
        }
    }
}