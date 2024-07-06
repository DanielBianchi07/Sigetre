using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class CertificateMapping : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable("Certificates");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(64);
        builder.Property(x => x.Watermark)
            .IsRequired(false)
            .HasColumnType("VARBINARY(MAX)");
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