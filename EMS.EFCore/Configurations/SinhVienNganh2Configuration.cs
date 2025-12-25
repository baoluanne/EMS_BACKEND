using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class SinhVienNganh2Configuration : IEntityTypeConfiguration<SinhVienNganh2>
    {
        public void Configure(EntityTypeBuilder<SinhVienNganh2> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();

            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .IsRequired();

            builder.HasOne(x => x.LopHoc2)
                .WithMany()
                .HasForeignKey(x => x.IdLopHoc2)
                .IsRequired();

            // Properties
            builder.Property(x => x.SoQuyetDinh)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}