using BrandBook.Core.Domain.Brand.Icon;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IIconRepository : IRepository<Icon>
    {

        List<Icon> GetAllIconsFromCategory(int categoryId);
    }
}
