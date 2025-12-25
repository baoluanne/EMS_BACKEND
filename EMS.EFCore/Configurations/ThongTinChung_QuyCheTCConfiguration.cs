using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ThongTinChung_QuyCheTCConfiguration : IEntityTypeConfiguration<ThongTinChung_QuyCheTC>
    {
        public void Configure(EntityTypeBuilder<ThongTinChung_QuyCheTC> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyCheTC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheTC)
                .IsRequired();

            // Decimal fields with precision and scale
            builder.Property(x => x.DiemTKTrongSo)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemGKTrongSo)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemTieuLuanTrongSo)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemCuoiKyTrongSo)
                .HasPrecision(5, 2);
        }
    }
}
