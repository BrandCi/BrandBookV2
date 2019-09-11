using BrandBook.Core.Repositories.Brand.Font;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand.Font
{
    public class FontRepository : Repository<Core.Domain.Brand.Font.Font>, IFontRepository
    {

        public FontRepository(BrandBookDbContext context)
            : base(context)
        {
        }

    }
}
