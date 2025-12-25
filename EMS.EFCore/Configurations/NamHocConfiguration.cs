using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NamHocConfiguration : IEntityTypeConfiguration<NamHoc>
    {
        public void Configure(EntityTypeBuilder<NamHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Required properties
            builder.Property(x => x.NamHocValue)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.NienHoc)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);

            // Optional properties
            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(100);

            builder.Property(x => x.SoTuan)
                .HasPrecision(5, 2);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
