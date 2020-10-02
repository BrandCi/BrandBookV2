namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateRelationBetweenFontsAndFontsInclusionsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FontInclusions", "FontId", "dbo.Fonts");
            DropIndex("dbo.FontInclusions", new[] { "FontId" });
            AddColumn("dbo.Fonts", "FontInclusionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fonts", "FontInclusionId");
            AddForeignKey("dbo.Fonts", "FontInclusionId", "dbo.FontInclusions", "Id", cascadeDelete: true);
            DropColumn("dbo.FontInclusions", "FontId");
        }

        public override void Down()
        {
            AddColumn("dbo.FontInclusions", "FontId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Fonts", "FontInclusionId", "dbo.FontInclusions");
            DropIndex("dbo.Fonts", new[] { "FontInclusionId" });
            DropColumn("dbo.Fonts", "FontInclusionId");
            CreateIndex("dbo.FontInclusions", "FontId");
            AddForeignKey("dbo.FontInclusions", "FontId", "dbo.Fonts", "Id", cascadeDelete: true);
        }
    }
}
