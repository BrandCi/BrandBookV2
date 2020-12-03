using BrandCi.Core.Domain.System.Notification;
using BrandCi.Core.Repositories.System;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.System
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
