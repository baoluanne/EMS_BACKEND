using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TieuChuanXetDanhHieuConfiguration : IEntityTypeConfiguration<TieuChuanXetDanhHieu>
    {
        public void Configure(EntityTypeBuilder<TieuChuanXetDanhHieu> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.STT)
                .IsRequired(false);

            builder.Property(x => x.NhomDanhHieu)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(x => x.HocLuc10Tu)
                .IsRequired();

            builder.Property(x => x.HocLuc10Den)
                .IsRequired();

            builder.Property(x => x.HocLuc4Tu)
                .IsRequired(false);

            builder.Property(x => x.HocLuc4Den)
                .IsRequired(false);

            builder.Property(x => x.HanhKiemTu)
                .IsRequired();

            builder.Property(x => x.HanhKiemDen)
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);
        }
    }
}
