namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedInitialData : DbMigration
    {
        public override void Up()
        {   
            // Create Built In Roles
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Name], [Discriminator]) VALUES (N'AppUser', N'IdentityRole')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Name], [Discriminator]) VALUES (N'Administrator', N'IdentityRole')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Name], [Discriminator]) VALUES (N'BlogManager', N'IdentityRole')");
        }

        public override void Down()
        {
        }
    }
}
