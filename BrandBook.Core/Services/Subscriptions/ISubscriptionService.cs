using BrandBook.Core.Domain.User;
using System;

namespace BrandBook.Core.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        bool HasValidSubscription(int userId);
        bool AllowedToCreateNewBrands(int userId);
        string GenerateSubscriptionKey();
        DateTime GetSubscriptionEndDate(Subscription subscription);
        bool UserHasPaidMembership(int userId);
    }
}
