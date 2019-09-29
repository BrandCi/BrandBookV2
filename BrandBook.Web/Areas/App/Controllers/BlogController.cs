using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BlogController : AppControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public BlogController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        // GET: App/Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}