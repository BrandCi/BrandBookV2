namespace BrandCi.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPublishDateToBlogEntriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogEntries", "PublishDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.BlogEntries", "PublishDate");
        }
    }
}
