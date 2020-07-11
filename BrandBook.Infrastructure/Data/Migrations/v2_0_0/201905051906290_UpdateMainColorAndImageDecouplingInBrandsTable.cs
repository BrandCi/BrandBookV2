namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateMainColorAndImageDecouplingInBrandsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "ImageName", c => c.String());
            AddColumn("dbo.Brands", "ImageType", c => c.String());
            AddColumn("dbo.Brands", "MainHexColor", c => c.String());
            DropColumn("dbo.Brands", "Image");
            DropColumn("dbo.Brands", "MainColor");
        }

        public override void Down()
        {
            AddColumn("dbo.Brands", "MainColor", c => c.String());
            AddColumn("dbo.Brands", "Image", c => c.String());
            DropColumn("dbo.Brands", "MainHexColor");
            DropColumn("dbo.Brands", "ImageType");
            DropColumn("dbo.Brands", "ImageName");
        }
    }
}
