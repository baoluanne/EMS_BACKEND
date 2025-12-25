using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Domain.Configurations
{
    public class HTXLViPhamQCThiConfiguration : IEntityTypeConfiguration<HTXLViPhamQCThi>
    {
        public void Configure(EntityTypeBuilder<HTXLViPhamQCThi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaXLQC)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenXLQC)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhanTramDiemTru)
                .IsRequired(false);

            builder.Property(x => x.MucDo)
                .IsRequired(false);

            builder.Property(x => x.DiemTruRL)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);
        }
    }
}
