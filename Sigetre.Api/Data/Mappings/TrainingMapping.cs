using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class TrainingMapping : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.ToTable("Trainings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.Situation)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        
        builder.Property(x => x.Status)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.ClientId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        builder.Property(x => x.CreateBy)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        builder.Property(x => x.UpdatedBy)
            .IsRequired(true)
            .HasColumnType("BIGINT");
    }
}