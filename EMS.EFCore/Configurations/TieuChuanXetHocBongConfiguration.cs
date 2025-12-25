using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TieuChuanXetHocBongConfiguration : IEntityTypeConfiguration<TieuChuanXetHocBong>
    {
        public void Configure(EntityTypeBuilder<TieuChuanXetHocBong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.STT)
                .IsRequired();

            builder.Property(x => x.Nhom)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.HocBong)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.HocLucDiem10Tu)
                .IsRequired();

            builder.Property(x => x.HocLucDiem10Den)
                .IsRequired();

            builder.Property(x => x.HanhKiemTu)
                .IsRequired();

            builder.Property(x => x.HanhKiemDen)
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.PhanTramSoTien)
                .HasMaxLength(10);

            builder.Property(x => x.SoTien)
                .HasMaxLength(10);
        }
    }
}
