namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationTemplateType = c.Int(nullable: false),
                        Subject = c.String(),
                        CreationDate = c.String(),
                        EmailAddress = c.String(),
                        RequestIp = c.String(),
                        EmailContent = c.String(),
                        IsSpam = c.Boolean(nullable: false),
                        IsSent = c.Boolean(nullable: false),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
