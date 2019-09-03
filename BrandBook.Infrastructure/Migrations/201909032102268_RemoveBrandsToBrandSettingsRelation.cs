namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBrandsToBrandSettingsRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brands", "BrandPublicSettingId", "dbo.BrandPublicSettings");
            DropForeignKey("dbo.Brands", "BrandSettingId", "dbo.BrandSettings");
            DropIndex("dbo.Brands", new[] { "BrandPublicSettingId" });
            DropIndex("dbo.Brands", new[] { "BrandSettingId" });
            DropColumn("dbo.Brands", "BrandPublicSettingId");
            DropColumn("dbo.Brands", "BrandSettingId");
            DropTable("dbo.BrandSettings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BrandSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactEmail = c.String(),
                        PrimaryHexColor = c.String(),
                        RoundedButtons = c.Boolean(nullable: false),
                        RoundedButtonsPixel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Brands", "BrandSettingId", c => c.Int(nullable: false));
            AddColumn("dbo.Brands", "BrandPublicSettingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Brands", "BrandSettingId");
            CreateIndex("dbo.Brands", "BrandPublicSettingId");
            AddForeignKey("dbo.Brands", "BrandSettingId", "dbo.BrandSettings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Brands", "BrandPublicSettingId", "dbo.BrandPublicSettings", "Id", cascadeDelete: true);
        }
    }
}
