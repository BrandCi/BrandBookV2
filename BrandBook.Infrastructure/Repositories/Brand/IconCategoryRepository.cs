using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Icon;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class IconCategoryRepository : Repository<IconCategory>, IIconCategoryRepository
    {
        public IconCategoryRepository(BrandBookDbContext context)
            : base(context)
        {
        }

        public List<IconCategory> GetCategoriesForBrand(int brandId)
        {
            return Set.Where(cc => cc.BrandId == brandId).ToList();
        }
    }
}
