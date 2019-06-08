using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class ColorsController : PublicControllerBase
    {
        private IUnitOfWork unitOfWork;

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