namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateFontRelatedTablesWithCorrectRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FontInclusions", "Font_Id", "dbo.Fonts");
            DropForeignKey("dbo.Fonts", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.FontStyles", "Font_Id", "dbo.Fonts");
            DropIndex("dbo.FontInclusions", new[] { "Font_Id" });
            DropIndex("dbo.Fonts", new[] { "Brand_Id" });
            DropIndex("dbo.FontStyles", new[] { "Font_Id" });
            RenameColumn(table: "dbo.FontInclusions", name: "Font_Id", newName: "FontId");
            RenameColumn(table: "dbo.Fonts", name: "Brand_Id", newName: "BrandId");
            RenameColumn(table: "dbo.FontStyles", name: "Font_Id", newName: "FontId");
            AddColumn("dbo.FontInclusions", "HtmlInline", c => c.String());
            AlterColumn("dbo.FontInclusions", "FontId", c => c.Int(nullable: false));
            AlterColumn("dbo.Fonts", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.FontStyles", "FontId", c => c.Int(nullable: false));
            CreateIndex("dbo.FontInclusions", "FontId");
            CreateIndex("dbo.Fonts", "BrandId");
            CreateIndex("dbo.FontStyles", "FontId");
            AddForeignKey("dbo.FontInclusions", "FontId", "dbo.Fonts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fonts", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FontStyles", "FontId", "dbo.Fonts", "Id", cascadeDelete: true);
            DropColumn("dbo.FontInclusions", "InlineIntegration");
        }

        public override void Down()
        {
            AddColumn("dbo.FontInclusions", "InlineIntegration", c => c.String());
            DropForeignKey("dbo.FontStyles", "FontId", "dbo.Fonts");
            DropForeignKey("dbo.Fonts", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.FontInclusions", "FontId", "dbo.Fonts");
            DropIndex("dbo.FontStyles", new[] { "FontId" });
            DropIndex("dbo.Fonts", new[] { "BrandId" });
            DropIndex("dbo.FontInclusions", new[] { "FontId" });
            AlterColumn("dbo.FontStyles", "FontId", c => c.Int());
            AlterColumn("dbo.Fonts", "BrandId", c => c.Int());
            AlterColumn("dbo.FontInclusions", "FontId", c => c.Int());
            DropColumn("dbo.FontInclusions", "HtmlInline");
            RenameColumn(table: "dbo.FontStyles", name: "FontId", newName: "Font_Id");
            RenameColumn(table: "dbo.Fonts", name: "BrandId", newName: "Brand_Id");
            RenameColumn(table: "dbo.FontInclusions", name: "FontId", newName: "Font_Id");
            CreateIndex("dbo.FontStyles", "Font_Id");
            CreateIndex("dbo.Fonts", "Brand_Id");
            CreateIndex("dbo.FontInclusions", "Font_Id");
            AddForeignKey("dbo.FontStyles", "Font_Id", "dbo.Fonts", "Id");
            AddForeignKey("dbo.Fonts", "Brand_Id", "dbo.Brands", "Id");
            AddForeignKey("dbo.FontInclusions", "Font_Id", "dbo.Fonts", "Id");
        }
    }
}
