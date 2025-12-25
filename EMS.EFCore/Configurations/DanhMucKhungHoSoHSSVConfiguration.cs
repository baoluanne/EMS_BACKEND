using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucKhungHoSoHSSVConfiguration : IEntityTypeConfiguration<DanhMucKhungHoSoHSSV>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhungHoSoHSSV> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Required relationships
            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired();

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired();

            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc);

            builder.Property(x => x.STT);

            builder.Property(x => x.IsBatBuoc);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasOne(x => x.TieuChiTuyenSinh)
                .WithMany()
                .HasForeignKey(x => x.IdTieuChiTuyenSinh);

            builder.HasOne(x => x.LoaiSinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiSinhVien);

            builder.HasOne(x => x.HoSoHSSV)
                .WithMany()
                .HasForeignKey(x => x.IdHoSoHSSV);

            // Unique constraint for MaHoSo within the same HoSoHssv, BacDaoTao and LoaiDaoTao
            builder.HasIndex(x => new { x.IdHoSoHSSV, x.IdBacDaoTao, x.IdLoaiDaoTao });
        }
    }
}
