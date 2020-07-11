namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateBlogEntriesAndAddBlogImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ContentType = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.BlogEntries", "AdditionalStyles", c => c.String());
            AddColumn("dbo.BlogEntries", "BlogImageId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogEntries", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogEntries", "AppUser_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogEntries", "BlogImageId");
            CreateIndex("dbo.BlogEntries", "AppUser_Id");
            AddForeignKey("dbo.BlogEntries", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BlogEntries", "BlogImageId", "dbo.BlogImages", "Id", cascadeDelete: true);
            DropColumn("dbo.BlogEntries", "Image");
        }

        public override void Down()
        {
            AddColumn("dbo.BlogEntries", "Image", c => c.String());
            DropForeignKey("dbo.BlogEntries", "BlogImageId", "dbo.BlogImages");
            DropForeignKey("dbo.BlogEntries", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogEntries", new[] { "AppUser_Id" });
            DropIndex("dbo.BlogEntries", new[] { "BlogImageId" });
            DropColumn("dbo.BlogEntries", "AppUser_Id");
            DropColumn("dbo.BlogEntries", "AppUserId");
            DropColumn("dbo.BlogEntries", "BlogImageId");
            DropColumn("dbo.BlogEntries", "AdditionalStyles");
            DropTable("dbo.BlogImages");
        }
    }
}
