using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxTangConfiguration : IEntityTypeConfiguration<KtxTang>
    {
        public void Configure(EntityTypeBuilder<KtxTang> builder)
        {
            builder.ToTable("KtxTang");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenTang)
                .HasMaxLength(50);

            builder.Property(x => x.LoaiTang)
                .HasMaxLength(50);

            builder.HasOne(x => x.ToaNha)
                .WithMany(t => t.KtxTangs)
                .HasForeignKey(x => x.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.KtxPhongs)
                .WithOne(p => p.Tang)
                .HasForeignKey(p => p.TangKtxId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}