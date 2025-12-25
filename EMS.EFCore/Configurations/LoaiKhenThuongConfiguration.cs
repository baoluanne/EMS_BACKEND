using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiKhenThuongConfiguration : IEntityTypeConfiguration<LoaiKhenThuong>
    {
        public void Configure(EntityTypeBuilder<LoaiKhenThuong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaLoaiKhenThuong)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenLoaiKhenThuong)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DiemCongToiDa);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Relationships
            builder.HasOne(x => x.NhomLoaiKhenThuong)
                .WithMany()
                .HasForeignKey(x => x.IdNhomLoaiKhenThuong)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.KhenThuongs)
                .WithOne(x => x.LoaiKhenThuong)
                .HasForeignKey(x => x.IdLoaiKhenThuong)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
