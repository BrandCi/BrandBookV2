using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

using BrandBook.Core.Services.Subscriptions;

namespace BrandBook.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;


        public SubscriptionService()
        {
            this._unitOfWork = new UnitOfWork();
        }


        public bool HasValidSubscription(string userId)
        {
            var subscriptions = _unitOfWork.SubscriptionRepository.GetActiveAndPaidUserSubscriptions(userId);

            return IsAnySubscriptionValid(userId, subscriptions);
        }


        public string GenerateSubscriptionKey()
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }




        private bool IsAnySubscriptionValid(string userId, IEnumerable<Subscription> subscriptions)
        {
            
            if (IsMaximumOfBrandsReached(userId, subscriptions))
            {
                return false;
            }

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



        private bool IsMaximumOfBrandsReached(string userId, IEnumerable<Subscription> subscriptions)
        {
            var usersCompanyId = _unitOfWork.AppUserRepository.FindById(userId).CompanyId;
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



    }
}
