using BrandBook.Core.Domain.System;
using BrandBook.Core.Repositories.System;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.System
{
    public class Log4NetLogRepository : Repository<Log4NetLog>, ILog4NetLogRepository
    {
        public Log4NetLogRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
