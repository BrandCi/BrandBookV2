using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        bool HasValidSubscription(int userId);
        bool AllowedToCreateNewBrands(int userId);
        string GenerateSubscriptionKey();
        DateTime GetSubscriptionEndDate(Subscription subscription);
    }
}
