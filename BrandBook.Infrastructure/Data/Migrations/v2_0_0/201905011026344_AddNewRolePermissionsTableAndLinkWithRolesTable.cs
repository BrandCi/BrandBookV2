namespace BrandBook.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRolePermissionsTableAndLinkWithRolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleRolePermissions",
                c => new
                    {
                        UserRole_Id = c.Int(nullable: false),
                        RolePermission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_Id, t.RolePermission_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.UserRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.RolePermissions", t => t.RolePermission_Id, cascadeDelete: true)
                .Index(t => t.UserRole_Id)
                .Index(t => t.RolePermission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleRolePermissions", "RolePermission_Id", "dbo.RolePermissions");
            DropForeignKey("dbo.UserRoleRolePermissions", "UserRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.UserRoleRolePermissions", new[] { "RolePermission_Id" });
            DropIndex("dbo.UserRoleRolePermissions", new[] { "UserRole_Id" });
            DropTable("dbo.UserRoleRolePermissions");
            DropTable("dbo.RolePermissions");
        }
    }
}
