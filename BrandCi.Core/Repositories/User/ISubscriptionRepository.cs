using BrandCi.Core.Domain.User;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.User
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        List<Subscription> GetAllUserSubscriptions(int userId);
        List<Subscription> GetActiveUserSubscriptions(int userId);
        List<Subscription> GetActiveAndPaidUserSubscriptions(int userId);

    }
}
