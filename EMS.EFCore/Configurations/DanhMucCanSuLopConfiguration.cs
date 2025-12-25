using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucCanSuLopConfiguration : IEntityTypeConfiguration<DanhMucCanSuLop>
    {
        public void Configure(EntityTypeBuilder<DanhMucCanSuLop> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.MaChucVu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenChucVu)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.HoatDongDoan)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.LoaiChucVu)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiChucVu);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);

            builder.Property(x => x.DiemCong)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.STT);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            // Unique constraint for MaChucVu
            builder.HasIndex(x => x.MaChucVu);
        }
    }
}
