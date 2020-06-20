using BrandBook.Core.Domain.Brand.Font;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand.Font
{
    public interface IFontStyleRepository : IRepository<FontStyle>
    {

        List<FontStyle> GetAllForFont(int fontId);

    }
}
