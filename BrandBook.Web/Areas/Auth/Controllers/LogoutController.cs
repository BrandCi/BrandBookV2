using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Auth/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home", new {area = ""});
        }



        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}