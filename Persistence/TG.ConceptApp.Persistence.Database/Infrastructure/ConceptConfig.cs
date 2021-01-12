using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG.ConceptApp.Domain.Concept.Entities;

namespace TG.ConceptApp.Persistence.Database.Infrastructure
{
    internal class ConceptConfig : IEntityTypeConfiguration<Concept>
    {
        public void Configure(EntityTypeBuilder<Concept> builder)
        {
            builder.ToTable("Concepts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Super).HasColumnName("Super").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Sub).HasColumnName("Sub").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();

            builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted").HasColumnType("bit").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetimeoffset").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.UpdatedOn).HasColumnName("UpdatedOn").HasColumnType("datetimeoffset");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("nvarchar").HasMaxLength(256);

            builder.HasIndex(x => new { x.Super, x.Sub });
        }
    }
}
