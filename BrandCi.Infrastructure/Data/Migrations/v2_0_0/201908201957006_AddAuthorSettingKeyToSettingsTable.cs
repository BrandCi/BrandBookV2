namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAuthorSettingKeyToSettingsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[Settings] ON");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(18, N'conf_system_appauthor', N'Philipp C. Moser', 0, 1)");
            Sql("SET IDENTITY_INSERT[dbo].[Settings] OFF");
        }

        public override void Down()
        {
        }
    }
}
