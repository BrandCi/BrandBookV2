using BrandBook.Core.Domain.Brand.Color;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IColorRepository : IRepository<Color>
    {
        List<Color> GetAllColorsFromCategory(int categoryId);
    }
}
