using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxGiuongConfiguration : IEntityTypeConfiguration<KtxGiuong>
    {
        public void Configure(EntityTypeBuilder<KtxGiuong> builder)
        {
            builder.ToTable("KtxGiuong");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaGiuong)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(x => x.MaGiuong)
                .IsUnique();

            builder.Property(x => x.TrangThai)
                .HasDefaultValue(0);

            // Foreign Key to Phong
            builder.HasOne(x => x.Phong)
                .WithMany(p => p.KtxGiuongs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key to SinhVien (Optional)
            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relationship: One Giuong -> Many CuTruKtxs
            builder.HasMany(x => x.CuTruKtxs)
                .WithOne(c => c.GiuongKtx)
                .HasForeignKey(c => c.GiuongKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}