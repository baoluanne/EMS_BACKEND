using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChuyenTruongConfiguration : IEntityTypeConfiguration<ChuyenTruong>
    {
        public void Configure(EntityTypeBuilder<ChuyenTruong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Required properties
            builder.Property(x => x.MaHoSo)
                .IsRequired()
                .HasMaxLength(50);

            // Optional properties
            builder.Property(x => x.HoTen)
                .HasMaxLength(100);

            // Relationships
            builder.HasOne(x => x.CoSo)
                .WithMany()
                .HasForeignKey(x => x.IdCoSo)
                .IsRequired(false);

            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .IsRequired(false);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired(false);

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired(false);

            builder.HasOne(x => x.NganhHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNganhHoc)
                .IsRequired(false);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired(false);

            builder.HasOne(x => x.ChuyenNganh)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganh)
                .IsRequired();

            builder.HasOne(x => x.LopHoc)
                .WithMany()
                .HasForeignKey(x => x.IdLopHoc)
                .IsRequired();
        }
    }
}