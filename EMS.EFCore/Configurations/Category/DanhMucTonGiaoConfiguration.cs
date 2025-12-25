using EMS.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.Category
{
    public class DanhMucTonGiaoConfiguration : IEntityTypeConfiguration<DanhMucTonGiao>
    {
        public void Configure(EntityTypeBuilder<DanhMucTonGiao> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaTonGiao)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.TenTonGiao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasIndex(x => x.MaTonGiao)
                .IsUnique();
        }
    }
}