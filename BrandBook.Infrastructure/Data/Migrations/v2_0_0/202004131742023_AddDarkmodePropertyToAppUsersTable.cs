namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDarkmodePropertyToAppUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsDarkmodeEnabled", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDarkmodeEnabled");
        }
    }
}
