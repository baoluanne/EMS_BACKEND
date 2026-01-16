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
                .HasDefaultValue(0);

            builder.Property(x => x.SoLuongGiuong)
                .HasDefaultValue(0);

            builder.Property(x => x.TrangThai)
                .HasDefaultValue(0);

            // Foreign Key to Tang
            builder.HasOne(x => x.Tang)
                .WithMany(t => t.KtxPhongs)
                .HasForeignKey(x => x.TangKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: One Phong -> Many Giuongs
            builder.HasMany(x => x.KtxGiuongs)
                .WithOne(g => g.Phong)
                .HasForeignKey(g => g.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: One Phong -> Many ChiSoDienNuocs
            builder.HasMany(x => x.ChiSoDienNuocs)
                .WithOne(c => c.Phong)
                .HasForeignKey(c => c.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: One Phong -> Many YeuCauSuaChuas
            builder.HasMany(x => x.YeuCauSuaChuas)
                .WithOne(y => y.Phong)
                .HasForeignKey(y => y.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}