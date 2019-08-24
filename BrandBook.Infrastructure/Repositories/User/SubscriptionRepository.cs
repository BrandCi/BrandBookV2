using System.Collections.Generic;
using System.Linq;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.User
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public List<Subscription> GetAllUserSubscriptions(string userId)
        {
            return Set.Where(s => s.AppUserId == userId).ToList();
        }

        public List<Subscription> GetActiveUserSubscriptions(string userId)
        {
            return Set.Where(s => s.AppUserId == userId && s.IsActive).ToList();
        }
    }
}
