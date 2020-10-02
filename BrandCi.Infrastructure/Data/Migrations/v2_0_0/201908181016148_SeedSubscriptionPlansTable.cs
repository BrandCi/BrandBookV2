namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedSubscriptionPlansTable : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT [dbo].[SubscriptionPlans] ON");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (1, N'Professional Monthly', 1, 4)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (2, N'Professional Annually', 12, 2)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (3, N'Business Monthly', 1, 7)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (4, N'Business Annually', 12, 5)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (5, N'Agency Monthly', 1, 25)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (6, N'Agency Annually', 12, 20)");
            Sql("INSERT INTO [dbo].[SubscriptionPlans] ([Id], [Name], [ValidityInMonths], [Price]) VALUES (7, N'Evaluation', 1, 0)");
            Sql("SET IDENTITY_INSERT [dbo].[SubscriptionPlans] OFF");

        }

        public override void Down()
        {
        }
    }
}