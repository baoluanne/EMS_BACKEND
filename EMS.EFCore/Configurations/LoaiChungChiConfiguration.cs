     using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiChungChiConfiguration : IEntityTypeConfiguration<LoaiChungChi>
    {
        public void Configure(EntityTypeBuilder<LoaiChungChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiChungChi)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiChungChi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(300);
        }
    }
}