using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class StudentMapping : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        builder.Property(x => x.Ssn)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(14);
        builder.Property(x => x.Ic)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(32);
        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        builder.Property(x => x.Telephone)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(16);
        builder.Property(x => x.Signature)
            .IsRequired(false)
            .HasColumnType("VARBINARY(MAX)");
        
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