using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class TaiSanKtxConfiguration : IEntityTypeConfiguration<TaiSanKtx>
    {
        public void Configure(EntityTypeBuilder<TaiSanKtx> builder)
        {
            builder.ToTable("TaiSanKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaTaiSan)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TenTaiSan)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.TinhTrang)
                .HasMaxLength(50)
                .HasDefaultValue("Tot");

            builder.Property(x => x.GiaTri)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.HasOne(x => x.PhongKtx)
                .WithMany(p => p.TaiSanKtxs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}