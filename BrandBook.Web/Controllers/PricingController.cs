﻿using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandBook.Web.Controllers
{
    public class PricingController : FrontendControllerBase
    {
        // GET: Pricing
        public ActionResult Index()
        {
            ViewBag.Title = "Pricing";
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";

            return View();
        }
    }
}