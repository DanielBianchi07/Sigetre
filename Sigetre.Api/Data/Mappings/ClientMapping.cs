using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Api.Models;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;

namespace Sigetre.Api.Data.Mappings;

public class ClientMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        builder.Property(x => x.Ein)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(32)
            .IsRequired();
        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.HasOne(e => e.Address)
            .WithOne(a => a.Client)
            .HasForeignKey<Address>(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Telephones)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);
        
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
            .HasMaxLength(160);;
    }
}