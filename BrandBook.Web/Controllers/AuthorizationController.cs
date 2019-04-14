using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.ViewModels.Authorization;

namespace BrandBook.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}