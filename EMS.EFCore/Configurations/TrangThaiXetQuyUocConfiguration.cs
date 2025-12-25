using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TrangThaiXetQuyUocConfiguration : IEntityTypeConfiguration<TrangThaiXetQuyUoc>
    {
        public void Configure(EntityTypeBuilder<TrangThaiXetQuyUoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaTrangThaiXetQuyUoc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenTrangThaiXetQuyUoc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}


