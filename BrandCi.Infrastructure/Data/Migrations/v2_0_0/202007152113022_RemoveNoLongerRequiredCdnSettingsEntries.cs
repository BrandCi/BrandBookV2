namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveNoLongerRequiredCdnSettingsEntries : DbMigration
    {
        public override void Up()
        {
            // Delete Entries
            // Configuration for CDN has moved to MachineAppSettings
            Sql("DELETE FROM [dbo].[Settings] WHERE Id IN(4, 5)");
        }

        public override void Down()
        {
        }
    }
}
