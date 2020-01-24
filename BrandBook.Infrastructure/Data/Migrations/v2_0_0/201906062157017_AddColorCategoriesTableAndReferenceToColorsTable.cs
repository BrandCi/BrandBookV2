namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorCategoriesTableAndReferenceToColorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            AddColumn("dbo.Colors", "Category_Id", c => c.Int());
            CreateIndex("dbo.Colors", "Category_Id");
            AddForeignKey("dbo.Colors", "Category_Id", "dbo.ColorCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colors", "Category_Id", "dbo.ColorCategories");
            DropForeignKey("dbo.ColorCategories", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Colors", new[] { "Category_Id" });
            DropIndex("dbo.ColorCategories", new[] { "Brand_Id" });
            DropColumn("dbo.Colors", "Category_Id");
            DropTable("dbo.ColorCategories");
        }
    }
}
