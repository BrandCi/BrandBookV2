using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Auth;
using Microsoft.AspNet.Identity.Owin;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class LoginController : AuthControllerBase
    {


        #region Constructor

        public LoginController() { }

        public LoginController(UserService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
        }

        #endregion



        public SignInService SignInService
        {
            get
            {
                return _signInService ?? HttpContext.GetOwinContext().Get<SignInService>();
            }
            private set
            {
                _signInService = value;
            }
        }

        public UserService UserManager
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().GetUserManager<UserService>();
            }
            private set
            {
                _userService = value;
            }
        }




        // GET: Auth/Login
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new {area = ""});
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInService.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Dashboard", new { area = "App"} );
            }
            else
            {
                ModelState.AddModelError("", "Du konntest nicht angemeldet werden.");
                return View(model);
            }

        }
    }
}