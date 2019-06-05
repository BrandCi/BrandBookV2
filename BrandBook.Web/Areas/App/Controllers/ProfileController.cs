using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Profile;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class ProfileController : AppControllerBase
    {

        private IUnitOfWork unitOfWork;

        public ProfileController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var appUser = unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());

            GeneralUserDataViewModel appUserViewModel = new GeneralUserDataViewModel(appUser.Id, appUser.FirstName, appUser.LastName, appUser.UserName, appUser.Email);
                

            return View(appUserViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserData(GeneralUserDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile", new { area = "App" });
            }

            var appUser = unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());

            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;

            unitOfWork.AppUserRepository.Update(appUser);


            return RedirectToAction("Index", "Profile", new {area = "App"});
        }


    }
}