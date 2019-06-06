﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.System;
using BrandBook.Core.Repository.Setting;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Setting
{
    public class SettingRepository : Repository<Core.Domain.System.Setting>, ISettingRepository
    {
        public SettingRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public List<Core.Domain.System.Setting> GetSettingsByCategory(Category category)
        {
            return Set.Where(x => x.Category == category).ToList();
        }

        public Core.Domain.System.Setting GetSettingByKey(string key)
        {
            return Set.FirstOrDefault(x => x.Key == key);
        }
    }
}
