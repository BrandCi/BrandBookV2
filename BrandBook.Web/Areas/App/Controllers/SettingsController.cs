using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class SettingsController : Controller
    {
        // GET: App/Settings
        public ActionResult Index()
        {
            return View();
        }
    }
}