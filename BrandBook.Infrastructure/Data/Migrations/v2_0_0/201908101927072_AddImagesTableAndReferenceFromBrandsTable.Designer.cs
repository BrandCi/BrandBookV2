// <auto-generated />
namespace BrandBook.Infrastructure.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddImagesTableAndReferenceFromBrandsTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddImagesTableAndReferenceFromBrandsTable));
        
        string IMigrationMetadata.Id
        {
            get { return "201908101927072_AddImagesTableAndReferenceFromBrandsTable"; }
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
