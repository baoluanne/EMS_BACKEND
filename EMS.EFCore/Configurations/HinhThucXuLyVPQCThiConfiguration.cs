using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class HinhThucXuLyVPQCThiConfiguration : IEntityTypeConfiguration<HinhThucXuLyVPQCThi>
    {
        public void Configure(EntityTypeBuilder<HinhThucXuLyVPQCThi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaHinhThucXL)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenHinhThucXL)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PhanTramDiemTru)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemTruRL)
                .HasPrecision(5, 2);

            builder.Property(x => x.IdMucDo)
                .IsRequired();

            builder.HasOne(x => x.MucDo)
                .WithMany()
                .HasForeignKey(x => x.IdMucDo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Add unique constraint for MaHinhThucXL
            builder.HasIndex(x => x.MaHinhThucXL);
        }
    }
} 