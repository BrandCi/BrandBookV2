namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserlikeSettingToSettingsTable : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT[dbo].[Settings] ON");

            // Userlike Settings
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(16, N'ext_userlike_enabled', N'0', 4, 1)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(17, N'ext_userlike_source', N'0', 4, 1)");

            Sql("SET IDENTITY_INSERT[dbo].[Settings] OFF");


        }

        public override void Down()
        {
        }
    }
}
