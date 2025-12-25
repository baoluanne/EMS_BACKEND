using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class DonKtxConfiguration : IEntityTypeConfiguration<DonKtx>
    {
        public void Configure(EntityTypeBuilder<DonKtx> builder)
        {
            builder.ToTable("DonKtx");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDon).HasMaxLength(50);
            builder.Property(x => x.LoaiDon).HasMaxLength(50);
            builder.Property(x => x.TrangThai).HasMaxLength(50);
            builder.Property(x => x.LyDoChuyen).HasMaxLength(500);
            builder.Property(x => x.Ghichu).HasMaxLength(500);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongKtx)
                .WithMany()
                .HasForeignKey(x => x.PhongDuocDuyet)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongHienTainav)
                .WithMany()
                .HasForeignKey(x => x.PhongHienTai)
                .OnDelete(DeleteBehavior.Restrict);

   
            builder.HasOne(x => x.PhongMongMuonnav)
                .WithMany()
                .HasForeignKey(x => x.phongMuonChuyen)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GiuongKtx)
                .WithMany()
                .HasForeignKey(x => x.GiuongDuocDuyet)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}