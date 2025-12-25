using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiHinhGiangDayConfiguration : IEntityTypeConfiguration<LoaiHinhGiangDay>
    {
        public void Configure(EntityTypeBuilder<LoaiHinhGiangDay> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiHinhGiangDay)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiHinhGiangDay)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}


