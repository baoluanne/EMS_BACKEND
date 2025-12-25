using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyChe_TinChiConfiguration : IEntityTypeConfiguration<QuyChe_TinChi>
    {
        public void Configure(EntityTypeBuilder<QuyChe_TinChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyCheHocVu)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheHocVu)
                .IsRequired();

            builder.HasOne(x => x.DKTH_MucDoVP)
                .WithMany()
                .HasForeignKey(x => x.DKTH_IdMucDoVP);

            builder.HasOne(x => x.HBXL_MucDoVPKL)
                .WithMany()
                .HasForeignKey(x => x.HBXL_IdMucDoVPKL);

            builder.HasOne(x => x.HBXL_MucDoVPQC)
                .WithMany()
                .HasForeignKey(x => x.HBXL_IdMucDoVPQC);

            // Decimal fields with precision and scale
            builder.Property(x => x.HeSoDiemLT).HasPrecision(5, 2);
            builder.Property(x => x.HeSoDiemTH).HasPrecision(5, 2);
            builder.Property(x => x.SoCotDiemKTTK).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBMon).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBChung).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTKMon).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBHK).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_DiemTBThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_DiemTBThuongXuyen).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_DiemGiuaKy).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_DiemTieuLuan).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTTongVang).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTLyThuyet).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTThucHanh).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemThoiHocMoiHK).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_SoHKCanhBaoMax).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemHKDau).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemHKLienTiep).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_HKLienTiep).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemHKTiepTheo).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_XetTamNgungTu).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_XetTamNgungDen).HasPrecision(5, 2);
            builder.Property(x => x.HBXL_DiemHaBacTu).HasPrecision(5, 2);
            builder.Property(x => x.DH_DiemTB).HasPrecision(5, 2);
            builder.Property(x => x.DH_DiemHK).HasPrecision(5, 2);
            builder.Property(x => x.HB_DiemTrungBinh).HasPrecision(5, 2);
            builder.Property(x => x.HB_DiemTBToiThieu).HasPrecision(5, 2);
            builder.Property(x => x.HB_SoTCDangKy).HasPrecision(5, 2);
            builder.Property(x => x.HB_SoTCDKNam).HasPrecision(5, 2);
        }
    }
}
