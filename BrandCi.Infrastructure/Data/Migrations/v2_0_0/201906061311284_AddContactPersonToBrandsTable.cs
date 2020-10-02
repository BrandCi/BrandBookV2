namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddContactPersonToBrandsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "ContactPerson", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Brands", "ContactPerson");
        }
    }
}
