using BrandCi.Core;
using BrandCi.Core.Domain.User;
using BrandCi.Core.Services.Subscriptions;
using BrandCi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BrandCi.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _trialSubscriptionPlanId;

        #region Public Methods
        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            // TODO: Update Model
            // int.TryParse(ConfigurationManager.AppSettings["TrialSubscriptionPlanId"], out _trialSubscriptionPlanId);
            int.TryParse("7", out _trialSubscriptionPlanId);
        }


        public bool HasValidSubscription(int userId)
        {
            var subscriptions = _unitOfWork.SubscriptionRepository.GetActiveAndPaidUserSubscriptions(userId);

            return IsAnySubscriptionValid(userId, subscriptions);
        }


        public bool AllowedToCreateNewBrands(int userId)
        {
            var subscriptions = _unitOfWork.SubscriptionRepository.GetActiveAndPaidUserSubscriptions(userId);

            if (!BrandLimitReached(userId, subscriptions))
            {
                return true;
            }

            return false;
        }



        public string GenerateSubscriptionKey()
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public DateTime GetSubscriptionEndDate(Subscription subscription)
        {
            var validityInMonths = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId).ValidityInMonths;

            return subscription.StartDateTime.AddMonths(validityInMonths);
        }

        public bool UserHasPaidMembership(int userId)
        {
            var subscriptions =
                _unitOfWork.SubscriptionRepository.GetActiveAndPaidUserSubscriptions(userId);

            return subscriptions.Any(x => x.SubscriptionPlanId != _trialSubscriptionPlanId);
        }
        #endregion




        #region Private Methods
        private bool IsAnySubscriptionValid(int userId, IEnumerable<Subscription> subscriptions)
        {
            /*            
            if (IsMaximumOfBrandsReached(userId, subscriptions))
            {
                return false;
            }*/

            foreach (var subscription in subscriptions)
            {
                var subscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId);

                if (IsEndDateInFuture(subscription, subscriptionPlan))
                {
                    return true;
                }

            }

            return false;
        }



        private bool IsEndDateInFuture(Subscription subscription, SubscriptionPlan subscriptionPlan)
        {
            var endDate = subscription.StartDateTime.AddMonths(subscriptionPlan.ValidityInMonths);
            var currentDate = DateTime.Now;

            return DateTime.Compare(endDate, currentDate) > 0;
        }



        private bool BrandLimitReached(int userId, IEnumerable<Subscription> subscriptions)
        {
            // TODO: Update Model
            // var usersCompanyId = _unitOfWork.ApplicationUserRepository.FindById(userId).CompanyId;
            // var amountOfBrands = _unitOfWork.BrandRepository.CountBrandsByCompany(usersCompanyId);

            return 1 >= CalcAmountOfPossibleBrands(subscriptions);
        }


        private int CalcAmountOfPossibleBrands(IEnumerable<Subscription> subscriptions)
        {
            return subscriptions
                .Select(subscription => _unitOfWork.SubscriptionPlanRepository
                                        .FindById(subscription.SubscriptionPlanId))
                                        .Select(subscriptionPlan => subscriptionPlan.AmountOfBrands)
                                        .Sum();
        }

        #endregion

    }
}
