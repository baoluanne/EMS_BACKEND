using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KhenThuongConfiguration : IEntityTypeConfiguration<KhenThuong>
    {
        public void Configure(EntityTypeBuilder<KhenThuong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaKhenThuong)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhenThuong)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DiemCong);
            
            builder.Property(x => x.DiemCongToiDa);

            builder.Property(x => x.NoiDung)
                .HasMaxLength(500);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            builder.Property(x => x.IsViPhamNoiTru);

            // Relationships
            builder.HasOne(x => x.LoaiKhenThuong)
                .WithMany(x => x.KhenThuongs)
                .HasForeignKey(x => x.IdLoaiKhenThuong)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}