namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCompaniesTable : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT [dbo].[Companies] ON");
            Sql("INSERT INTO[dbo].[Companies]([Id], [Name], [UrlName], [ContactEmail]) VALUES(1, N'Philipp C. Moser', N'philipp-c-moser', N'info@philipp-moser.de')");
            Sql("SET IDENTITY_INSERT[dbo].[Companies] OFF");



            Sql("UPDATE [dbo].[AspNetUsers] SET Company_Id = 1 WHERE  Id = N'2d370030-c2c5-4196-a9e2-c423398630e3'");



        }
        
        public override void Down()
        {

            Sql("DELETE FROM [dbo].[Companies] WHERE Id = 1");

        }
    }
}
