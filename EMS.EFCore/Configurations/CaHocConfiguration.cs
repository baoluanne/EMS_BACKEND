using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class CaHocConfiguration : IEntityTypeConfiguration<CaHoc>
    {
        public void Configure(EntityTypeBuilder<CaHoc> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaCaHoc)
                .IsRequired();

            builder.Property(x => x.TenCaHoc)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Thu)
                .HasMaxLength(50);

            builder.Property(x => x.Tiet)
                .HasMaxLength(100);

            builder.Property(x => x.BuoiHoc)
                .HasConversion<int>();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaCaHoc
            builder.HasIndex(x => x.MaCaHoc)
                .IsUnique();
        }
    }
}