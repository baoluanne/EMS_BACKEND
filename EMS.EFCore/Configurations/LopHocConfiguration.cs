using EMS.Domain.Entities.ClassManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LopHocConfiguration : IEntityTypeConfiguration<LopHoc>
    {
        public void Configure(EntityTypeBuilder<LopHoc> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaLop)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLop)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);

            builder.Property(x => x.SiSoDuKien)
                .IsRequired();

            builder.Property(x => x.SiSoHienTai)
                .HasDefaultValue(0);

            builder.Property(x => x.SiSoDangHoc)
                .HasDefaultValue(0);

            builder.Property(x => x.IsVisible)
                .HasDefaultValue(true);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.KyTuMSSV)
                .HasMaxLength(10);

            builder.Property(x => x.SoHopDong)
                .HasMaxLength(100);

            builder.Property(x => x.SoQuyetDinhThanhLapLop)
                .HasMaxLength(100);

            // Foreign key relationships
            builder.HasOne(x => x.CoSoDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdCoSoDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NganhHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNganhHoc)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChuyenNganh)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganh)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Khoa)
                .WithMany()
                .HasForeignKey(x => x.IdKhoa)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GiangVienChuNhiem)
                .WithMany()
                .HasForeignKey(x => x.IdGiangVienChuNhiem)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.CoVanHocTap)
                .WithMany()
                .HasForeignKey(x => x.IdCoVanHocTap)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.CaHoc)
                .WithMany()
                .HasForeignKey(x => x.IDCaHoc)
                .OnDelete(DeleteBehavior.SetNull);

            // Unique constraints
            builder.HasIndex(x => x.MaLop)
                .IsUnique();

            // Composite indexes for better query performance
            builder.HasIndex(x => new { x.IdKhoaHoc, x.IdNganhHoc, x.MaLop })
                .HasDatabaseName("IX_LopHoc_KhoaHoc_NganhHoc_MaLop");

            builder.HasIndex(x => new { x.IdKhoa, x.IdBacDaoTao, x.IdLoaiDaoTao })
                .HasDatabaseName("IX_LopHoc_Khoa_BacDaoTao_LoaiDaoTao");
        }
    }
}