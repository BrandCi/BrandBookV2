namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSortingColumnToColorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colors", "Sorting", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Colors", "Sorting");
        }
    }
}
