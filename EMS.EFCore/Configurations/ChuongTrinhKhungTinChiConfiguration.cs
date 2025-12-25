using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChuongTrinhKhungTinChiConfiguration : IEntityTypeConfiguration<ChuongTrinhKhungTinChi>
    {
        public void Configure(EntityTypeBuilder<ChuongTrinhKhungTinChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaChuongTrinh)
                .HasMaxLength(50);
            builder.Property(x => x.TenChuongTrinh)
                .HasMaxLength(255);
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
            builder.Property(x => x.GhiChuTiengAnh)
                .HasMaxLength(300);
            builder.Property(x => x.IsBlock)
                .IsRequired();

            // Required foreign keys
            builder.Property(x => x.IdCoSoDaoTao).IsRequired();
            builder.Property(x => x.IdKhoaHoc).IsRequired();
            builder.Property(x => x.IdLoaiDaoTao).IsRequired();
            builder.Property(x => x.IdNganhHoc).IsRequired();
            builder.Property(x => x.IdBacDaoTao).IsRequired();
            builder.Property(x => x.IdChuyenNganh).IsRequired();

            // Relationships
            builder.HasOne(x => x.CoSoDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdCoSoDaoTao)
                .IsRequired();
            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .IsRequired();
            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired();
            builder.HasOne(x => x.NganhHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNganhHoc)
                .IsRequired();
            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired();
            builder.HasOne(x => x.ChuyenNganh)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganh)
                .IsRequired();

            // Collection navigation
            builder.HasMany(x => x.ChiTietKhungHocKy_TinChis)
                .WithOne(x => x.ChuongTrinhKhungTinChi)
                .HasForeignKey(x => x.IdChuongTrinhKhung)
                .IsRequired();
        }
    }
} 