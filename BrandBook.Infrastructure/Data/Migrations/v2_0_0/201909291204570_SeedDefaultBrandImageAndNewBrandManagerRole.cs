namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDefaultBrandImageAndNewBrandManagerRole : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[BlogImages] ON");
            Sql("INSERT INTO[dbo].[BlogImages] ([Id], [Name], [ContentType]) VALUES(1, N'default.jpg', N'image/jpeg')");
            Sql("SET IDENTITY_INSERT[dbo].[BlogImages] OFF");
        }

        public override void Down()
        {
        }
    }
}
