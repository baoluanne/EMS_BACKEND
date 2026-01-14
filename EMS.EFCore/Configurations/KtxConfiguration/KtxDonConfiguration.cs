using EMS.Domain.Entities.KtxManagement;
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
                .HasMaxLength(50);

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50);

            builder.Property(x => x.NgayGuiDon)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayBatDau)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayHetHan)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.NgayOThucTe)
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

            builder.HasMany(x => x.DonKtxChiTiets)
                .WithOne(d => d.DonKtx)
                .HasForeignKey(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DonKtxPhongGiuongs)
                .WithOne(d => d.DonKtx)
                .HasForeignKey(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CuTruKtxs)
                .WithOne(c => c.DonKtx)
                .HasForeignKey(c => c.DonKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}