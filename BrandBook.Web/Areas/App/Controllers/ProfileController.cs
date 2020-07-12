using BrandBook.Core;
using BrandBook.Core.ViewModels.App.Profile;
using BrandBook.Core.ViewModels.App.Subscriptions;
using BrandBook.Infrastructure;
using BrandBook.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class ProfileController : AppMvcControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly SubscriptionService _subscriptionService;
        #endregion


        #region Constructor
        public ProfileController()
        {
            _unitOfWork = new UnitOfWork();
            _subscriptionService = new SubscriptionService();
        }
        #endregion


        #region Actions
        public ActionResult Index()
        {
            var appUser = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId<int>());


            var model = new GeneralUserDataViewModel()
            {
                UserName = appUser.UserName,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
            };


            return View(model);
        }

        public ActionResult Subscriptions()
        {
            var userId = User.Identity.GetUserId<int>();
            var subscriptions = _unitOfWork.SubscriptionRepository.GetAllUserSubscriptions(userId);


            var viewModel = new SubscriptionsViewModel()
            {
                Subscriptions = new List<SingleSubscriptionViewModel>(),
                HasValidSubscription = _subscriptionService.HasValidSubscription(userId)
            };


            foreach (var subscription in subscriptions)
            {
                var subscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId);
                var endDate = subscription.StartDateTime.AddMonths(subscriptionPlan.ValidityInMonths);

                viewModel.Subscriptions.Add(new SingleSubscriptionViewModel()
                {
                    Id = subscription.Id,
                    Key = subscription.Key,
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

        public ActionResult ChangeAppColorMode(string mode)
        {
            var user = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId<int>());

            user.IsDarkmodeEnabled = false;

            if (mode == "dark")
            {
                user.IsDarkmodeEnabled = true;
            }

            _unitOfWork.AppUserRepository.UpdateWithModification(user);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "Dashboard", new { area = "App" });
        }
        #endregion


        #region Public POST Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserData(GeneralUserDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile", new { area = "App" });
            }

            var appUser = _unitOfWork.AppUserRepository.FindById(User.Identity.GetUserId<int>());

            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;

            _unitOfWork.AppUserRepository.UpdateWithModification(appUser);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "Profile", new { area = "App" });
        }
        #endregion
    }
}