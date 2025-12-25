using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NamHoc_HocKyConfiguration : IEntityTypeConfiguration<NamHoc_HocKy>
    {
        public void Configure(EntityTypeBuilder<NamHoc_HocKy> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Required string properties
            builder.Property(x => x.TenDot)
                .IsRequired()
                .HasMaxLength(50);

            // Required numeric properties
            builder.Property(x => x.STT)
                .IsRequired();

            builder.Property(x => x.SoTuan)
                .IsRequired();

            builder.Property(x => x.HeSo)
                .IsRequired()
                .HasPrecision(5, 2);

            // Required boolean properties with default values
            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsDangKyHP)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsDangKyNoiTruTT)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);

            // Optional integer properties
            builder.Property(x => x.TuThang);
            builder.Property(x => x.DenThang);
            builder.Property(x => x.TuNgay);
            builder.Property(x => x.DenNgay);

            // Optional string properties
            builder.Property(x => x.TenDayDu)
                .HasMaxLength(200);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);

            builder.Property(x => x.NamHoc)
                .HasMaxLength(20);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
} 