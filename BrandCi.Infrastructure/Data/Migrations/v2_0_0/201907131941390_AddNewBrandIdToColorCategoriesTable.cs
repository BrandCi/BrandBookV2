namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNewBrandIdToColorCategoriesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ColorCategories", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.ColorCategories", new[] { "Brand_Id" });
            RenameColumn(table: "dbo.ColorCategories", name: "Brand_Id", newName: "BrandId");
            AlterColumn("dbo.ColorCategories", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.ColorCategories", "BrandId");
            AddForeignKey("dbo.ColorCategories", "BrandId", "dbo.Brands", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ColorCategories", "BrandId", "dbo.Brands");
            DropIndex("dbo.ColorCategories", new[] { "BrandId" });
            AlterColumn("dbo.ColorCategories", "BrandId", c => c.Int());
            RenameColumn(table: "dbo.ColorCategories", name: "BrandId", newName: "Brand_Id");
            CreateIndex("dbo.ColorCategories", "Brand_Id");
            AddForeignKey("dbo.ColorCategories", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}
