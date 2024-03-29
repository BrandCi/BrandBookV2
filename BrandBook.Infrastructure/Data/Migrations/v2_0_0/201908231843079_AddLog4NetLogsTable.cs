namespace BrandBook.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddLog4NetLogsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log4NetLog",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Thread = c.String(),
                    Level = c.String(),
                    Logger = c.String(),
                    Message = c.String(),
                    Exception = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Log4NetLog");
        }
    }
}
