namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateAllInitialColorRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CmykValues",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    C = c.Int(nullable: false),
                    M = c.Int(nullable: false),
                    Y = c.Int(nullable: false),
                    K = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Colors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    CmykValue_Id = c.Int(),
                    RgbValue_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CmykValues", t => t.CmykValue_Id)
                .ForeignKey("dbo.RgbValues", t => t.RgbValue_Id)
                .Index(t => t.CmykValue_Id)
                .Index(t => t.RgbValue_Id);

            CreateTable(
                "dbo.RgbValues",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    R = c.Int(nullable: false),
                    G = c.Int(nullable: false),
                    B = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Colors", "RgbValue_Id", "dbo.RgbValues");
            DropForeignKey("dbo.Colors", "CmykValue_Id", "dbo.CmykValues");
            DropIndex("dbo.Colors", new[] { "RgbValue_Id" });
            DropIndex("dbo.Colors", new[] { "CmykValue_Id" });
            DropTable("dbo.RgbValues");
            DropTable("dbo.Colors");
            DropTable("dbo.CmykValues");
        }
    }
}
