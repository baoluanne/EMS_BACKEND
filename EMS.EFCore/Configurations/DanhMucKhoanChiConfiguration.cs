using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucKhoanChiConfiguration : IEntityTypeConfiguration<DanhMucKhoanChi>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoanChi> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaKhoanChi)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhoanChi)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaKhoanChi
            builder.HasIndex(x => x.MaKhoanChi);
        }
    }
}
