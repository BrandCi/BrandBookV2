namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBlogEntriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogEntries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UrlKey = c.String(),
                    Title = c.String(),
                    SubTitle = c.String(),
                    Image = c.String(),
                    Content = c.String(),
                    Author = c.String(),
                    CreationDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.BlogEntries");
        }
    }
}
