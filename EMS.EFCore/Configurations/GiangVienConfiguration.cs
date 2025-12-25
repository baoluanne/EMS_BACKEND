using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class GiangVienConfiguration : IEntityTypeConfiguration<GiangVien>
    {
        public void Configure(EntityTypeBuilder<GiangVien> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaGiangVien).IsRequired().HasMaxLength(50);
            builder.Property(x => x.HoDem).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NgaySinh);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.DiaChi).HasMaxLength(200);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.IdLoaiGiangVien).IsRequired();
            builder.Property(x => x.IdKhoa).IsRequired();
            builder.Property(x => x.IdHocVi);
            builder.Property(x => x.IDToBoMon);
            builder.Property(x => x.TenVietTat).HasMaxLength(20);
            builder.Property(x => x.HSGV_LT).HasPrecision(18,2);
            builder.Property(x => x.HSGV_TH).HasPrecision(18,2);
            builder.Property(x => x.PhuongTien).HasMaxLength(100);
            builder.Property(x => x.NgayChamDutHopDong);
            builder.Property(x => x.IsCoiThi);
            builder.Property(x => x.IsVisible);
            builder.Property(x => x.IsKhongChamCong);
            builder.Property(x => x.IsChamDutHopDong);

            builder.HasOne(x => x.LoaiGiangVien)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiGiangVien);

            builder.HasOne(x => x.Khoa)
                .WithMany()
                .HasForeignKey(x => x.IdKhoa);

            builder.HasOne(x => x.HocVi)
                .WithMany()
                .HasForeignKey(x => x.IdHocVi);

            builder.HasOne(x => x.ToBoMon)
                .WithMany()
                .HasForeignKey(x => x.IDToBoMon);
        }
    }
} 