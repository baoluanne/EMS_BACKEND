using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucPhongBanConfiguration : IEntityTypeConfiguration<DanhMucPhongBan>
    {
        public void Configure(EntityTypeBuilder<DanhMucPhongBan> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaPhongBan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenPhongBan)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IsDaoTao);
        }
    }
} 