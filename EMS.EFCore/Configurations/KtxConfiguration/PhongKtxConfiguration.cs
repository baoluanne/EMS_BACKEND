using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class PhongKtxConfiguration : IEntityTypeConfiguration<PhongKtx>
    {
        public void Configure(EntityTypeBuilder<PhongKtx> builder)
        {
            builder.ToTable("PhongKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaPhong)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(x => x.MaPhong)
                .IsUnique();

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.GiaPhong)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.ToaNha)
                .WithMany(t => t.PhongKtxs)
                .HasForeignKey(x => x.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GiuongKtxs)
                .WithOne(g => g.PhongKtx)
                .HasForeignKey(g => g.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ChiSoDienNuocs)
                .WithOne(c => c.PhongKtx)
                .HasForeignKey(c => c.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TaiSanKtxs)
                .WithOne(t => t.PhongKtx)
                .HasForeignKey(t => t.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.HoaDonKtxs)
                .WithOne(h => h.PhongKtx)
                .HasForeignKey(h => h.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.YeuCauSuaChuas)
                .WithOne(y => y.PhongKtx)
                .HasForeignKey(y => y.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}