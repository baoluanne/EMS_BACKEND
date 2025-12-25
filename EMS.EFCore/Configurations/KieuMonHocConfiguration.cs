using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KieuMonHocConfiguration : IEntityTypeConfiguration<KieuMonHoc>
    {
        public void Configure(EntityTypeBuilder<KieuMonHoc> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaKieuMonHoc).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenKieuMonHoc).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
} 