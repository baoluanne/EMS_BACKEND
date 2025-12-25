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

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50);

            builder.Property(x => x.GiaPhong)
                .HasColumnType("decimal(18,2)");

            // Relationship với ToaNha
            builder.HasOne(x => x.ToaNha)
                .WithMany(x => x.PhongKtxs)
                .HasForeignKey(x => x.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship với GiuongKtx
            builder.HasMany(x => x.GiuongKtxs)
                .WithOne(x => x.PhongKtx)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}