using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Icon;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IIconCategoryRepository : IRepository<IconCategory>
    {
        List<IconCategory> GetCategoriesForBrand(int brandId);
    }
}
