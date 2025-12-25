using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiMonHocConfiguration : IEntityTypeConfiguration<LoaiMonHoc>
    {
        public void Configure(EntityTypeBuilder<LoaiMonHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiMonHoc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiMonHoc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}

