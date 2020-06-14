namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCompanyMembershipsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });

            CreateTable(
                "dbo.CompanyMemberships",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AppUserId = c.Int(nullable: false),
                    CompanyId = c.Int(nullable: false),
                    IsCompanyManager = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.CompanyId);

            // Sql("INSERT INTO dbo.CompanyMemberships (AppUserId, CompanyId, IsCompanyManager) VALUES ((SELECT Id AS AppUserId, CompanyId AS CompanyId, 'False' AS IsCompanyManager FROM AspNetUsers));");

            DropColumn("dbo.AspNetUsers", "CompanyId");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CompanyMemberships", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyMemberships", "AppUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CompanyMemberships", new[] { "CompanyId" });
            DropIndex("dbo.CompanyMemberships", new[] { "AppUserId" });
            DropTable("dbo.CompanyMemberships");
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
