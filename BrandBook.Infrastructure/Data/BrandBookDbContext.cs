using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend.Legal;
using BrandBook.Core.Domain.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Infrastructure.Data
{
    public class BrandBookDbContext : IdentityDbContext<User>
    {


        // Frontend Domain
        public DbSet<ImprintValue> FeImprintValues { get; set; }




        public BrandBookDbContext()
            : base("name=DefaultConnection")
        {

        }

        public static BrandBookDbContext Create()
        {
            return new BrandBookDbContext();
        }

    }
}
