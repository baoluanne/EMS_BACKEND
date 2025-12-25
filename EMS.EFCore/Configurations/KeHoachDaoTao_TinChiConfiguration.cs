using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KeHoachDaoTao_TinChiConfiguration : IEntityTypeConfiguration<KeHoachDaoTao_TinChi>
    {
        public void Configure(EntityTypeBuilder<KeHoachDaoTao_TinChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.ChiTietKhungHocKy_TinChi)
                .WithMany()
                .HasForeignKey(x => x.IdChiTietKhungHocKy_TinChi)
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