using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

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
        builder.Property(x => x.Neighborhood)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(48);
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

        builder.Property(x => x.ClientId)
            .IsRequired(false)
            .HasColumnType("BIGINT");
        builder.Property(x => x.CompanyId)
            .IsRequired(false)
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.Status)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        builder.Property(x => x.CreatedBy)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        builder.Property(x => x.UpdatedBy)
            .IsRequired(false)
            .HasColumnType("BIGINT");
    }
}