using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Bases.Controllers;

namespace BrandBook.Web.Controllers
{
    public class PricingController : FrontendControllerBase
    {
        // GET: Pricing
        public ActionResult Index()
        {
            return View();
        }
    }
}