using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxCutruConfiguration : IEntityTypeConfiguration<KtxCutru>
    {
        public void Configure(EntityTypeBuilder<KtxCutru> builder)
        {
            builder.ToTable("KtxCutru");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SinhVienId)
                .IsRequired();

            builder.Property(x => x.GiuongKtxId)
                .IsRequired();

            builder.Property(x => x.DonKtxId)
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
                .WithMany(d => d.CuTruKtxs)
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}