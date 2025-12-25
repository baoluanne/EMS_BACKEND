using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KhoiKienThucConfiguration : IEntityTypeConfiguration<KhoiKienThuc>
    {
        public void Configure(EntityTypeBuilder<KhoiKienThuc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaKhoiKienThuc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhoiKienThuc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
