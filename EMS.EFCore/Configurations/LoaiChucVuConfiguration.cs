using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiChucVuConfiguration : IEntityTypeConfiguration<LoaiChucVu>
    {
        public void Configure(EntityTypeBuilder<LoaiChucVu> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiChucVu).IsRequired();

            builder.Property(x => x.TenLoaiChucVu).IsRequired();

            builder.Property(x => x.STT).IsRequired(false);

            builder.Property(x => x.GhiChu).IsRequired(false);

            // Composite unique constraint for IdBacDaoTao and IdLoaiDaoTao
            builder.HasIndex(x => new { x.MaLoaiChucVu, x.TenLoaiChucVu });
        }
    }
}
