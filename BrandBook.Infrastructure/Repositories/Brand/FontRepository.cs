using BrandBook.Core.Domain.Brand.Font;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class FontRepository : Repository<Font>, IFontRepository
    {

        public FontRepository(BrandBookDbContext context)
            : base(context)
        {
        }

    }
}
