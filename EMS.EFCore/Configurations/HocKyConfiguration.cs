using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class HocKyConfiguration : IEntityTypeConfiguration<HocKy>
    {
        public void Configure(EntityTypeBuilder<HocKy> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.NamHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNamHoc)
                .IsRequired();

            // Required properties
            builder.Property(x => x.TenDot)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SoThuTu)
                .IsRequired();

            // Optional properties
            builder.Property(x => x.SoTuan)
                .HasPrecision(5, 2);

            builder.Property(x => x.HeSo)
                .HasPrecision(5, 2);

            builder.Property(x => x.TuThang);
            builder.Property(x => x.DenThang);
            builder.Property(x => x.NamHanhChinh)
                .HasMaxLength(20);
            builder.Property(x => x.TenDayDu)
                .HasMaxLength(200);
            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Boolean properties
            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(x => x.IsDKHP)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(x => x.IsDKNTTT)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}