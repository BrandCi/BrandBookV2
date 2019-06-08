namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllInitialFontsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FontInclusions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InlineIntegration = c.String(),
                        CssImport = c.String(),
                        CssProperty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fonts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Brand_Id = c.Int(),
                        FontInclusion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .ForeignKey("dbo.FontInclusions", t => t.FontInclusion_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.FontInclusion_Id);
            
            CreateTable(
                "dbo.FontStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Style = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fonts", "FontInclusion_Id", "dbo.FontInclusions");
            DropForeignKey("dbo.Fonts", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Fonts", new[] { "FontInclusion_Id" });
            DropIndex("dbo.Fonts", new[] { "Brand_Id" });
            DropTable("dbo.FontStyles");
            DropTable("dbo.Fonts");
            DropTable("dbo.FontInclusions");
        }
    }
}
