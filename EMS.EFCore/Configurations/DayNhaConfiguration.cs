using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DayNhaConfiguration : IEntityTypeConfiguration<DayNha>
    {
        public void Configure(EntityTypeBuilder<DayNha> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDayNha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenDayNha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdDiaDiemPhong).IsRequired();
            builder.Property(x => x.SoTang);
            builder.Property(x => x.SoPhong);
            builder.Property(x => x.GhiChu).HasMaxLength(300);

            builder.HasOne(x => x.DiaDiemPhong)
                .WithMany(d => d.DayNha)
                .HasForeignKey(x => x.IdDiaDiemPhong);
        }
    }
} 