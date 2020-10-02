namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddHexColorCodeToColorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colors", "HexColorCode", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Colors", "HexColorCode");
        }
    }
}
