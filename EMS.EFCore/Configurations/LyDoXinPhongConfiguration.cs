using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LyDoXinPhongConfiguration : IEntityTypeConfiguration<LyDoXinPhong>
    {
        public void Configure(EntityTypeBuilder<LyDoXinPhong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiXinPhong)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiXinPhong)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SoThuTu);
        }
    }
} 