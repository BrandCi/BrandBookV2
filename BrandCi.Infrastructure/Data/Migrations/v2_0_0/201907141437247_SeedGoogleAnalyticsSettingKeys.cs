namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedGoogleAnalyticsSettingKeys : DbMigration
    {
        public override void Up()
        {

            // Google Analytics
            Sql("SET IDENTITY_INSERT[dbo].[Settings] ON");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(14, N'google_analytics_enabled', N'0', 3, 1)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(15, N'google_analytics_trackingkey', N'', 3, 1)");
            Sql("SET IDENTITY_INSERT[dbo].[Settings] OFF");
        }

        public override void Down()
        {
        }
    }
}
