using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class PhoneMapping : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Phones");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(16);
        
        builder.HasOne(s => s.Client)
            .WithMany(c => c.Telephones)
            .HasForeignKey(s => s.ClientId);
        
        builder.HasOne(s => s.Company)
            .WithMany(c => c.Telephones)
            .HasForeignKey(s => s.CompanyId);
        
        builder.Property(x => x.ClientId)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(32);
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