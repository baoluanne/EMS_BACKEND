using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucNoiDungConfiguration : IEntityTypeConfiguration<DanhMucNoiDung>
    {
        public void Configure(EntityTypeBuilder<DanhMucNoiDung> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.LoaiNoiDung)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NoiDung)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(false);

            // Composite unique constraint for LoaiNoiDung and NoiDung
            builder.HasIndex(x => new { x.LoaiNoiDung, x.NoiDung });
        }
    }
}
