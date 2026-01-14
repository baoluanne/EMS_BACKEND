using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxChiSoDienNuocConfiguration : IEntityTypeConfiguration<KtxChiSoDienNuoc>
    {
        public void Configure(EntityTypeBuilder<KtxChiSoDienNuoc> builder)
        {
            builder.ToTable("KtxChiSoDienNuoc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhongKtxId)
                .IsRequired();

            builder.Property(x => x.Thang)
                .IsRequired();

            builder.Property(x => x.Nam)
                .IsRequired();

            builder.Property(x => x.DienCu)
                .IsRequired();

            builder.Property(x => x.DienMoi)
                .IsRequired();

            builder.Property(x => x.NuocCu)
                .IsRequired();

            builder.Property(x => x.NuocMoi)
                .IsRequired();

            builder.Property(x => x.DaChot)
                .HasDefaultValue(false);

            builder.HasOne(x => x.Phong)
                .WithMany(p => p.ChiSoDienNuocs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.PhongKtxId, x.Thang, x.Nam })
                .IsUnique()
                .HasDatabaseName("IX_KtxChiSoDienNuoc_Phong_Thang_Nam_Unique");
        }
    }
}