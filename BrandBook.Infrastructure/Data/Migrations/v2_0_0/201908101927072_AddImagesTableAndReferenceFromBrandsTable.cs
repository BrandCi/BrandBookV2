namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesTableAndReferenceFromBrandsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Brands", "ImageId", c => c.Int(nullable: true));
            CreateIndex("dbo.Brands", "ImageId");
            AddForeignKey("dbo.Brands", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            DropColumn("dbo.Brands", "ImageName");
            DropColumn("dbo.Brands", "ImageType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "ImageType", c => c.String());
            AddColumn("dbo.Brands", "ImageName", c => c.String());
            DropForeignKey("dbo.Brands", "ImageId", "dbo.Images");
            DropIndex("dbo.Brands", new[] { "ImageId" });
            DropColumn("dbo.Brands", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
