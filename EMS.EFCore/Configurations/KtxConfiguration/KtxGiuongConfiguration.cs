using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
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
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TrangThai)
        .HasConversion<string>()
        .HasMaxLength(50)
        .IsRequired()
        .HasDefaultValue(KtxGiuongTrangThai.Trong);

            builder.HasOne(x => x.Phong)
                .WithMany(p => p.Giuongs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}