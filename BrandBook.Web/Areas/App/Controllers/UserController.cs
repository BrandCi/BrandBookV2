using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class UserController : AppControllerBase
    {
        // GET: App/User
        public ActionResult UserOverview()
        {
            return View();
        }


        public ActionResult CustomerOverview()
        {
            return View();
        }
    }
}