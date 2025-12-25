using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KhoaHocConfiguration : IEntityTypeConfiguration<KhoaHoc>
    {
        public void Configure(EntityTypeBuilder<KhoaHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.TenKhoaHoc)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Nam)
                .HasMaxLength(5);

            builder.Property(x => x.CachViet)
                .HasMaxLength(20);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
