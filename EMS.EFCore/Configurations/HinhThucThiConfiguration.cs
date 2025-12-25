using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class HinhThucThiConfiguration : IEntityTypeConfiguration<HinhThucThi>
    {
        public void Configure(EntityTypeBuilder<HinhThucThi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaHinhThucThi)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenHinhThucThi)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);

            builder.Property(x => x.HeSoChamThi)
                .HasPrecision(5, 2);

            builder.Property(x => x.SoGiangVien);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Relationship with DanhMucBieuMau
            builder.HasOne(x => x.BieuMauDanhSachDuThi)
                .WithMany()
                .HasForeignKey(x => x.IdBieuMauDanhSachDuThi);

            // Unique constraint for MaHinhThucThi
            builder.HasIndex(x => x.MaHinhThucThi);
        }
    }
}

