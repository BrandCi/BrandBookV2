namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIconsTablesAndAdjustedRelationsInColorsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Colors", "BrandId", "dbo.Brands");
            DropIndex("dbo.Colors", new[] { "BrandId" });
            RenameColumn(table: "dbo.Colors", name: "BrandId", newName: "Brand_Id");
            CreateTable(
                "dbo.IconCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sorting = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Prefix = c.String(),
                        IconCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IconCategories", t => t.IconCategoryId, cascadeDelete: true)
                .Index(t => t.IconCategoryId);
            
            AlterColumn("dbo.Colors", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Colors", "Brand_Id");
            AddForeignKey("dbo.Colors", "Brand_Id", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colors", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Icons", "IconCategoryId", "dbo.IconCategories");
            DropForeignKey("dbo.IconCategories", "BrandId", "dbo.Brands");
            DropIndex("dbo.Icons", new[] { "IconCategoryId" });
            DropIndex("dbo.IconCategories", new[] { "BrandId" });
            DropIndex("dbo.Colors", new[] { "Brand_Id" });
            AlterColumn("dbo.Colors", "Brand_Id", c => c.Int(nullable: false));
            DropTable("dbo.Icons");
            DropTable("dbo.IconCategories");
            RenameColumn(table: "dbo.Colors", name: "Brand_Id", newName: "BrandId");
            CreateIndex("dbo.Colors", "BrandId");
            AddForeignKey("dbo.Colors", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
