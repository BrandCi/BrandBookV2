using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Public.Controllers
{
    public class BrandController : Controller
    {

        public ActionResult Overview()
        {
            return View();
        }

    }
}
