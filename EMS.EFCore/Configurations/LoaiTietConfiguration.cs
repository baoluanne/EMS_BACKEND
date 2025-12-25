using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiTietConfiguration : IEntityTypeConfiguration<LoaiTiet>
    {
        public void Configure(EntityTypeBuilder<LoaiTiet> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiTiet)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiTiet)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.HeSo)  
                .HasPrecision(5, 2);

            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(300);
        }
    }
}

