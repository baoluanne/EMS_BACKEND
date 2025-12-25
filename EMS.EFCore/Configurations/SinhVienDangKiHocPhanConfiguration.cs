using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class SinhVienDangKiHocPhanConfiguration : IEntityTypeConfiguration<SinhVienDangKiHocPhan>
    {
        public void Configure(EntityTypeBuilder<SinhVienDangKiHocPhan> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany(x => x.DangKyHocPhans)
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LopHocPhan)
                .WithMany(x => x.DangKyHocPhans)
                .HasForeignKey(x => x.IdLopHocPhan)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.HocPhi);

            builder.Property(x => x.NguonDangKy);

            builder.HasIndex(x => x.TrangThaiDangKyLHP);

            // Properties

            builder.HasOne(x => x.NguoiDangKy)
                .WithMany()
                .HasForeignKey(x => x.IdNguoiDangKy)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}