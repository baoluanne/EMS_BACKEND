using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NhatKyCapNhatTrangThaiSvConfiguration : IEntityTypeConfiguration<NhatKyCapNhatTrangThaiSv>
    {
        public void Configure(EntityTypeBuilder<NhatKyCapNhatTrangThaiSv> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.SinhVien)
                .WithMany()
                .HasForeignKey(e => e.IdSinhVien)
                .IsRequired();

            builder.HasOne(e => e.QuyetDinh)
                .WithMany()
                .HasForeignKey(e => e.IdQuyetDinh)
                .IsRequired();

            builder.Property(e => e.SoQuyetDinh)
                .HasMaxLength(50);

            builder.Property(e => e.GhiChu)
                .HasMaxLength(500);
        }
    }
}