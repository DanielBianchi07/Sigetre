using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class CourseMapping : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        builder.Property(x => x.InitialWorkload)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.PeriodicWorkload)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.Validity)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.Logo)
            .IsRequired(false)
            .HasColumnType("VARBINARY(MAX)");
        builder.Property(x => x.SpecializationId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.Status)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.CreatedBy)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        builder.Property(x => x.UpdatedBy)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        builder.Property(x => x.User)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
    }
}