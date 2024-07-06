using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class CompanyAddressMapping : IEntityTypeConfiguration<CompanyAddress>
{
    public void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        builder.ToTable("CompanyAddresses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ZipCode)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(9);
        builder.Property(x => x.State)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(48);
        builder.Property(x => x.City)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(32);
        builder.Property(x => x.District)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(2);
        builder.Property(x => x.StreetName)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        builder.Property(x => x.Number)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(5);
        builder.Property(x => x.Complement)
            .IsRequired(false)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(64);
        
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