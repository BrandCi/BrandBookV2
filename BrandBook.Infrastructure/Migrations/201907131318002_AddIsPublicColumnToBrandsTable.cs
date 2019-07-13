namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPublicColumnToBrandsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings");
            DropIndex("dbo.Brands", new[] { "BrandSetting_Id" });
            RenameColumn(table: "dbo.Brands", name: "BrandSetting_Id", newName: "BrandSettingId");
            AddColumn("dbo.Brands", "IsPublic", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Brands", "BrandSettingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Brands", "BrandSettingId");
            AddForeignKey("dbo.Brands", "BrandSettingId", "dbo.BrandSettings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brands", "BrandSettingId", "dbo.BrandSettings");
            DropIndex("dbo.Brands", new[] { "BrandSettingId" });
            AlterColumn("dbo.Brands", "BrandSettingId", c => c.Int());
            DropColumn("dbo.Brands", "IsPublic");
            RenameColumn(table: "dbo.Brands", name: "BrandSettingId", newName: "BrandSetting_Id");
            CreateIndex("dbo.Brands", "BrandSetting_Id");
            AddForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings", "Id");
        }
    }
}
