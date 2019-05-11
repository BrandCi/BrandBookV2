using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.System;

namespace BrandBook.Core.RepositoryInterfaces.Setting
{
    public interface ISettingRepository : IRepository<Domain.System.Setting>
    {
        List<Domain.System.Setting> GetSettingsByCategory(Category category);
    }
}
