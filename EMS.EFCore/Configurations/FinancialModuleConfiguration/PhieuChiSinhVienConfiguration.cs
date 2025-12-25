using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class PhieuChiSinhVienConfiguration : IEntityTypeConfiguration<PhieuChiSinhVien>
    {
        public void Configure(EntityTypeBuilder<PhieuChiSinhVien> builder)
        {
            builder.ToTable("PhieuChiSinhVien");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoPhieu).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.SoPhieu).IsUnique();

            builder.Property(x => x.SoTien).HasColumnType("decimal(18,2)");
            builder.Property(x => x.LyDoChi).HasMaxLength(255);
            builder.Property(x => x.SoTaiKhoanNhan).HasMaxLength(50);
            builder.Property(x => x.NganHangNhan).HasMaxLength(100);

            builder.HasOne(x => x.SinhVien)
                   .WithMany() 
                   .HasForeignKey(x => x.SinhVienId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}