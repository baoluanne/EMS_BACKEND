using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyetDinhConfiguration : IEntityTypeConfiguration<QuyetDinh>
    {
        public void Configure(EntityTypeBuilder<QuyetDinh> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Property configurations
            builder.Property(x => x.SoQuyetDinh)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenQuyetDinh)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.NgayRaQuyetDinh);
            builder.Property(x => x.NguoiRaQD)
                .HasMaxLength(100);
            
            builder.Property(x => x.NgayKyQuyetDinh);
            
            builder.Property(x => x.NguoiKyQD)
                .HasMaxLength(100);
            
            
            builder.HasOne(x => x.LoaiQuyetDinh)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiQuyetDinh)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(x => x.NoiDung)
                .HasMaxLength(1000);

            // Unique index for SoQuyetDinh
            builder.HasIndex(x => x.SoQuyetDinh)
                .IsUnique();
        }
    }
}