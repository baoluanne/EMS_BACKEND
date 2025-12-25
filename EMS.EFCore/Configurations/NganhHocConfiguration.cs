using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NganhHocConfiguration : IEntityTypeConfiguration<NganhHoc>
    {
        public void Configure(EntityTypeBuilder<NganhHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaNganhHoc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenNganhHoc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
