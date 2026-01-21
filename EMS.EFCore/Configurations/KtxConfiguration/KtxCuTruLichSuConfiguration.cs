using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Persistence.Configurations.KtxManagement
{
    public class KtxCuTruLichSuConfiguration : IEntityTypeConfiguration<KtxCuTruLichSu>
    {
        public void Configure(EntityTypeBuilder<KtxCuTruLichSu> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LoaiDon)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(x => x.TrangThai)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.NgayBatDau)
                .IsRequired();

            builder.Property(x => x.NgayRoiDuKien)
                .IsRequired();

            builder.Property(x => x.NgayRoiThucTe)
                .IsRequired(false);

            builder.Property(x => x.NgayGhiLichSu)
                .IsRequired();

            builder.HasOne(x => x.CuTru)
                .WithMany()
                .HasForeignKey(x => x.CuTruId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.DonKtx)
                .WithMany()
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PhongCu)
                .WithMany()
                .HasForeignKey(x => x.PhongCuId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GiuongCu)
                .WithMany()
                .HasForeignKey(x => x.GiuongCuId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PhongMoi)
                .WithMany()
                .HasForeignKey(x => x.PhongMoiId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GiuongMoi)
                .WithMany()
                .HasForeignKey(x => x.GiuongMoiId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("KtxCuTruLichSu");
        }
    }
}