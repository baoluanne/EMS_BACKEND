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

            builder.Property(x => x.LoaiToaNha)
                .HasMaxLength(50);

            builder.HasMany(x => x.PhongKtxs)
                .WithOne(x => x.ToaNha)
                .HasForeignKey(x => x.ToaNhaId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}