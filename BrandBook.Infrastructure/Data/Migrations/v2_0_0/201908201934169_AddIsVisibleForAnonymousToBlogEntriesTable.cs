namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddIsVisibleForAnonymousToBlogEntriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogEntries", "IsVisibleForAnonymous", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.BlogEntries", "IsVisibleForAnonymous");
        }
    }
}
