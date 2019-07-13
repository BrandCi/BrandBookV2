namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandRelationToColorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colors", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Colors", "BrandId");
            AddForeignKey("dbo.Colors", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colors", "BrandId", "dbo.Brands");
            DropIndex("dbo.Colors", new[] { "BrandId" });
            DropColumn("dbo.Colors", "BrandId");
        }
    }
}
