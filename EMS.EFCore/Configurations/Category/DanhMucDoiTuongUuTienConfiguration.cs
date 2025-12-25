using EMS.Domain.Entities;
using EMS.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.Category
{
    public class DanhMucDoiTuongUuTienConfiguration : IEntityTypeConfiguration<DanhMucDoiTuongUuTien>
    {
        public void Configure(EntityTypeBuilder<DanhMucDoiTuongUuTien> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDoiTuong)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.TenDoiTuong)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasIndex(x => x.MaDoiTuong)
                .IsUnique();
        }
    }
}