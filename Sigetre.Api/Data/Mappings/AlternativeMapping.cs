using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class AlternativeMapping : IEntityTypeConfiguration<Alternative>
{
    public void Configure(EntityTypeBuilder<Alternative> builder)
    {
        builder.ToTable("Alternatives");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);
        builder.Property(x => x.Answer)
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