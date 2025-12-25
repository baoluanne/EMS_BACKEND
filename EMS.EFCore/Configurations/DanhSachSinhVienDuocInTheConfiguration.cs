using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhSachSinhVienDuocInTheConfiguration : IEntityTypeConfiguration<DanhSachSinhVienDuocInThe>
    {
        public void Configure(EntityTypeBuilder<DanhSachSinhVienDuocInThe> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CoHinhTheSv);
            builder.Property(x => x.NgayImportHinhTheSv);

            // Relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany(x => x.DanhSachSinhVienDuocInThes)
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();
        }
    }
}