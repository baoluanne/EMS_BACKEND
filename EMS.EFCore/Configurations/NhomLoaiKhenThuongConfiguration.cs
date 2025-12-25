using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class NhomLoaiKhenThuongConfiguration : IEntityTypeConfiguration<NhomLoaiKhenThuong>
    {
        public void Configure(EntityTypeBuilder<NhomLoaiKhenThuong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaNhomKhenThuong).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TenNhomKhenThuong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
}
