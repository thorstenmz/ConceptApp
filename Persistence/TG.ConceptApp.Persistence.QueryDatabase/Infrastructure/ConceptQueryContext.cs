using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TG.ConceptApp.Application.QueryModel.Entities;

namespace TG.ConceptApp.Persistence.QueryDatabase.Infrastructure
{
    public class ConceptQueryContext : DbContext
    {
        public ConceptQueryContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #pragma warning disable RCS1170 // Use read-only auto-implemented property.
        public DbSet<ReadonlyConcept> ReadonlyConcepts { get; private set; }
        #pragma warning restore RCS1170 // Setter needed for EF Core.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Skeleton;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new ConceptQueryConfig());

        internal async Task TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=Skeleton;Trusted_Connection=True;"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                await conn.OpenAsync();
                comm.CommandText = "select * from [dbo].[ReadonlyConcepts]";
                SqlDataReader reader = await comm.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    string super = reader.GetString(1);
                    string sub = reader.GetString(2);
                }
            }
        }
    }

    public static class DbContextExtensions
    {
        /// <summary>
        /// This will wipe and create a new database - which takes some time
        /// </summary>
        /// <param name="onlyIfNoDatabase">If true it will not do anything if the database exists</param>
        /// <returns>returns true if database database was created</returns>
        public static bool WipeCreateSeed(bool onlyIfNoDatabase)
        {
            using (var db = new ConceptQueryContext())
            {
                if (onlyIfNoDatabase && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if (!db.ReadonlyConcepts.Any())
                {
                    WriteTestData(db);
                }
            }
            return true;
        }

        public static void WriteTestData(this ConceptQueryContext db)
        {
            //ReadonlyConcept[] concepts = new[]
            //{
            //    new ReadonlyConcept
            //    {
            //        Id = 0,
            //        Super = "color",
            //        Sub = "red"
            //    },
            //    new ReadonlyConcept
            //    {
            //        Id = 1,
            //        Super = "color",
            //        Sub = "blue"
            //    }
            //};

            //db.ReadonlyConcepts.AddRange(concepts);
            //db.SaveChanges();
        }
    }
}
