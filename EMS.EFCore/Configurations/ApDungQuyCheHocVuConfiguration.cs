using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ApDungQuyCheHocVuConfiguration : IEntityTypeConfiguration<ApDungQuyCheHocVu>
    {
        public void Configure(EntityTypeBuilder<ApDungQuyCheHocVu> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyCheTC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheTC)
                .IsRequired(false);

            builder.HasOne(x => x.QuyCheNC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheNC)
                .IsRequired(false);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired(false);
            
            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired(false);
            
            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .IsRequired(false);
            // Decimal fields with precision and scale
            builder.Property(x => x.ChoPhepNoMon)
                .HasPrecision(5, 2);

            builder.Property(x => x.ChoPhepNoDVHT)
                .HasPrecision(5, 2);

            // String properties
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
