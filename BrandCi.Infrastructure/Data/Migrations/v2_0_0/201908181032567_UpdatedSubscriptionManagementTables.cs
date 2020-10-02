namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatedSubscriptionManagementTables : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Subscriptions", new[] { "AppUser_Id" });
            DropColumn("dbo.Subscriptions", "AppUserId");
            RenameColumn(table: "dbo.Subscriptions", name: "AppUser_Id", newName: "AppUserId");
            AddColumn("dbo.SubscriptionPlans", "PricePerMonth", c => c.Double(nullable: false));
            AlterColumn("dbo.Subscriptions", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "AppUserId");

            Sql("UPDATE dbo.SubscriptionPlans SET PricePerMonth = Price;");

            DropColumn("dbo.SubscriptionPlans", "Price");
        }

        public override void Down()
        {
            AddColumn("dbo.SubscriptionPlans", "Price", c => c.Double(nullable: false));
            DropIndex("dbo.Subscriptions", new[] { "AppUserId" });
            AlterColumn("dbo.Subscriptions", "AppUserId", c => c.Int(nullable: false));
            DropColumn("dbo.SubscriptionPlans", "PricePerMonth");
            RenameColumn(table: "dbo.Subscriptions", name: "AppUserId", newName: "AppUser_Id");
            AddColumn("dbo.Subscriptions", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "AppUser_Id");
        }
    }
}
