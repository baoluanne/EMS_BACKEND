using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucNganhDaoTaoConfiguration : IEntityTypeConfiguration<DanhMucNganhDaoTao>
    {
        public void Configure(EntityTypeBuilder<DanhMucNganhDaoTao> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Required relationships
            builder.HasOne(x => x.Khoa)
                .WithMany()
                .HasForeignKey(x => x.IdKhoa)
                .IsRequired();

            // Property configurations
            builder.Property(x => x.MaNganh)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenNganh)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);

            builder.Property(x => x.TenVietTat)
                .HasMaxLength(50);

            builder.Property(x => x.MaTuyenSinh)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.STT)
                .HasMaxLength(10);

            builder.Property(x => x.KhoiThi)
                .HasMaxLength(100);

            builder.Property(x => x.KyTuMaSV)
                .HasMaxLength(10);

            builder.HasOne(x => x.KhoiNganh)
                .WithMany()
                .HasForeignKey(x => x.IdKhoiNganh);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.IsVisible);

            // Unique constraints
            builder.HasIndex(x => x.MaNganh);

            builder.HasIndex(x => x.MaTuyenSinh);
        }
    }
}
