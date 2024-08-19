using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;

namespace Sigetre.Api.Data.Mappings;

public class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        builder.Property(x => x.Ein)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(32);
        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        
        builder.HasOne(e => e.Address)
            .WithOne(a => a.Company)
            .HasForeignKey<Address>(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Telephones)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
        
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