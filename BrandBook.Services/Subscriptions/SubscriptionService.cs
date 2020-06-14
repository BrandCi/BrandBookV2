using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandBook.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Public Methods
        public SubscriptionService()
        {
            this._unitOfWork = new UnitOfWork();
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
            var usersCompanyId = _unitOfWork.CompanyMembershipRepository.GetCompanyIdByUserId(userId);
            var amountOfBrands = _unitOfWork.BrandRepository.CountBrandsByCompany(usersCompanyId);

            return amountOfBrands >= CalcAmountOfPossibleBrands(subscriptions);
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
