using BrandCi.Core.Domain.Brand.Font;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.Brand.Font
{
    public interface IFontStyleRepository : IRepository<FontStyle>
    {

        List<FontStyle> GetAllForFont(int fontId);

    }
}
