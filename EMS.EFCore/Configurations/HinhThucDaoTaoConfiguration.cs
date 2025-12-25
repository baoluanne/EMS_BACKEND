using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class HinhThucDaoTaoConfiguration : IEntityTypeConfiguration<HinhThucDaoTao>
    {
        public void Configure(EntityTypeBuilder<HinhThucDaoTao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaHinhThuc).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenHinhThuc).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
        }
    }
} 