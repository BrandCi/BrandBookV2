namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixIssueWithAppUserIdDatatypeInBlogEntriesTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BlogEntries", new[] { "AppUser_Id" });
            DropColumn("dbo.BlogEntries", "AppUserId");
            RenameColumn(table: "dbo.BlogEntries", name: "AppUser_Id", newName: "AppUserId");
            AlterColumn("dbo.BlogEntries", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogEntries", "AppUserId");
        }

        public override void Down()
        {
            DropIndex("dbo.BlogEntries", new[] { "AppUserId" });
            AlterColumn("dbo.BlogEntries", "AppUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.BlogEntries", name: "AppUserId", newName: "AppUser_Id");
            AddColumn("dbo.BlogEntries", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogEntries", "AppUser_Id");
        }
    }
}
