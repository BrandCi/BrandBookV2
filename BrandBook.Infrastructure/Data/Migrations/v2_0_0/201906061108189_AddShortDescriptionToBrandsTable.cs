namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionToBrandsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "ShortDescription");
        }
    }
}
