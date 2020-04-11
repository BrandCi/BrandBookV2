namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAppIdentityTablesPrimaryKeyFromCharToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogEntries", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscriptions", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoleRolePermissions", "UserRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.BlogEntries", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Subscriptions", new[] { "AppUserId" });
            DropIndex("dbo.UserRoleRolePermissions", new[] { "UserRole_Id" });
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.UserRoleRolePermissions");
            AddColumn("dbo.BlogEntries", "AppUser_Id", c => c.Int());
            AlterColumn("dbo.BlogEntries", "AppUserId", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Subscriptions", "AppUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRoleRolePermissions", "UserRole_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.UserRoleRolePermissions", new[] { "UserRole_Id", "RolePermission_Id" });
            CreateIndex("dbo.BlogEntries", "AppUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.Subscriptions", "AppUserId");
            CreateIndex("dbo.UserRoleRolePermissions", "UserRole_Id");
            AddForeignKey("dbo.BlogEntries", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Subscriptions", "AppUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleRolePermissions", "UserRole_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserRoleRolePermissions", "UserRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscriptions", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BlogEntries", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoleRolePermissions", new[] { "UserRole_Id" });
            DropIndex("dbo.Subscriptions", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.BlogEntries", new[] { "AppUser_Id" });
            DropPrimaryKey("dbo.UserRoleRolePermissions");
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.UserRoleRolePermissions", "UserRole_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Subscriptions", "AppUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BlogEntries", "AppUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.BlogEntries", "AppUser_Id");
            AddPrimaryKey("dbo.UserRoleRolePermissions", new[] { "UserRole_Id", "RolePermission_Id" });
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.UserRoleRolePermissions", "UserRole_Id");
            CreateIndex("dbo.Subscriptions", "AppUserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.BlogEntries", "AppUserId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleRolePermissions", "UserRole_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Subscriptions", "AppUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BlogEntries", "AppUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
