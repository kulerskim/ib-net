// <auto-generated />
namespace ib_dotnet.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class RemoveForeignKeyAnnotation : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemoveForeignKeyAnnotation));
        
        string IMigrationMetadata.Id
        {
            get { return "201306111336191_RemoveForeignKeyAnnotation"; }
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