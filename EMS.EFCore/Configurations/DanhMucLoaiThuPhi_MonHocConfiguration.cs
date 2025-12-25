using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucLoaiThuPhi_MonHocConfiguration : IEntityTypeConfiguration<DanhMucLoaiThuPhi_MonHoc>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiThuPhi_MonHoc> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaLoaiThuPhi)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiThuPhi)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);

            builder.Property(x => x.CapSoHoaDonDienTu);

            builder.Property(x => x.CongThucQuyDoi)
                .HasMaxLength(500);

            builder.Property(x => x.MaTKNganHang)
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaLoaiThuPhi
            builder.HasIndex(x => x.MaLoaiThuPhi);
        }
    }
}
