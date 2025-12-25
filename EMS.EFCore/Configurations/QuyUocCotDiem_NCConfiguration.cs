using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyUocCotDiem_NCConfiguration : IEntityTypeConfiguration<QuyUocCotDiem_NC>
    {
        public void Configure(EntityTypeBuilder<QuyUocCotDiem_NC> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyChe_NienChe)
                .WithMany()
                .HasForeignKey(x => x.IdQuyChe_NienChe)
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
            builder.Property(x => x.IsSuDung);
            builder.Property(x => x.HeSoTheoDVHT);
            builder.Property(x => x.HeSoTheoLTTH_TC);
            builder.Property(x => x.IsApDungQuyCheNghe);
            builder.Property(x => x.IsApDungQuyCheMonVH);
            builder.Property(x => x.IsRangBuocDCK);
            builder.Property(x => x.IsXetDuThiGK);
            builder.Property(x => x.IsKhongApDungHSCD);

            // Decimal properties with precision
            builder.Property(x => x.DiemTBC).HasPrecision(5, 2);
            builder.Property(x => x.ChuyenCan).HasPrecision(5, 2);
            builder.Property(x => x.HeSoTBTK).HasPrecision(5, 2);
            builder.Property(x => x.HeSoCK).HasPrecision(5, 2);
            builder.Property(x => x.HeSoLT).HasPrecision(5, 2);
            builder.Property(x => x.HeSoTH).HasPrecision(5, 2);
            builder.Property(x => x.DiemRangBuocCK).HasPrecision(5, 2);
            builder.Property(x => x.DRB_CotDiemGK).HasPrecision(5, 2);
            builder.Property(x => x.DRB_CotDiemCC).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemGiuaKy).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemChuyenCan).HasPrecision(5, 2);
            builder.Property(x => x.DRB_DiemTieuLuan).HasPrecision(5, 2);
            builder.Property(x => x.DRB_ThangDiemMax).HasPrecision(5, 2);

            // Integer properties
            builder.Property(x => x.SoCotChuyenCan);
            builder.Property(x => x.SoCotThucHanh);
            builder.Property(x => x.SoCotLTHS1);
            builder.Property(x => x.SoCotLTHS2);
            builder.Property(x => x.SoCotLTHS3);
            builder.Property(x => x.SoCotTHHS1);
            builder.Property(x => x.SoCotTHHS2);
            builder.Property(x => x.SoCotTHHS3);
            builder.Property(x => x.SoCotDiemGK);
            builder.Property(x => x.SoCotDiemCC);

            // String properties
            builder.Property(x => x.DRB_CongThucTinhDTB_TK)
                .HasMaxLength(500);

            builder.Property(x => x.DRB_GhiChu)
                .HasMaxLength(300);
        }
    }
} 