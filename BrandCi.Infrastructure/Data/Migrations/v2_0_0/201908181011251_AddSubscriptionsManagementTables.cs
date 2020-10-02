namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSubscriptionsManagementTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriptionPlans",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ValidityInMonths = c.Int(nullable: false),
                    Price = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Subscriptions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StartDateTime = c.DateTime(nullable: false),
                    IsPaid = c.Boolean(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    AppUserId = c.Int(nullable: false),
                    SubscriptionPlanId = c.Int(nullable: false),
                    AppUser_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.SubscriptionPlans", t => t.SubscriptionPlanId, cascadeDelete: true)
                .Index(t => t.SubscriptionPlanId)
                .Index(t => t.AppUser_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "SubscriptionPlanId", "dbo.SubscriptionPlans");
            DropForeignKey("dbo.Subscriptions", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subscriptions", new[] { "AppUser_Id" });
            DropIndex("dbo.Subscriptions", new[] { "SubscriptionPlanId" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.SubscriptionPlans");
        }
    }
}
