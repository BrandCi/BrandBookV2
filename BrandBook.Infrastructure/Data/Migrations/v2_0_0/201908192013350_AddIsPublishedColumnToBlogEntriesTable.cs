namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddIsPublishedColumnToBlogEntriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogEntries", "IsPublished", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.BlogEntries", "IsPublished");
        }
    }
}
