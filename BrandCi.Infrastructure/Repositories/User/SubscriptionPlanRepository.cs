using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.User
{
    public class SubscriptionPlanRepository : Repository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
