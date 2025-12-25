using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DiaDiemPhongConfiguration : IEntityTypeConfiguration<DiaDiemPhong>
    {
        public void Configure(EntityTypeBuilder<DiaDiemPhong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaDDPhong).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenNhomDDPhong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DiaChi).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IdCoSoDaoTao).IsRequired();
            builder.Property(x => x.DiaDiem).HasMaxLength(100);
            builder.Property(x => x.BanKinh);
            builder.Property(x => x.GhiChu).HasMaxLength(300);

            builder.HasOne(x => x.CoSoDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdCoSoDaoTao);
        }
    }
} 