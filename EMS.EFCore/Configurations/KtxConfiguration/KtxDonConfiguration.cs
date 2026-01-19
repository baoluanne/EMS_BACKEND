using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxDonConfiguration : IEntityTypeConfiguration<KtxDon>
    {
        public void Configure(EntityTypeBuilder<KtxDon> builder)
        {
            builder.ToTable("KtxDon");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDon)
                .HasMaxLength(50);

            builder.HasIndex(x => x.MaDon)
                .IsUnique();

            builder.Property(x => x.LoaiDon)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue(KtxLoaiDon.DangKyMoi);

            builder.Property(x => x.TrangThai)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue(KtxDonTrangThai.ChoDuyet);

            builder.Property(x => x.NgayGuiDon)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayDuyet)
                .HasColumnType("date");

            builder.Property(x => x.NgayBatDau)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayHetHan)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GoiDichVu)
                .WithMany()
                .HasForeignKey(x => x.IdGoiDichVu)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongDuocDuyet)
                .WithMany()
                .HasForeignKey(x => x.PhongDuocDuyetId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.GiuongDuocDuyet)
                .WithMany()
                .HasForeignKey(x => x.GiuongDuocDuyetId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.DonKtxChiTiets)
                .WithOne(d => d.DonKtx)
                .HasForeignKey(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DangKyMoi)
                .WithOne(d => d.DonKtx)
                .HasForeignKey<KtxDonDangKyMoi>(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.GiaHan)
                .WithOne(g => g.DonKtx)
                .HasForeignKey<KtxDonGiaHan>(g => g.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ChuyenPhong)
                .WithOne(c => c.DonKtx)
                .HasForeignKey<KtxDonChuyenPhong>(c => c.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.RoiKtx)
                .WithOne(r => r.DonKtx)
                .HasForeignKey<KtxDonRoiKtx>(r => r.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.IdSinhVien, x.IdHocKy })
                .HasDatabaseName("IX_KtxDon_SinhVien_HocKy");

            builder.HasIndex(x => x.TrangThai)
                .HasDatabaseName("IX_KtxDon_TrangThai");

            builder.HasIndex(x => x.LoaiDon)
                .HasDatabaseName("IX_KtxDon_LoaiDon");
        }
    }
}