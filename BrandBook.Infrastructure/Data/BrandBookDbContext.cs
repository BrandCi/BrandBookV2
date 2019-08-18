using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.Domain.Brand.Font;
using BrandBook.Core.Domain.Brand.Icon;
using BrandBook.Core.Domain.Company;
using BrandBook.Core.Domain.Resource;
using BrandBook.Core.Domain.System;
using BrandBook.Core.Domain.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Infrastructure.Data
{
    public class BrandBookDbContext : IdentityDbContext<AppUser>
    {
        /* User */
        public DbSet<Company> Companies { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }


        /* Brand */
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandPublicSetting> BrandPublicSettings { get; set; }

        // Colors
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorCategory> ColorCategories { get; set; }
        public DbSet<RgbValue> RgbValues { get; set; }
        public DbSet<CmykValue> CmykValues { get; set; }

        // Icons
        public DbSet<Icon> Icons { get; set; }
        public DbSet<IconCategory> IconCategories { get; set; }

        // Fonts
        public DbSet<Font> Fonts { get; set; }
        public DbSet<FontStyle> FontStyles { get; set; }
        public DbSet<FontInclusion> FontInclusions { get; set; }

        // Settings
        public DbSet<Setting> Settings { get; set; }

        // Resources
        public DbSet<Image> Images { get; set; }




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
