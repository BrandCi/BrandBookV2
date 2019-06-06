using System.Collections.Generic;
using BrandBook.Core.Domain.System;

namespace BrandBook.Core.Repositories.Setting
{
    public interface ISettingRepository : IRepository<Domain.System.Setting>
    {
        List<Domain.System.Setting> GetSettingsByCategory(Category category);

        Domain.System.Setting GetSettingByKey(string key);
    }
}
