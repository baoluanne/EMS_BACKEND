using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiSinhVienConfiguration : IEntityTypeConfiguration<LoaiSinhVien>
    {
        public void Configure(EntityTypeBuilder<LoaiSinhVien> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Note: Additional properties will be configured when entity properties are confirmed
            builder.Property(x => x.MaLoaiSinhVien).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TenLoaiSinhVien).IsRequired().HasMaxLength(500);
        }
    }
}
