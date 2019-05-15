using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class UserController : Controller
    {
        // GET: App/User
        public ActionResult UserOverview()
        {
            return View();
        }
    }
}