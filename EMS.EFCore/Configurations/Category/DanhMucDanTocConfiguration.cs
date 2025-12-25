using EMS.Domain.Entities;
using EMS.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.Category
{
    public class DanhMucDanTocConfiguration : IEntityTypeConfiguration<DanhMucDanToc>
    {
        public void Configure(EntityTypeBuilder<DanhMucDanToc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDanToc)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.TenDanToc)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasIndex(x => x.MaDanToc)
                .IsUnique();
        }
    }
}