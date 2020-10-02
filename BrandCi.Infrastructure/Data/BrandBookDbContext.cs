using BrandCi.Core.Domain.Brand;
using BrandCi.Core.Domain.Brand.Color;
using BrandCi.Core.Domain.Brand.Font;
using BrandCi.Core.Domain.Brand.Icon;
using BrandCi.Core.Domain.Company;
using BrandCi.Core.Domain.Frontend;
using BrandCi.Core.Domain.Resource;
using BrandCi.Core.Domain.System;
using BrandCi.Core.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BrandCi.Infrastructure.Data
{
    public class BrandBookDbContext : IdentityDbContext<AppUser>
    {
        // General
        public DbSet<Log4NetLog> Log4NetLogs { get; set; }

        // User
        public DbSet<Company> Companies { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }


        // Brand
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




        /* Frontend - Blog */
        public DbSet<BlogEntry> BlogEntries { get; set; }




        public BrandBookDbContext(DbContextOptions<BrandBookDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
