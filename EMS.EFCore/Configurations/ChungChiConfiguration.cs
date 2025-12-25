using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChungChiConfiguration : IEntityTypeConfiguration<ChungChi>
    {
        public void Configure(EntityTypeBuilder<ChungChi> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.TenLoaiChungChi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.KyHieu)
                .HasMaxLength(50);

            builder.Property(x => x.GiaTri)
                .HasPrecision(5, 2);

            builder.Property(x => x.HocPhi)
                .HasPrecision(5, 2);

            builder.Property(x => x.LePhiThi)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemQuyDinh)
                .HasPrecision(5, 2);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Relationships
            builder.HasOne(x => x.LoaiChungChi)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiChungChi)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}