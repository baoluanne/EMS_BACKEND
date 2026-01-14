using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxToaNhaConfiguration : IEntityTypeConfiguration<KTXToaNha>
    {
        public void Configure(EntityTypeBuilder<KTXToaNha> builder)
        {
            builder.ToTable("KtxToaNha");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenToaNha)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(x => x.TenToaNha)
                .IsUnique();

            builder.Property(x => x.LoaiToaNha)
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasMany(x => x.KtxTangs)
                .WithOne(t => t.ToaNha)
                .HasForeignKey(t => t.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}