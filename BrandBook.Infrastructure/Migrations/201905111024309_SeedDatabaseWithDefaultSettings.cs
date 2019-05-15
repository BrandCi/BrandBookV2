namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDatabaseWithDefaultSettings : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT[dbo].[Settings] ON");

            // System Settings
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(1, N'conf_system_apptitle', N'Brand Ci', 0, 1)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(2, N'conf_system_baseisurl', N'abc.xyz.de', 0, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(3, N'conf_system_email', N'abc@xyz.de', 0, 2)");

            // Media Settings
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(4, N'conf_media_server', N'abc.xyz.de', 2, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(5, N'conf_media_key', N'a1b2c3d4e5', 2, 2)");

            // User Settings
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(6, N'conf_user_pass_requiredlength', N'6', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(7, N'conf_user_pass_requirenonletterordigit', N'1', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(8, N'conf_user_pass_requiredigit', N'1', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(9, N'conf_user_pass_requirelowercase', N'1', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(10, N'conf_user_pass_requireuppercase', N'1', 1, 2)");

            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(11, N'conf_user_lockout_enable', N'1', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(12, N'conf_user_lockout_lockouttime', N'5', 1, 2)");
            Sql("INSERT INTO[dbo].[Settings] ([Id], [Key], [Value], [Category], [AccessLevel]) VALUES(13, N'conf_user_lockout_failedattemtsbeforelockout', N'5', 1, 2)");

            Sql("SET IDENTITY_INSERT[dbo].[Settings] OFF");

    }

    public override void Down()
        {
        }
    }
}
