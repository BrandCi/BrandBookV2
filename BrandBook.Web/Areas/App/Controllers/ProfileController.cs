using System.Collections.Generic;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Profile;
using BrandBook.Web.Framework.ViewModels.App.Subscriptions;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class ProfileController : AppControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProfileController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var appUser = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());

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

            var appUser = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId());

            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;

            _unitOfWork.AppUserRepository.Update(appUser);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "Profile", new {area = "App"});
        }




        public ActionResult Subscriptions()
        {
            var userId = User.Identity.GetUserId();
            var subscriptions = _unitOfWork.SubscriptionRepository.GetAllUserSubscriptions(userId);
            var viewModel = new SubscriptionsViewModel()
            {
                Subscriptions = new List<SingleSubscriptionViewModel>()
            };


            foreach (var subscription in subscriptions)
            {
                var subscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId);
                var endDate = subscription.StartDateTime.AddMonths(subscriptionPlan.ValidityInMonths);

                viewModel.Subscriptions.Add(new SingleSubscriptionViewModel()
                    {
                        Id = subscription.Id,
                        Key = subscription.Id.ToString(),
                        StartDate = subscription.StartDateTime.ToString("dd.MM.yyyy"),
                        EndDate = endDate.ToString("dd.MM.yyyy"),
                        IsActive = subscription.IsActive,
                        IsPaid = subscription.IsPaid,
                        Name = subscriptionPlan.Name,
                        AmountOfBrands = subscriptionPlan.AmountOfBrands,
                        ValidityInMonths = subscriptionPlan.ValidityInMonths,
                        PricePerMonth = subscriptionPlan.PricePerMonth
                    }
                );
            }


            return View(viewModel);
        }


    }
}