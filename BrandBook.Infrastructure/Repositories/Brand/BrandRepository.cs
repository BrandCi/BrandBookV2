using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class BrandRepository : Repository<Core.Domain.Brand.Brand>, IBrandRepository
    {
        public BrandRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
