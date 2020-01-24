namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompaniesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlName = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Brands", "Company_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Company_Id", c => c.Int());
            CreateIndex("dbo.Brands", "Company_Id");
            CreateIndex("dbo.AspNetUsers", "Company_Id");
            AddForeignKey("dbo.Brands", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Brands", "Company_Id", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id" });
            DropIndex("dbo.Brands", new[] { "Company_Id" });
            DropColumn("dbo.AspNetUsers", "Company_Id");
            DropColumn("dbo.Brands", "Company_Id");
            DropTable("dbo.Companies");
        }
    }
}
