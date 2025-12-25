using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class HanhViViPhamConfiguration : IEntityTypeConfiguration<HanhViViPham>
    {
        public void Configure(EntityTypeBuilder<HanhViViPham> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaHanhVi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TenHanhVi).IsRequired().HasMaxLength(500);
            builder.Property(x => x.NoiDung).HasMaxLength(500);
            builder.Property(x => x.GhiChu).HasMaxLength(300);

            builder.HasOne(x => x.LoaiHanhVi)
                   .WithMany(x => x.HanhViViPhams)
                   .HasForeignKey(x => x.IdLoaiHanhVi)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}