using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class LoggingController : AppControllerBase
    {
        // GET: App/Logging
        public ActionResult LoggingMessages()
        {
            return View();
        }
    }
}