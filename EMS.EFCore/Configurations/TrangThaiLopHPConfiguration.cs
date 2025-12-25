using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TrangThaiLopHPConfiguration : IEntityTypeConfiguration<TrangThaiLopHP>
    {
        public void Configure(EntityTypeBuilder<TrangThaiLopHP> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaTrangThaiLop)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenTrangThaiLop)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}



