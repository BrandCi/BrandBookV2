﻿using System.Threading.Tasks;
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
        private IAppUserRepository appUserRepository;

       
        #region Constructor

        public RegisterController()
        {
            this.appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }

        public RegisterController(UserService userService, SignInService signInService)
        {
            UserManager = userService;
            SignInService = signInService;
            this.appUserRepository = new AppUserRepository(new BrandBookDbContext());
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
                //if (model.PromotionCode != "Promo_E85D2C" || model.PromotionCode != "Promo_292A8D" || model.PromotionCode != "Promo_5CEAE3")
                //{
                    //ModelState.AddModelError("", "Please check the Promotioncode!");
                    //return View(model);
                //}



                var user = new AppUser { UserName = model.Username, Email = model.Email, CompanyId = 1};
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