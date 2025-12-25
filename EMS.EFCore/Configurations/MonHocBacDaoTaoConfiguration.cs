using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class MonHocBacDaoTaoConfiguration : IEntityTypeConfiguration<MonHocBacDaoTao>
    {
        public void Configure(EntityTypeBuilder<MonHocBacDaoTao> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.MonHoc)
                .WithMany(x => x.MonHocBacDaoTaos)
                .HasForeignKey(x => x.IdMonHoc);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao);

            builder.HasOne(x => x.HinhThucThi)
                .WithMany()
                .HasForeignKey(x => x.IdHinhThucThi);

            builder.HasOne(x => x.LoaiHinhGiangDay)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiHinhGiangDay);

            builder.HasOne(x => x.LoaiTiet)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiTiet);

            builder.HasOne(x => x.QuyUocCotDiem_NC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyUocCotDiem_NC)
                .IsRequired(false);

            builder.HasOne(x => x.QuyUocCotDiem_TC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyUocCotDiem_TC)
                .IsRequired(false);

            // Decimal properties with precision
            builder.Property(x => x.DVHT_TC)
                .HasPrecision(5, 2);

            builder.Property(x => x.DVHT_HP)
                .HasPrecision(5, 2);

            builder.Property(x => x.DVHT_Le)
                .HasPrecision(5, 2);

            // Integer properties
            builder.Property(x => x.SoTinChi);
            builder.Property(x => x.SoTietLyThuyet);
            builder.Property(x => x.SoTietThucHanh);
            builder.Property(x => x.TuHoc);
            builder.Property(x => x.SoLanKTDinhKy);
            builder.Property(x => x.ThucHanh);
            builder.Property(x => x.LyThuyet);
            builder.Property(x => x.MoRong);
            builder.Property(x => x.SoTietLTT);
            builder.Property(x => x.SoTietTHBT);
            builder.Property(x => x.SoTietTuHoc);
            builder.Property(x => x.SoGioThucTap);
            builder.Property(x => x.SoGioDoAnBTLon);
            builder.Property(x => x.SoTietKT);

            // Boolean properties
            builder.Property(x => x.IsLyThuyet);
            builder.Property(x => x.IsKhongTinhDiemTBC);

            // String properties
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}