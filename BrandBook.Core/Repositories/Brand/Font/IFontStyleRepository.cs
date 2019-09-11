using System.Collections.Generic;
using BrandBook.Core.Domain.Brand.Font;

namespace BrandBook.Core.Repositories.Brand.Font
{
    public interface IFontStyleRepository : IRepository<FontStyle>
    {

        List<FontStyle> GetAllForFont(int fontId);

    }
}
