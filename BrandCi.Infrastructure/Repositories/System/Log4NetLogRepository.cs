using BrandCi.Core.Domain.System;
using BrandCi.Core.Repositories.System;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.System
{
    public class Log4NetLogRepository : Repository<Log4NetLog>, ILog4NetLogRepository
    {
        public Log4NetLogRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
