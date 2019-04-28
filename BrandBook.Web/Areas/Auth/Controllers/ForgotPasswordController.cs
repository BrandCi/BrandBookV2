using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class ForgotPasswordController : Controller
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