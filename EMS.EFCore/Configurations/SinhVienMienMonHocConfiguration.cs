using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class SinhVienMienMonHocConfiguration : IEntityTypeConfiguration<SinhVienMienMonHoc>
    {
        public void Configure(EntityTypeBuilder<SinhVienMienMonHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany(x => x.MonHocDuocMiens)
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();

            builder.HasOne(x => x.MonHocBacDaoTao)
                .WithMany(x => x.SinhVienDuocMiens)
                .HasForeignKey(x => x.IdMonHocBacDaoTao)
                .IsRequired();

            builder.HasOne(x => x.QuyetDinh)
                .WithMany()
                .HasForeignKey(x => x.IdQuyetDinh)
                .IsRequired(false);
        }
    }
}