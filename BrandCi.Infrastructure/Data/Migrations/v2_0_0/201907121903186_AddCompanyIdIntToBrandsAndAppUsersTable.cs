namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCompanyIdIntToBrandsAndAppUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brands", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Brands", new[] { "Company_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id" });
            RenameColumn(table: "dbo.Brands", name: "Company_Id", newName: "CompanyId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_Id", newName: "CompanyId");
            AlterColumn("dbo.Brands", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Brands", "CompanyId");
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.Brands", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Brands", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.Brands", new[] { "CompanyId" });
            AlterColumn("dbo.AspNetUsers", "CompanyId", c => c.Int());
            AlterColumn("dbo.Brands", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyId", newName: "Company_Id");
            RenameColumn(table: "dbo.Brands", name: "CompanyId", newName: "Company_Id");
            CreateIndex("dbo.AspNetUsers", "Company_Id");
            CreateIndex("dbo.Brands", "Company_Id");
            AddForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Brands", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
