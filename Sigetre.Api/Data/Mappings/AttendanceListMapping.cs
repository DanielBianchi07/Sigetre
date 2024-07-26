using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class AttendanceListMapping : IEntityTypeConfiguration<AttendanceList>
{
    public void Configure(EntityTypeBuilder<AttendanceList> builder)
    {
        builder.ToTable("AttendanceLists");
        
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
        builder.Property(x => x.CreatedBy)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        builder.Property(x => x.UpdatedBy)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);;
    }
}