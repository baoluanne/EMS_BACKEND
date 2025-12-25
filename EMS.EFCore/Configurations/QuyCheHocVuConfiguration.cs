using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyCheHocVuConfiguration : IEntityTypeConfiguration<QuyCheHocVu>
    {
        public void Configure(EntityTypeBuilder<QuyCheHocVu> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            // Properties
            builder.Property(x => x.MaQuyChe)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.TenQuyChe)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.BieuThuc)
                .HasMaxLength(500);

            builder.Property(x => x.IsNienChe)
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Decimal fields with precision and scale
            builder.Property(x => x.DKDT_DiemTBTK)
                .HasPrecision(5, 2);

            builder.Property(x => x.DKDT_DiemTBTH)
                .HasPrecision(5, 2);

            builder.Property(x => x.DKDT_TongTietVang)
                .HasPrecision(5, 2);

            builder.Property(x => x.DKDT_LyThuyet)
                .HasPrecision(5, 2);

            builder.Property(x => x.DKDT_ThucHanh)
                .HasPrecision(5, 2);

            builder.Property(x => x.DKDT_DuocThiLai)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemThanhPhan)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemCuoiKy)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTBThuongKy)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTBTH)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTB)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTBHK)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTN)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_DiemTK)
                .HasPrecision(5, 2);

            builder.Property(x => x.DDDS_KieuLamTron)
                .HasMaxLength(50);
        }
    }
}
