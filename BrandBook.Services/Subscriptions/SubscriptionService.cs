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

            foreach(var subscription in subscriptions)
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

            return endDate > new DateTime();
        }



        private bool IsMaximumOfBrandsReached(int amountCurrentBrands, int amountPossibleBrands)
        {


            return amountCurrentBrands >= amountPossibleBrands;
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
