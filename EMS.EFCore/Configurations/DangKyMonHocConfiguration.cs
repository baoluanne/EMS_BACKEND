using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DangKyMonHocConfiguration : IEntityTypeConfiguration<DangKyMonHoc>
    {
        public void Configure(EntityTypeBuilder<DangKyMonHoc> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaDangKy)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NgayDangKy)
                .IsRequired();

            builder.Property(x => x.TrangThai)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.NgayDuyet);

            builder.Property(x => x.LyDoDuyet)
                .HasMaxLength(500);

            builder.Property(x => x.SoTinChi)
                .IsRequired();

            builder.Property(x => x.DiemQuaTrinh)
                .HasPrecision(4, 2);

            builder.Property(x => x.DiemCuoiKy)
                .HasPrecision(4, 2);

            builder.Property(x => x.DiemTongKet)
                .HasPrecision(4, 2);

            builder.Property(x => x.DiemChu)
                .HasMaxLength(5);

            builder.Property(x => x.DiemSo4)
                .HasPrecision(3, 2);

            builder.Property(x => x.KetQua);

            builder.Property(x => x.SoBuoiVang)
                .HasDefaultValue(0);

            builder.Property(x => x.LyDoVang)
                .HasMaxLength(500);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(1000);

            builder.Property(x => x.IsMienGiam)
                .HasDefaultValue(false);

            builder.Property(x => x.LanHoc)
                .HasDefaultValue(1);

            builder.Property(x => x.HocPhi)
                .HasPrecision(18, 2);

            builder.Property(x => x.DaDongHocPhi)
                .HasDefaultValue(false);

            builder.Property(x => x.NgayDongHocPhi);

            // Required relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.HasOne(x => x.NamHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNamHoc)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Optional relationships
            builder.HasOne(x => x.LopHocPhan)
                .WithMany()
                .HasForeignKey(x => x.IdLopHocPhan)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiDuyet)
                .WithMany()
                .HasForeignKey(x => x.IdNguoiDuyet)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint for MaDangKy
            builder.HasIndex(x => x.MaDangKy)
                .IsUnique();

            // Composite index for common queries
            builder.HasIndex(x => new { x.IdSinhVien, x.IdMonHoc, x.IdHocKy, x.IdNamHoc });
            builder.HasIndex(x => new { x.IdSinhVien, x.TrangThai });
            builder.HasIndex(x => new { x.IdMonHoc, x.TrangThai });
        }
    }
}