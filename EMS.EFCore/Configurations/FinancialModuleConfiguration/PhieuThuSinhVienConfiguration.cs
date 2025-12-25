using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class PhieuThuSinhVienConfiguration : IEntityTypeConfiguration<PhieuThuSinhVien>
    {
        public void Configure(EntityTypeBuilder<PhieuThuSinhVien> builder)
        {
            builder.ToTable("PhieuThuSinhVien");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoPhieu).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.SoPhieu).IsUnique();

            builder.Property(x => x.SoTien).HasColumnType("decimal(18,2)");
            builder.Property(x => x.HinhThucThanhToan).HasMaxLength(50);
            builder.Property(x => x.NguoiThu).HasMaxLength(100);

            builder.HasOne(x => x.SinhVien)
                   .WithMany(s => s.PhieuThus)
                   .HasForeignKey(x => x.SinhVienId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CongNo)
                   .WithMany(c => c.PhieuThus)
                   .HasForeignKey(x => x.CongNoId)
                   .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}