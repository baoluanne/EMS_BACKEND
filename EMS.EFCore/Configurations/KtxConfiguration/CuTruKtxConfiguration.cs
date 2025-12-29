// CuTruKtxConfiguration.cs
using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class CuTruKtxConfiguration : IEntityTypeConfiguration<CuTruKtx>
    {
        public void Configure(EntityTypeBuilder<CuTruKtx> builder)
        {
            builder.ToTable("CuTruKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SinhVienId)
                .IsRequired();

            builder.Property(x => x.GiuongKtxId)
                .IsRequired();

            builder.Property(x => x.NgayBatDau)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayHetHan)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("DangO");

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasIndex(x => new { x.SinhVienId, x.TrangThai })
                .HasFilter("\"TrangThai\" = 'DangO'");

            builder.HasIndex(x => new { x.GiuongKtxId, x.TrangThai })
                .HasFilter("\"TrangThai\" = 'DangO'");

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.GiuongKtx)
                .WithMany(g => g.CuTruKtxs)
                .HasForeignKey(x => x.GiuongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DonKtx)
                .WithMany()
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}