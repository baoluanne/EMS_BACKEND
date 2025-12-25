using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChuyenNganhConfiguration : IEntityTypeConfiguration<ChuyenNganh>
    {
        public void Configure(EntityTypeBuilder<ChuyenNganh> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.NganhHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNganhHoc)
                .IsRequired();

            // Properties
            builder.Property(x => x.MaChuyenNganh)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenChuyenNganh)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.MaNganhTuQuan)
                .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.STT);

            builder.Property(x => x.TenVietTat)
                .HasMaxLength(50);

            builder.Property(x => x.TenTiengAnh)
                .HasMaxLength(200);

            builder.Property(x => x.IsVisible);

            // Unique constraint for MaChuyenNganh
            builder.HasIndex(x => x.MaChuyenNganh);
        }
    }
}

