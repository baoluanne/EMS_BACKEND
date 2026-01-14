using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxDonPhongGiuongConfiguration : IEntityTypeConfiguration<KtxDonPhongGiuong>
    {
        public void Configure(EntityTypeBuilder<KtxDonPhongGiuong> builder)
        {
            builder.ToTable("KtxDonPhongGiuong");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DonKtxId)
                .IsRequired();

            builder.Property(x => x.PhongYeuCauId)
                .IsRequired();

            builder.Property(x => x.LyDoChuyen)
                .HasMaxLength(500);

            builder.HasOne(x => x.DonKtx)
                .WithMany(d => d.DonKtxPhongGiuongs)
                .HasForeignKey(x => x.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PhongHienTai)
                .WithMany()
                .HasForeignKey(x => x.PhongHienTaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongYeuCau)
                .WithMany()
                .HasForeignKey(x => x.PhongYeuCauId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongDuocDuyet)
                .WithMany()
                .HasForeignKey(x => x.PhongDuocDuyetId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.GiuongDuocDuyet)
                .WithMany()
                .HasForeignKey(x => x.GiuongDuocDuyetId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}