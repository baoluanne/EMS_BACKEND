using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class HoSoSVConfiguration : IEntityTypeConfiguration<HoSoSV>
    {
        public void Configure(EntityTypeBuilder<HoSoSV> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaHoSo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenHoSo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique index for MaHoSo
            builder.HasIndex(x => x.MaHoSo)
                .IsUnique();
        }
    }
}