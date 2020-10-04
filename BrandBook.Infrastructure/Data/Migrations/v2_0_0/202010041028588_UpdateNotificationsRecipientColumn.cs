namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotificationsRecipientColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Recipient", c => c.String());
            DropColumn("dbo.Notifications", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "EmailAddress", c => c.String());
            DropColumn("dbo.Notifications", "Recipient");
        }
    }
}
