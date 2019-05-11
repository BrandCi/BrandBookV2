using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.RepositoryInterfaces.Setting;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Setting
{
    public class SettingRepository : Repository<Core.Domain.System.Setting>, ISettingRepository
    {
        public SettingRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
