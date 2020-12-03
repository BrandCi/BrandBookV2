using BrandCi.Core.Domain.Brand.Color;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.Brand
{
    public interface IColorRepository : IRepository<Color>
    {
        List<Color> GetAllColorsFromCategory(int categoryId);
    }
}
