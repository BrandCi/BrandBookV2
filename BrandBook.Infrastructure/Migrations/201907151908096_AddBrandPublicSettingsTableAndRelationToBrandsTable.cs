namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandPublicSettingsTableAndRelationToBrandsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandPublicSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsPublic = c.Boolean(nullable: false),
                        ShareString = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            
            AddColumn("dbo.Brands", "BrandPublicSettingId", c => c.Int(nullable: true));
            CreateIndex("dbo.Brands", "BrandPublicSettingId");
            AddForeignKey("dbo.Brands", "BrandPublicSettingId", "dbo.BrandPublicSettings", "Id", cascadeDelete: true);
            DropColumn("dbo.Brands", "IsPublic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "IsPublic", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Brands", "BrandPublicSettingId", "dbo.BrandPublicSettings");
            DropIndex("dbo.Brands", new[] { "BrandPublicSettingId" });
            DropColumn("dbo.Brands", "BrandPublicSettingId");
            DropTable("dbo.BrandPublicSettings");
        }
    }
}
