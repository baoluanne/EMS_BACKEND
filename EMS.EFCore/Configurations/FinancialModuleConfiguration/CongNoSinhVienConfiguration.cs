using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class CongNoSinhVienConfiguration : IEntityTypeConfiguration<CongNoSinhVien>
    {
        public void Configure(EntityTypeBuilder<CongNoSinhVien> builder)
        {
            builder.ToTable("CongNoSinhVien");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.SoTienPhaiThu);
            builder.Ignore(x => x.ConNo);
            builder.Ignore(x => x.DaDongDu);

            builder.Property(x => x.DaThu)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(x => x.TongMienGiam)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(x => x.HanNop).IsRequired();
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasIndex(x => new { x.SinhVienId, x.NamHocHocKyId }).IsUnique();

            builder.HasOne(x => x.SinhVien)
                   .WithMany(s => s.CongNos) 
                   .HasForeignKey(x => x.SinhVienId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(x => x.NamHocHocKy)
                   .WithMany()
                   .HasForeignKey(x => x.NamHocHocKyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}