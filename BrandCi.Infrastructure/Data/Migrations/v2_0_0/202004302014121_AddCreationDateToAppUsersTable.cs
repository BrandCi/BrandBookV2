namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCreationDateToAppUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreationDate");
        }
    }
}
