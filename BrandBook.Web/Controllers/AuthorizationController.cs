using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BrandBook.Core.Domain.User;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using BrandBook.Web.ViewModels.Authorization;

namespace BrandBook.Web.Controllers
{
    public class AuthorizationController : Controller
    {

        #region Fields

        private SignInService _signInService;
        private UserService _userService;

        #endregion

        #region Constructor

        public AuthorizationController() { }

        public AuthorizationController(UserService userService, SignInService signInService)
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
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User {UserName = model.Username, Email = model.Email};
                var result = await UserManager.CreateAsync(user, model.Password);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}