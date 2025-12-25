using EMS.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.Category
{
    public class DanhMucQuocTichConfiguration : IEntityTypeConfiguration<DanhMucQuocTich>
    {
        public void Configure(EntityTypeBuilder<DanhMucQuocTich> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaQuocGia)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.TenQuocGia)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasIndex(x => x.MaQuocGia)
                .IsUnique();
        }
    }
}