using BrandBook.Core.Domain.User;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.User
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        List<Subscription> GetAllUserSubscriptions(string userId);
        List<Subscription> GetActiveUserSubscriptions(string userId);
        List<Subscription> GetActiveAndPaidUserSubscriptions(string userId);

    }
}
