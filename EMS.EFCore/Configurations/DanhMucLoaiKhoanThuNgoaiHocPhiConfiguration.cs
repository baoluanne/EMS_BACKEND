using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucLoaiKhoanThuNgoaiHocPhiConfiguration : IEntityTypeConfiguration<DanhMucLoaiKhoanThuNgoaiHocPhi>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiKhoanThuNgoaiHocPhi> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaLoaiKhoanThu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiKhoanThu)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);

            builder.Property(x => x.XuatHoaDonDienTu)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.HinhThucThu);

            builder.Property(x => x.PhanBoDoanThu)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.MaTKNganHang)
                .HasMaxLength(50);

            // Unique constraint for MaLoaiKhoanThu
            builder.HasIndex(x => x.MaLoaiKhoanThu);
        }
    }
}
