using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KieuLamTronConfiguration : IEntityTypeConfiguration<KieuLamTron>
    {
        public void Configure(EntityTypeBuilder<KieuLamTron> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaKieuLamTron)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKieuLamTron)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
} 