using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucHoSoHSSVConfiguration : IEntityTypeConfiguration<DanhMucHoSoHSSV>
    {
        public void Configure(EntityTypeBuilder<DanhMucHoSoHSSV> builder)
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

            builder.Property(x => x.STT);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaHoSo
            builder.HasIndex(x => x.MaHoSo);
        }
    }
}
