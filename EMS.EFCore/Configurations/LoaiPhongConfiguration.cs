using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiPhongConfiguration : IEntityTypeConfiguration<LoaiPhong>
    {
        public void Configure(EntityTypeBuilder<LoaiPhong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaLoaiPhong).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenLoaiPhong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
} 