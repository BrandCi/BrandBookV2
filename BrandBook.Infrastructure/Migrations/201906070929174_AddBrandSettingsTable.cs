namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandSettingsTable : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Brands", "BrandSetting_Id", c => c.Int());
            CreateIndex("dbo.Brands", "BrandSetting_Id");
            AddForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings", "Id");
            DropColumn("dbo.Brands", "ContactPerson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "ContactPerson", c => c.String());
            DropForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings");
            DropIndex("dbo.Brands", new[] { "BrandSetting_Id" });
            DropColumn("dbo.Brands", "BrandSetting_Id");
            DropTable("dbo.BrandSettings");
        }
    }
}
