namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationsInColorsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Colors", "Category_Id", "dbo.ColorCategories");
            DropForeignKey("dbo.Colors", "CmykValue_Id", "dbo.CmykValues");
            DropForeignKey("dbo.Colors", "RgbValue_Id", "dbo.RgbValues");
            DropIndex("dbo.Colors", new[] { "Category_Id" });
            DropIndex("dbo.Colors", new[] { "CmykValue_Id" });
            DropIndex("dbo.Colors", new[] { "RgbValue_Id" });
            RenameColumn(table: "dbo.Colors", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Colors", name: "CmykValue_Id", newName: "CmykValueId");
            RenameColumn(table: "dbo.Colors", name: "RgbValue_Id", newName: "RgbValueId");
            AlterColumn("dbo.Colors", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Colors", "CmykValueId", c => c.Int(nullable: false));
            AlterColumn("dbo.Colors", "RgbValueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Colors", "CategoryId");
            CreateIndex("dbo.Colors", "RgbValueId");
            CreateIndex("dbo.Colors", "CmykValueId");
            AddForeignKey("dbo.Colors", "CategoryId", "dbo.ColorCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Colors", "CmykValueId", "dbo.CmykValues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Colors", "RgbValueId", "dbo.RgbValues", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colors", "RgbValueId", "dbo.RgbValues");
            DropForeignKey("dbo.Colors", "CmykValueId", "dbo.CmykValues");
            DropForeignKey("dbo.Colors", "CategoryId", "dbo.ColorCategories");
            DropIndex("dbo.Colors", new[] { "CmykValueId" });
            DropIndex("dbo.Colors", new[] { "RgbValueId" });
            DropIndex("dbo.Colors", new[] { "CategoryId" });
            AlterColumn("dbo.Colors", "RgbValueId", c => c.Int());
            AlterColumn("dbo.Colors", "CmykValueId", c => c.Int());
            AlterColumn("dbo.Colors", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Colors", name: "RgbValueId", newName: "RgbValue_Id");
            RenameColumn(table: "dbo.Colors", name: "CmykValueId", newName: "CmykValue_Id");
            RenameColumn(table: "dbo.Colors", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Colors", "RgbValue_Id");
            CreateIndex("dbo.Colors", "CmykValue_Id");
            CreateIndex("dbo.Colors", "Category_Id");
            AddForeignKey("dbo.Colors", "RgbValue_Id", "dbo.RgbValues", "Id");
            AddForeignKey("dbo.Colors", "CmykValue_Id", "dbo.CmykValues", "Id");
            AddForeignKey("dbo.Colors", "Category_Id", "dbo.ColorCategories", "Id");
        }
    }
}
