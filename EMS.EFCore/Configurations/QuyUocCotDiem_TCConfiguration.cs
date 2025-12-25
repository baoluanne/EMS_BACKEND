using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyUocCotDiem_TCConfiguration : IEntityTypeConfiguration<QuyUocCotDiem_TC>
    {
        public void Configure(EntityTypeBuilder<QuyUocCotDiem_TC> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyChe_TinChi)
                .WithMany()
                .HasForeignKey(x => x.IdQuyChe_TinChi)
                .IsRequired();

            builder.HasOne(x => x.KieuMon)
                .WithMany()
                .HasForeignKey(x => x.IdKieuMon)
                .IsRequired();

            builder.HasOne(x => x.KieuLamTron)
                .WithMany()
                .HasForeignKey(x => x.IdKieuLamTron)
                .IsRequired(false);

            // Properties
            builder.Property(x => x.TenQuyUoc)
                .IsRequired()
                .HasMaxLength(100);

            // Boolean properties
            builder.Property(x => x.IsKhongTinhTBC);
            builder.Property(x => x.IsChiDiemCuoiKy);
            builder.Property(x => x.IsChiDanhGia);
            builder.Property(x => x.IsXetDuThiGiuaKy);
            builder.Property(x => x.IsSuDung);
            builder.Property(x => x.IsHSLTTH_TC);
            builder.Property(x => x.IsDiemRangBuocCK);

            // Decimal properties with precision
            builder.Property(x => x.DiemTBC).HasPrecision(5, 2);
            builder.Property(x => x.ChuyenCan).HasPrecision(5, 2);
            builder.Property(x => x.ThuongXuyen1).HasPrecision(5, 2);
            builder.Property(x => x.ThuongXuyen2).HasPrecision(5, 2);
            builder.Property(x => x.ThuongXuyen3).HasPrecision(5, 2);
            builder.Property(x => x.ThuongXuyen4).HasPrecision(5, 2);
            builder.Property(x => x.ThuongXuyen5).HasPrecision(5, 2);
            builder.Property(x => x.TieuLuan_BTL).HasPrecision(5, 2);
            builder.Property(x => x.CuoiKy).HasPrecision(5, 2);
            builder.Property(x => x.HeSoTH).HasPrecision(5, 2);
            builder.Property(x => x.HeSoLT).HasPrecision(5, 2);
            builder.Property(x => x.DiemRangBuocCK).HasPrecision(5, 2);
            builder.Property(x => x.DRB_CotDiemGK).HasPrecision(5, 2);
            builder.Property(x => x.DRB_CotDiemCC).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemGiuaKy).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemChuyenCan).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemTieuLuan).HasPrecision(5, 2);
            builder.Property(x => x.DRB_ThangDiemMax).HasPrecision(5, 2);

            // Integer properties
            builder.Property(x => x.SoCotDiemTH);

            // String properties
            builder.Property(x => x.DRB_CongThucTinhDTB_TK)
                .HasMaxLength(500);

            builder.Property(x => x.DRB_GhiChu)
                .HasMaxLength(300);
        }
    }
} 