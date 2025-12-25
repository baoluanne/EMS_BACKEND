using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class PhongHocConfiguration : IEntityTypeConfiguration<PhongHoc>
    {
        public void Configure(EntityTypeBuilder<PhongHoc> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaPhong).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenPhong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdDayNha).IsRequired();
            builder.Property(x => x.SoBan);
            builder.Property(x => x.SoChoNgoi);
            builder.Property(x => x.SoChoThi);
            builder.Property(x => x.IsNgungDungMayChieu);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
            builder.Property(x => x.IdLoaiPhong).IsRequired();
            builder.Property(x => x.IdTCMonHoc);

            builder.HasOne(x => x.DayNha)
                .WithMany(d => d.PhongHoc)
                .HasForeignKey(x => x.IdDayNha);

            builder.HasOne(x => x.LoaiPhong)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiPhong);

            builder.HasOne(x => x.TCMonHoc)
                .WithMany()
                .HasForeignKey(x => x.IdTCMonHoc).IsRequired(false);
            
            builder.HasIndex(x => x.MaPhong).IsUnique();
        }
    }
} 