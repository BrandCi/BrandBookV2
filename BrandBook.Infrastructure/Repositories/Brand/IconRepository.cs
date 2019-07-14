using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Icon;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class IconRepository : Repository<Icon>, IIconRepository
    {
        public IconRepository(BrandBookDbContext context)
            : base(context)
        {
        }


    }
}
