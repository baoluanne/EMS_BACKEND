using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KeHoachDaoTao_NienCheConfiguration : IEntityTypeConfiguration<KeHoachDaoTao_NienChe>
    {
        public void Configure(EntityTypeBuilder<KeHoachDaoTao_NienChe> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.ChiTietChuongTrinhKhung_NienChe)
                .WithMany()
                .HasForeignKey(x => x.IdChiTietKhungHocKy_NienChe)
                .IsRequired();

            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .IsRequired();

            // Boolean property
            builder.Property(x => x.IsHocKyChinh)
                .IsRequired()
                .HasDefaultValue(false);

            // Optional string property
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
} 