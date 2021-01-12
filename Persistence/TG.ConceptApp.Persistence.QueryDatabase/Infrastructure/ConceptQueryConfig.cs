using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG.ConceptApp.Application.QueryModel.Entities;

namespace TG.ConceptApp.Persistence.QueryDatabase.Infrastructure
{
    internal class ConceptQueryConfig : IEntityTypeConfiguration<ReadonlyConcept>
    {
        public void Configure(EntityTypeBuilder<ReadonlyConcept> builder)
        {
            builder.ToTable("ReadonlyConcepts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Super).HasColumnName("Super").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Sub).HasColumnName("Sub").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();

            //builder.Property(p => p.Super).IsRequired();

            //builder.Property(x => x.Sub).IsRequired();

            builder.HasIndex(x => new { x.Super, x.Sub });
        }
    }
}
