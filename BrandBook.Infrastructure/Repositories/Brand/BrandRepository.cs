using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    internal class BrandRepository : Repository<Core.Domain.Brand.Brand>
    {
        internal BrandRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
