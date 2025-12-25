using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NhomLoaiHanhViViPhamConfiguration : IEntityTypeConfiguration<NhomLoaiHanhViViPham>
    {
        public void Configure(EntityTypeBuilder<NhomLoaiHanhViViPham> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaNhomHanhVi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TenNhomHanhVi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
}
