namespace BrandCi.Infrastructure.Migrations
{
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
                    RoundedButtons = c.Boolean(nullable: false, defaultValue: true),
                    RoundedButtonsPixel = c.Int(nullable: false, defaultValue: 5),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Brands", "BrandSetting_Id", c => c.Int());
            CreateIndex("dbo.Brands", "BrandSetting_Id");
            AddForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings", "Id");

            // Migrate current available Data to BrandSettings
            Sql("INSERT INTO dbo.BrandSettings (ContactEmail) SELECT ContactPerson FROM dbo.Brands");

            DropColumn("dbo.Brands", "ContactPerson");
        }

        public override void Down()
        {
            AddColumn("dbo.Brands", "ContactPerson", c => c.String());

            // Migrate current available Data to Brands
            Sql("INSERT INTO dbo.Brands (ContactPerson) SELECT ContactEmail FROM dbo.BrandSettings");

            DropForeignKey("dbo.Brands", "BrandSetting_Id", "dbo.BrandSettings");
            DropIndex("dbo.Brands", new[] { "BrandSetting_Id" });
            DropColumn("dbo.Brands", "BrandSetting_Id");
            DropTable("dbo.BrandSettings");
        }
    }
}
