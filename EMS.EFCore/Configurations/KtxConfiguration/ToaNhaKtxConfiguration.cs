using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class ToaNhaKtxConfiguration : IEntityTypeConfiguration<ToaNhaKtx>
    {
        public void Configure(EntityTypeBuilder<ToaNhaKtx> builder)
        {
            builder.ToTable("ToaNhaKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenToaNha)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(x => x.TenToaNha)
                .IsUnique();

            builder.Property(x => x.LoaiToaNha)
                .HasMaxLength(50);

            builder.HasMany(x => x.PhongKtxs)
                .WithOne(p => p.ToaNha)
                .HasForeignKey(p => p.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}