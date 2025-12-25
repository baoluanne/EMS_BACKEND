using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class PhanMonLopHocConfiguration : IEntityTypeConfiguration<PhanMonLopHoc>
    {
        public void Configure(EntityTypeBuilder<PhanMonLopHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.MonHocBacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdMonHocBacDaoTao)
                .IsRequired();

            builder.HasOne(x => x.LopNienChe)
                .WithMany()
                .HasForeignKey(x => x.IdLopNienChe)
                .IsRequired();

            // Properties
            builder.Property(x => x.HocKy)
                .IsRequired();

            builder.Property(x => x.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);

            // String properties
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
} 