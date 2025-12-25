using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiGiangVienConfiguration : IEntityTypeConfiguration<LoaiGiangVien>
    {
        public void Configure(EntityTypeBuilder<LoaiGiangVien> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaLoaiGiangVien).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenLoaiGiangVien).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
} 