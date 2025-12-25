using EMS.Domain.Entities.TimeTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ThoiKhoaBieuConfiguration : IEntityTypeConfiguration<ThoiKhoaBieu>
    {
        public void Configure(EntityTypeBuilder<ThoiKhoaBieu> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Thu)
                .IsRequired();
            
            builder.Property(x => x.TietBatDau)
                .IsRequired();
            
            builder.Property(x => x.SoTiet)
                .IsRequired();

            builder.Property(x => x.TuanHoc)
                .IsRequired(false)
                .HasMaxLength(100);
            
            builder.Property(x => x.GhiChu)
                .IsRequired(false)
                .HasMaxLength(200);
            
            // KF
            builder.HasOne(x => x.LopHocPhan)
                .WithMany()
                .HasForeignKey(x => x.IdLopHocPhan)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.PhongHoc)
                .WithMany()
                .HasForeignKey(x => x.IdPhongHoc)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.GiangVien)
                .WithMany()
                .HasForeignKey(x => x.IdGiangVien)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}