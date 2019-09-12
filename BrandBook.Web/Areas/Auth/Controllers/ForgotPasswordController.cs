﻿using BrandBook.Web.Framework.Controllers;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class ForgotPasswordController : AuthControllerBase
    {
        // GET: Auth/ForgotPassword
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }
    }
}