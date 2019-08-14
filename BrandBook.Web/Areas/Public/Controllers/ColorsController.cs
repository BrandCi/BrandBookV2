using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class ColorsController : PublicControllerBase
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