using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucKhoanThuTuDoConfiguration : IEntityTypeConfiguration<DanhMucKhoanThuTuDo>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoanThuTuDo> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaKhoanThu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhoanThu)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.SoTien)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.STT);

            builder.HasOne(x => x.LoaiKhoanThu)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiKhoanThu)
                .IsRequired();

            builder.Property(x => x.ThueVAT)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.GomThueVAT)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.DonViTinh);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaKhoanThu
            builder.HasIndex(x => x.MaKhoanThu);
        }
    }
}
