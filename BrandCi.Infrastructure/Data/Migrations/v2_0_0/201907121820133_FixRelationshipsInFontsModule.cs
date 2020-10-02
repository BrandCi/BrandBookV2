namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixRelationshipsInFontsModule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fonts", "FontInclusion_Id", "dbo.FontInclusions");
            DropIndex("dbo.Fonts", new[] { "FontInclusion_Id" });
            AddColumn("dbo.FontInclusions", "Font_Id", c => c.Int());
            AddColumn("dbo.FontStyles", "Font_Id", c => c.Int());
            CreateIndex("dbo.FontInclusions", "Font_Id");
            CreateIndex("dbo.FontStyles", "Font_Id");
            AddForeignKey("dbo.FontInclusions", "Font_Id", "dbo.Fonts", "Id");
            AddForeignKey("dbo.FontStyles", "Font_Id", "dbo.Fonts", "Id");
            DropColumn("dbo.Fonts", "FontInclusion_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Fonts", "FontInclusion_Id", c => c.Int());
            DropForeignKey("dbo.FontStyles", "Font_Id", "dbo.Fonts");
            DropForeignKey("dbo.FontInclusions", "Font_Id", "dbo.Fonts");
            DropIndex("dbo.FontStyles", new[] { "Font_Id" });
            DropIndex("dbo.FontInclusions", new[] { "Font_Id" });
            DropColumn("dbo.FontStyles", "Font_Id");
            DropColumn("dbo.FontInclusions", "Font_Id");
            CreateIndex("dbo.Fonts", "FontInclusion_Id");
            AddForeignKey("dbo.Fonts", "FontInclusion_Id", "dbo.FontInclusions", "Id");
        }
    }
}
