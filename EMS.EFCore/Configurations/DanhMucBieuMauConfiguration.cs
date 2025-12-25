using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucBieuMauConfiguration : IEntityTypeConfiguration<DanhMucBieuMau>
    {
        public void Configure(EntityTypeBuilder<DanhMucBieuMau> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaBieuMau)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenBieuMau)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LoaiFile)
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Relationships
            builder.HasOne(x => x.KhoaQuanLy)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaQuanLy)
                .IsRequired();
        }
    }
}


