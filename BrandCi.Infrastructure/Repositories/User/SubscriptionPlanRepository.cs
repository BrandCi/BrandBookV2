using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.User
{
    public class SubscriptionPlanRepository : Repository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
