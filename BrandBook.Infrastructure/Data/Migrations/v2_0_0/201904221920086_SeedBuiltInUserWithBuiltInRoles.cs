namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBuiltInUserWithBuiltInRoles : DbMigration
    {
        public override void Up()
        {
            // Create Built In Roles
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'4f46d978-9b05-4d97-83ad-71b4cde6ec40', N'AppUser', N'IdentityRole')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'2abda22b-00ac-4e03-b878-49631a42c4c2', N'Administrator', N'IdentityRole')");

            // Create Built In Admin
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d370030-c2c5-4196-a9e2-c423398630e3', N'admin@philipp-moser.de', 0, N'AM7nSZ7TF/bFXQhY/IZmOsMtu8FNC+tuSM4OPlxFOe3/IXdXset6WzypvKaSnP+Ccg==', N'ff18fe92-184f-4300-937c-13bcd6c5e71e', NULL, 0, 0, NULL, 1, 0, N'admin')");

            // Assign Built In Roles to Built In Admin
            Sql("INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'2d370030-c2c5-4196-a9e2-c423398630e3', N'4f46d978-9b05-4d97-83ad-71b4cde6ec40')");
            Sql("INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'2d370030-c2c5-4196-a9e2-c423398630e3', N'2abda22b-00ac-4e03-b878-49631a42c4c2')");
            
        }

    public override void Down()
        {
        }
    }
}
