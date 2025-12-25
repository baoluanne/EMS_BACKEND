using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChuongTrinhKhungNienCheConfiguration : IEntityTypeConfiguration<ChuongTrinhKhungNienChe>
    {
        public void Configure(EntityTypeBuilder<ChuongTrinhKhungNienChe> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

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

            builder.HasMany(x => x.ChiTietChuongTrinhKhungNienChes)
                .WithOne(x => x.ChuongTrinhKhungNienChe)
                .HasForeignKey(x => x.IdChuongTrinhKhung)
                .OnDelete(DeleteBehavior.Cascade);

            // Properties
            builder.Property(x => x.MaChuongTrinh)
                .HasMaxLength(50);

            builder.Property(x => x.TenChuongTrinh)
                .HasMaxLength(200);

            builder.Property(x => x.IsBlock)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            builder.Property(x => x.GhiChuTiengAnh)
                .HasMaxLength(300);
        }
    }
} 