using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LopHocPhanConfiguration : IEntityTypeConfiguration<LopHocPhan>
    {
        public void Configure(EntityTypeBuilder<LopHocPhan> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // --- Required Relationships ---
            builder.HasOne(x => x.MonHoc)
                .WithMany()
                .HasForeignKey(x => x.IdMonHoc)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CoSo)
                .WithMany()
                .HasForeignKey(x => x.IdCoSo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.KhoaChuQuan)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaChuQuan)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoaiMonHoc)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiMonHoc)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HinhThucThi)
                .WithMany()
                .HasForeignKey(x => x.IdHinhThucThi)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GiangVien)
                .WithMany()
                .HasForeignKey(x => x.IdGiangVien)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Optional Relationships ---
            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Required Properties ---
            builder.Property(x => x.MaLopHocPhan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLopHocPhan)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MaHocPhan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TrangThai)
                .IsRequired()
                .HasDefaultValue(TrangThaiLopHocPhanEnum.MoLop);

            // --- Optional Properties ---
            builder.Property(x => x.LopBanDau)
                .HasMaxLength(100);

            builder.Property(x => x.SoLuongHienTai)
                .HasDefaultValue(0);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasMany(x => x.DangKyHocPhans)
                .WithOne(x => x.LopHocPhan)
                .HasForeignKey(x => x.IdLopHocPhan)
                .OnDelete(DeleteBehavior.Restrict);

            // Create a unique index on MaLopHocPhan
            builder.HasIndex(x => x.MaLopHocPhan)
                .IsUnique();

            builder.HasOne(x => x.ChuongTrinhKhungTinChi)
                .WithMany(x => x.LopHocPhans)
                .HasForeignKey(x => x.IdChuongTrinhKhungTinChi)
                .IsRequired(false);

            builder.Property(x => x.IsTuDongTao)
            .IsRequired(false)
            .HasDefaultValue(false);
        }
    }
}