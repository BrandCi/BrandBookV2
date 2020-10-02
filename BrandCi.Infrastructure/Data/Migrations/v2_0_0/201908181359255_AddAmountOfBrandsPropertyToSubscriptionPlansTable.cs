namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAmountOfBrandsPropertyToSubscriptionPlansTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubscriptionPlans", "AmountOfBrands", c => c.Int(nullable: false));

            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 1 WHERE Id = 1;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 1 WHERE Id = 2;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 2 WHERE Id = 3;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 2 WHERE Id = 4;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 999 WHERE Id = 5;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 999 WHERE Id = 6;");
            Sql("UPDATE dbo.SubscriptionPlans SET AmountOfBrands = 1 WHERE Id = 7;");



        }

        public override void Down()
        {
            DropColumn("dbo.SubscriptionPlans", "AmountOfBrands");
        }
    }
}
