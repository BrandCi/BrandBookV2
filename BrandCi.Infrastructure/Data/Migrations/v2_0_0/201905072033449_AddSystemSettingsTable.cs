namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSystemSettingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Key = c.String(),
                    Value = c.String(),
                    Category = c.Int(nullable: false),
                    AccessLevel = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
