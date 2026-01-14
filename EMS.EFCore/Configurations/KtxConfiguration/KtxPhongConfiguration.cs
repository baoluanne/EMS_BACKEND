using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxPhongConfiguration : IEntityTypeConfiguration<KtxPhong>
    {
        public void Configure(EntityTypeBuilder<KtxPhong> builder)
        {
            builder.ToTable("KtxPhong");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaPhong)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(x => x.MaPhong)
                .IsUnique();

            builder.Property(x => x.LoaiPhong)
                .HasMaxLength(50);

            builder.HasOne(x => x.Tang)
                .WithMany(t => t.KtxPhongs)
                .HasForeignKey(x => x.TangKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.KtxGiuongs)
                .WithOne(g => g.Phong)
                .HasForeignKey(g => g.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ChiSoDienNuocs)
                .WithOne(c => c.Phong)
                .HasForeignKey(c => c.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.YeuCauSuaChuas)
                .WithOne(y => y.Phong)
                .HasForeignKey(y => y.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}