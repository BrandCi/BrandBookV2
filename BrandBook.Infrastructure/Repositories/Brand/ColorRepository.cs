using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {

        public ColorRepository(BrandBookDbContext context)
            : base(context)
        {
        }

    }
}
