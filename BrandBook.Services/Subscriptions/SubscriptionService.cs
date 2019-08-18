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

                if (IsEndDateInFuture(subscription))
                {
                    return true;
                }

            }

            return false;
        }

        

        private bool IsEndDateInFuture(Subscription subscription)
        {
            var subscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId);
            var endDate = subscription.StartDateTime.AddMonths(subscriptionPlan.ValidityInMonths);

            if (endDate > new DateTime())
            {
                return true;
            }

            return false;
        }



    }
}
