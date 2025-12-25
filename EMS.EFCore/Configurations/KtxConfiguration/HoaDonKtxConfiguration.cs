using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class HoaDonKtxConfiguration : IEntityTypeConfiguration<HoaDonKtx>
    {
        public void Configure(EntityTypeBuilder<HoaDonKtx> builder)
        {
            builder.ToTable("HoaDonKtx");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.TongTien).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.PhongKtx)
                .WithMany(p => p.HoaDonKtxs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChiSoDienNuoc)
                .WithMany(x => x.HoaDonKtxs)
                .HasForeignKey(x => x.ChiSoDienNuocId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(x => new { x.PhongKtxId, x.Thang, x.Nam })
                   .IsUnique();
        }
    }
}