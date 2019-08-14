using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Auth;
using Microsoft.AspNet.Identity.Owin;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class RegisterController : AuthControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

       
        #region Constructor

        public RegisterController()
        {
            this._appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }

        public RegisterController(UserService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
            this._appUserRepository = new AppUserRepository(new BrandBookDbContext());
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


        // GET: Auth/Register
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Index(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    CompanyId = 1,
                    PrivacyPolicyAccepted = true,
                    IsActive = true
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "AppUser");

                    await SignInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Success", "Register", new {area = "Auth"});
                }
            }

            return View(model);
        }


        public ActionResult Success()
        {
            return View();
        }
    }
}