using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ChuyenLopConfiguration : IEntityTypeConfiguration<ChuyenLop>
    {
        public void Configure(EntityTypeBuilder<ChuyenLop> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Required relationships
            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();

            builder.HasOne(x => x.LopCu)
                .WithMany()
                .HasForeignKey(x => x.IdLopCu)
                .IsRequired();

            builder.HasOne(x => x.LopMoi)
                .WithMany()
                .HasForeignKey(x => x.IdLopMoi)
                .IsRequired();

            // Optional relationship
            builder.HasOne(x => x.QuyetDinh)
                .WithMany()
                .HasForeignKey(x => x.IdQuyetDinh)
                .IsRequired(false);

            // Property configurations
            builder.Property(x => x.SoQuyetDinh)
                .HasMaxLength(100);

            builder.Property(x => x.NgayRaQuyetDinh)
                .IsRequired(false);

            builder.Property(x => x.NgayChuyenLop)
                .IsRequired();

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.PhanLoaiChuyenLop)
                .IsRequired();

            builder.Property(x => x.TrichYeu)
                .HasMaxLength(1000);

            // Indexes for better query performance
            builder.HasIndex(x => x.IdSinhVien);
            builder.HasIndex(x => x.IdLopCu);
            builder.HasIndex(x => x.IdLopMoi);
            builder.HasIndex(x => x.NgayChuyenLop);
            builder.HasIndex(x => x.PhanLoaiChuyenLop);
        }
    }
}