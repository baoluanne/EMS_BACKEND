using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChiTietChuongTrinhKhung_NienCheConfiguration : IEntityTypeConfiguration<ChiTietChuongTrinhKhung_NienChe>
    {
        public void Configure(EntityTypeBuilder<ChiTietChuongTrinhKhung_NienChe> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.ChuongTrinhKhungNienChe)
                .WithMany()
                .HasForeignKey(x => x.IdChuongTrinhKhung)
                .IsRequired();

            builder.HasOne(x => x.MonHocBacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdMonHocBacDaoTao)
                .IsRequired();

            // Properties
            builder.Property(x => x.HocKy)
                .IsRequired();

            builder.Property(x => x.IsBatBuoc)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
} 