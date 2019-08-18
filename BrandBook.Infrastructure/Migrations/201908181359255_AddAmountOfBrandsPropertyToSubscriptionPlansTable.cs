namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountOfBrandsPropertyToSubscriptionPlansTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubscriptionPlans", "AmountOfBrands", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubscriptionPlans", "AmountOfBrands");
        }
    }
}
