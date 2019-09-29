namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDefaultBrandImageAndNewBrandManagerRole : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'd9cafbe1-8a59-4ce8-8d4f-5edd96bd0954', N'BlogManager', N'IdentityRole')");

            Sql("SET IDENTITY_INSERT[dbo].[BlogImages] ON");
            Sql("INSERT INTO[dbo].[BlogImages] ([Id], [Name], [ContentType]) VALUES(1, N'default.jpg', N'image/jpeg')");
            Sql("SET IDENTITY_INSERT[dbo].[BlogImages] OFF");


        }

        public override void Down()
        {
        }
    }
}
