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

            // Index để tìm hợp đồng hiện tại nhanh hơn
            builder.HasIndex(x => new { x.SinhVienId, x.TrangThai })
                .HasFilter("\"TrangThai\" = 'DangO'");

            builder.HasIndex(x => new { x.GiuongKtxId, x.TrangThai })
                .HasFilter("\"TrangThai\" = 'DangO'");

            // Relationship với SinhVien
            builder.HasOne(x => x.SinhVien)
                .WithMany(s => s.CuTruKtxs) // cần thêm navigation ở SinhVien
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship với GiuongKtx
            builder.HasOne(x => x.GiuongKtx)
                .WithMany(g => g.CuTruKtxs) // cần thêm navigation ở GiuongKtx
                .HasForeignKey(x => x.GiuongKtxId)
                .OnDelete(DeleteBehavior.Restrict); // không xóa giường khi xóa hợp đồng

            // Relationship với DonKtx (tùy chọn, để truy vết nguồn gốc)
            builder.HasOne(x => x.DonKtx)
                .WithMany()
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}