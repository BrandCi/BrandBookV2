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

            return (
                        from subscription in subscriptions
                        let subscriptionPlan = _unitOfWork.SubscriptionPlanRepository
                            .FindById(subscription.SubscriptionPlanId) where 
                            IsEndDateInFuture(subscription, subscriptionPlan)
                        select subscription
                    )
                    .Any();
        }

        

        private bool IsEndDateInFuture(Subscription subscription, SubscriptionPlan subscriptionPlan)
        {
            var endDate = subscription.StartDateTime.AddMonths(subscriptionPlan.ValidityInMonths);

            return endDate > new DateTime();
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
