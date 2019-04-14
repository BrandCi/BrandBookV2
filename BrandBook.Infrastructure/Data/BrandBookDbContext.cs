using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Infrastructure.Data
{
    public class BrandBookDbContext : DbContext
    {
        public BrandBookDbContext()
            : base("name=DefaultConnection")
        {

        }

    }
}
