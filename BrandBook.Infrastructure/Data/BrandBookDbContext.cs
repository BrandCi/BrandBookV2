using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.Domain.System;
using BrandBook.Core.Domain.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Infrastructure.Data
{
    public class BrandBookDbContext : IdentityDbContext<AppUser>
    {
        
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorCategory> ColorCategories { get; set; }
        public DbSet<RgbValue> RgbValues { get; set; }
        public DbSet<CmykValue> CmykValues { get; set; }
        public DbSet<Setting> Settings { get; set; }




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
