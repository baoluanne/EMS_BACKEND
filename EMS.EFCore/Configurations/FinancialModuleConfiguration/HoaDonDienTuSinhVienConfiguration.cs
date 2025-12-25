using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class HoaDonDienTuSinhVienConfiguration : IEntityTypeConfiguration<HoaDonDienTuSinhVien>
    {
        public void Configure(EntityTypeBuilder<HoaDonDienTuSinhVien> builder)
        {
            builder.ToTable("HoaDonDienTuSinhVien");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaHoaDon).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.MaHoaDon).IsUnique();

            builder.Property(x => x.NhaCungCap).HasMaxLength(100);
            builder.Property(x => x.TrangThai).HasMaxLength(50).HasDefaultValue("ChoPhatHanh");
            builder.Property(x => x.LinkPDF).HasMaxLength(500);

            builder.HasOne(x => x.PhieuThu)
                   .WithOne(pt => pt.HoaDonDienTu)
                   .HasForeignKey<HoaDonDienTuSinhVien>(x => x.PhieuThuId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}