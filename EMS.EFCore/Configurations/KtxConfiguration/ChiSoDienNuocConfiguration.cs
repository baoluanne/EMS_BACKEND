// ChiSoDienNuocConfiguration.cs
using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class ChiSoDienNuocConfiguration : IEntityTypeConfiguration<ChiSoDienNuoc>
    {
        public void Configure(EntityTypeBuilder<ChiSoDienNuoc> builder)
        {
            builder.ToTable("ChiSoDienNuoc");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PhongKtx)
                .WithMany(p => p.ChiSoDienNuocs)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.PhongKtxId, x.Thang, x.Nam })
                .IsUnique()
                .HasDatabaseName("IX_ChiSoDienNuoc_Phong_Thang_Nam_Unique");
        }
    }
}