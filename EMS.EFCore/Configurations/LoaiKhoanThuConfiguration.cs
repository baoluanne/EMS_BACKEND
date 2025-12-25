using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiKhoanThuConfiguration : IEntityTypeConfiguration<LoaiKhoanThu>
    {
        public void Configure(EntityTypeBuilder<LoaiKhoanThu> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.MaLoaiKhoanThu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiKhoanThu)
                .IsRequired()
                .HasMaxLength(100);

            // Note: Additional properties will be configured when entity properties are confirmed
        }
    }
}
