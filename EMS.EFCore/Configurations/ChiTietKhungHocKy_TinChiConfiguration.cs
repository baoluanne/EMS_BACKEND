using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChiTietKhungHocKy_TinChiConfiguration : IEntityTypeConfiguration<ChiTietKhungHocKy_TinChi>
    {
        public void Configure(EntityTypeBuilder<ChiTietKhungHocKy_TinChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.ChuongTrinhKhungTinChi)
                .WithMany(x => x.ChiTietKhungHocKy_TinChis)
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