﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class BlogController : FrontendControllerBase
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}