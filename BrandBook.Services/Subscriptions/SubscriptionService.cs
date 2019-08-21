using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure;

namespace BrandBook.Services.Subscriptions
{
    public class SubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly int _evaluationKeyLength = 6;
        private readonly int _paidKeyLength = 8;

        public SubscriptionService()
        {
            this._unitOfWork = new UnitOfWork();
        }


        public bool HasValidSubscription(string userId)
        {
            var subscriptions = _unitOfWork.SubscriptionRepository.GetActiveUserSubscriptions(userId);
            
            return IsAnySubscriptionValid(userId, subscriptions);
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


        private string GenerateKeyFor(int typeOfKey)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, typeOfKey)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }


        



    }
}
