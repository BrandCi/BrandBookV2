using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.User
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public List<Subscription> GetAllUserSubscriptions(int userId)
        {
            return Set.Where(s => s.AppUserId == userId).ToList();
        }

        public List<Subscription> GetActiveUserSubscriptions(int userId)
        {
            return Set.Where(s => s.AppUserId == userId && s.IsActive).ToList();
        }


        public List<Subscription> GetActiveAndPaidUserSubscriptions(int userId)
        {
            return Set.Where(s => s.AppUserId == userId && s.IsActive && s.IsPaid).ToList();
        }
    }
}
