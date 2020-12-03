using BrandCi.Core.Domain.Brand.Icon;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.Brand
{
    public interface IIconRepository : IRepository<Icon>
    {

        List<Icon> GetAllIconsFromCategory(int categoryId);
    }
}
