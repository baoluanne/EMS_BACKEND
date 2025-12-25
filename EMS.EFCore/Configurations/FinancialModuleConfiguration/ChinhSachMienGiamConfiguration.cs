using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class ChinhSachMienGiamConfiguration : IEntityTypeConfiguration<ChinhSachMienGiam>
    {
        public void Configure(EntityTypeBuilder<ChinhSachMienGiam> builder)
        {
            builder.ToTable("ChinhSachMienGiam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenChinhSach)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.LoaiChinhSach)
                   .HasMaxLength(20)
                   .IsRequired()
                   .HasDefaultValue("SoTien");

            builder.Property(x => x.GiaTri)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.ApDungCho)
                   .HasMaxLength(30)
                   .IsRequired()
                   .HasDefaultValue("TatCa");

            builder.Property(x => x.TrangThai)
                   .HasMaxLength(30)
                   .HasDefaultValue("HoatDong");

            builder.Property(x => x.GhiChu)
                   .HasMaxLength(1000);

            // Index tìm kiếm nhanh
            builder.HasIndex(x => x.TenChinhSach);
            builder.HasIndex(x => x.TrangThai);
            builder.HasIndex(x => x.NamHocHocKyId);

            // Quan hệ 1-n với MienGiamSinhVien
            builder.HasMany(x => x.DanhSachApDung)
                   .WithOne(m => m.ChinhSachMienGiam)
                   .HasForeignKey(m => m.ChinhSachMienGiamId)
                   .OnDelete(DeleteBehavior.Restrict); // Không xóa chính sách nếu đang có sinh viên dùng
        }
    }
}