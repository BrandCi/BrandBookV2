using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Profile;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class ProfileController : AppControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public ProfileController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var appUser = unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());

            var model = new GeneralUserDataViewModel()
            {
                UserName = appUser.UserName,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName
            };
                

            return View(model);
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
            unitOfWork.SaveChanges();


            return RedirectToAction("Index", "Profile", new {area = "App"});
        }




        public ActionResult Subscriptions()
        {
            return View();
        }


    }
}