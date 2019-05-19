using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Profile;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class ProfileController : AppControllerBase
    {

        private IAppUserRepository appUserRepository;

        public ProfileController()
        {
            this.appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }

        public ActionResult Index()
        {
            var appUser = appUserRepository.FindById(User.Identity.GetUserId());

            GeneralUserDataViewModel appUserViewModel = new GeneralUserDataViewModel(appUser.Id, appUser.FirstName, appUser.LastName, appUser.UserName, appUser.Email);
                

            return View(appUserViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserData(bool model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile", new { area = "App" });
            }

            return RedirectToAction("Index", "Profile", new {area = "App"});
        }


    }
}