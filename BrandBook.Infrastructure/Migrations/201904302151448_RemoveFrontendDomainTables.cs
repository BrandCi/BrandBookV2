namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFrontendDomainTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprintValues", "Category_Id", "dbo.ImprintCategories");
            DropIndex("dbo.ImprintValues", new[] { "Category_Id" });
            DropTable("dbo.ImprintCategories");
            DropTable("dbo.ImprintValues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImprintValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Position = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImprintCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ImprintValues", "Category_Id");
            AddForeignKey("dbo.ImprintValues", "Category_Id", "dbo.ImprintCategories", "Id");
        }
    }
}
