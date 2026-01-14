using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxDonChiTietConfiguration : IEntityTypeConfiguration<KtxDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<KtxDonChiTiet> builder)
        {
            builder.ToTable("KtxDonChiTiet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DonKtxId)
                .IsRequired();

            builder.Property(x => x.IdDanhMucKhoanThu)
                .IsRequired();

            builder.Property(x => x.SoLuong)
                .IsRequired();

            builder.Property(x => x.DonGia)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.ThanhTien)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasOne(x => x.DonKtx)
                .WithMany(d => d.DonKtxChiTiets)
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DanhMucKhoanThu)
                .WithMany()
                .HasForeignKey(x => x.IdDanhMucKhoanThu)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.DonKtxId, x.IdDanhMucKhoanThu })
                .IsUnique();
        }
    }
}