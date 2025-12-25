using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class MonHocConfiguration : IEntityTypeConfiguration<MonHoc>
    {
        public void Configure(EntityTypeBuilder<MonHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.LoaiMonHoc)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiMonHoc)
                .IsRequired();

            builder.HasOne(x => x.Khoa)
                .WithMany()
                .HasForeignKey(x => x.IdKhoa)
                .IsRequired();

            builder.HasOne(x => x.ToBoMon)
                .WithMany()
                .HasForeignKey(x => x.IdToBoMon)
                .IsRequired(false);

            builder.HasOne(x => x.LoaiTiet)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiTiet)
                .IsRequired(false);

            builder.HasOne(x => x.KhoiKienThuc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoiKienThuc)
                .IsRequired(false);

            builder.HasOne(x => x.TinhChatMonHoc)
                .WithMany()
                .HasForeignKey(x => x.IdTinhChatMonHoc)
                .IsRequired(false);

            // Properties
            builder.Property(x => x.MaMonHoc)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.MaMonHoc);

            builder.Property(x => x.TenMonHoc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MaTuQuan)
                .HasMaxLength(50);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(100);

            builder.Property(x => x.TenVietTat)
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            builder.Property(x => x.IsKhongTinhTBC)
                .IsRequired(false);

            builder.Property(x => x.SoTinChi);
        }
    }
}

