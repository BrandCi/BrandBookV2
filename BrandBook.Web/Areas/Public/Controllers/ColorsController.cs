using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class ColorsController : PublicControllerBase
    {
        // GET: Public/Colors
        public ActionResult Index()
        {
            return View();
        }
    }
}