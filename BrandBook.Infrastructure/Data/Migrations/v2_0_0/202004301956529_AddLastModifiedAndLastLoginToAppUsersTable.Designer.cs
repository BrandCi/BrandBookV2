// <auto-generated />
namespace BrandBook.Infrastructure.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddLastModifiedAndLastLoginToAppUsersTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddLastModifiedAndLastLoginToAppUsersTable));
        
        string IMigrationMetadata.Id
        {
            get { return "202004301956529_AddLastModifiedAndLastLoginToAppUsersTable"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
