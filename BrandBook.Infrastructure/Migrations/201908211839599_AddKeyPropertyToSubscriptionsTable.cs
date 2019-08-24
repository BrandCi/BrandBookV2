namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyPropertyToSubscriptionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Key", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "Key");
        }
    }
}
