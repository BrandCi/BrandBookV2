namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewCategoriesTableForImprint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImprintCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ImprintValues", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.ImprintValues", "Category_Id", c => c.Int());
            CreateIndex("dbo.ImprintValues", "Category_Id");
            AddForeignKey("dbo.ImprintValues", "Category_Id", "dbo.ImprintCategories", "Id");
            DropColumn("dbo.ImprintValues", "ColorCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImprintValues", "ColorCategory", c => c.Int(nullable: false));
            DropForeignKey("dbo.ImprintValues", "Category_Id", "dbo.ImprintCategories");
            DropIndex("dbo.ImprintValues", new[] { "Category_Id" });
            DropColumn("dbo.ImprintValues", "Category_Id");
            DropColumn("dbo.ImprintValues", "Position");
            DropTable("dbo.ImprintCategories");
        }
    }
}
