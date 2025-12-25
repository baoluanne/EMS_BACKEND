using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class MienGiamSinhVienConfiguration : IEntityTypeConfiguration<MienGiamSinhVien>
    {
        public void Configure(EntityTypeBuilder<MienGiamSinhVien> builder)
        {
            builder.ToTable("MienGiamSinhVien");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoTien)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TrangThai)
                   .HasMaxLength(50)
                   .HasDefaultValue("ChoDuyet");

            // Index tìm kiếm nhanh
            builder.HasIndex(x => x.SinhVienId);
            builder.HasIndex(x => x.NamHocHocKyId);
            builder.HasIndex(x => x.ChinhSachMienGiamId);
            builder.HasIndex(x => x.TrangThai);

            // Quan hệ
            builder.HasOne(x => x.ChinhSachMienGiam)
                   .WithMany(c => c.DanhSachApDung)
                   .HasForeignKey(x => x.ChinhSachMienGiamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}