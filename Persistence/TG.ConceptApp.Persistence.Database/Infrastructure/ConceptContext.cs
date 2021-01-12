using Microsoft.EntityFrameworkCore;
using TG.ConceptApp.Domain.Concept.Entities;

namespace TG.ConceptApp.Persistence.Database.Infrastructure
{
    public class ConceptContext : SoftDeleteContextBase<Concept>
    {
        #pragma warning disable RCS1170 // Use read-only auto-implemented property.
        public DbSet<Concept> Concepts { get; private set; }
        #pragma warning restore RCS1170 // Setter needed for EF Core.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Skeleton;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new ConceptConfig());
    }
}
