using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyChe_NienCheConfiguration : IEntityTypeConfiguration<QuyChe_NienChe>
    {
        public void Configure(EntityTypeBuilder<QuyChe_NienChe> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyCheHocVu)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheHocVu)
                .IsRequired();

            // Decimal fields with precision and scale
            builder.Property(x => x.HeSoDiemLT).HasPrecision(5, 2);
            builder.Property(x => x.HeSoDiemTH).HasPrecision(5, 2);
            builder.Property(x => x.CotDiemKTTK).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBMon).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemThiTotNghiep).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBTK).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBHK).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBTN).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemKTMon).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemTBChung).HasPrecision(5, 2);
            builder.Property(x => x.DDDS_DiemToanKhoa).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_DTBThuongKy).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTTongVang).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTLyThuyet).HasPrecision(5, 2);
            builder.Property(x => x.DKDT_PTThucHanh).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemThoiHocMoiHK).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_SoDVHTKhongDatHK).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemTLNam2).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_SoDVHTKhongDatN2).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_DiemTLNam3).HasPrecision(5, 2);
            builder.Property(x => x.DKTH_SoDVHTKhongDatN3).HasPrecision(5, 2);
            builder.Property(x => x.HB_DiemTB).HasPrecision(5, 2);
            builder.Property(x => x.HB_DiemHK).HasPrecision(5, 2);
            builder.Property(x => x.HB_DiemTBToiThieu).HasPrecision(5, 2);
            builder.Property(x => x.DH_DiemTB).HasPrecision(5, 2);
            builder.Property(x => x.DH_DiemHanhKiem).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_DTBHocKy).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_SoDVHTKhongDatHK).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_DTBNam).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_SoDVHTKhongDatN).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_DiemTichLuyN2).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_SoDVHTKhongDatN2).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_DiemTichLuyN3).HasPrecision(5, 2);
            builder.Property(x => x.DKHT_SoDVHTKhongDatN3).HasPrecision(5, 2);
        }
    }
}
