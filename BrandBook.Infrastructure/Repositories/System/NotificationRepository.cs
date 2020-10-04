using BrandBook.Core.Domain.System.Notification;
using BrandBook.Core.Repositories.System;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.System
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
