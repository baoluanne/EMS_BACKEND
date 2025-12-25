using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucKhoanThuHocPhiConfiguration : IEntityTypeConfiguration<DanhMucKhoanThuHocPhi>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoanThuHocPhi> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaKhoanThu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhoanThu)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);

            builder.Property(x => x.CapSoHoaDonDienTu)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaKhoanThu
            builder.HasIndex(x => x.MaKhoanThu);
        }
    }
}
