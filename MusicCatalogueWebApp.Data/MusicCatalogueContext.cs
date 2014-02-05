using System;
using Microsoft.WindowsAzure;
using MusicCatalogueWebApp.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicCatalogueWebApp.Data
{
    public class MusicCatalogueContext : DbContext
    {
        public MusicCatalogueContext()
            : base("MusicCatalogueContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<AlbumArtist> AlbumArtist { get; set; }
        public DbSet<Recording> Recordings { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region DatabaseInitializer

        class DatabaseInitializer : IDatabaseInitializer<MusicCatalogueContext>
        {
            #region IDatabaseInitializer<MusicCatalogueContext> Members

            public void InitializeDatabase(MusicCatalogueContext context)
            {
                if (context == null) throw new ArgumentNullException("context");
                bool updateDbStructure;
                bool.TryParse(CloudConfigurationManager.GetSetting("UpdateDatabaseStructure"), out updateDbStructure);
                if (!updateDbStructure) return;

                //context.UpdateDatabaseStructure();
            }

            #endregion
        }

        #endregion
    }
}
