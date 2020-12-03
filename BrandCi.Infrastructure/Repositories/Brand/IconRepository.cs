using BrandCi.Core.Domain.Brand.Icon;
using BrandCi.Core.Repositories.Brand;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand
{
    public class IconRepository : Repository<Icon>, IIconRepository
    {
        public IconRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public List<Icon> GetAllIconsFromCategory(int categoryId)
        {
            return Set
                .Where(i => i.IconCategoryId == categoryId)
                .OrderBy(i => i.ClassName)
                .ToList();
        }


    }
}
