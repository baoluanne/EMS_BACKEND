using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxViPhamNoiQuyConfiguration : IEntityTypeConfiguration<KtxViPhamNoiQuy>
    {
        public void Configure(EntityTypeBuilder<KtxViPhamNoiQuy> builder)
        {
            builder.ToTable("KtxViPhamNoiQuy");
            builder.HasKey(x => x.Id);

            // Cấu hình trường mới: LoaiViPham
            builder.Property(x => x.LoaiViPham)
                .IsRequired()
                .HasComment("Loại hành vi vi phạm dựa trên Enum");

            builder.Property(x => x.MaBienBan)
                .IsRequired()
                .HasMaxLength(100); // Tăng lên 100 vì mã tự sinh dài hơn (VP-PREFIX-YYYYMMDD-LX)

            builder.Property(x => x.NoiDungViPham)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.HinhThucXuLy)
                .HasMaxLength(500);

            builder.Property(x => x.LanViPham)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(x => x.DiemTru)
                .HasDefaultValue(0);

            // Cấu hình quan hệ với SinhVien
            builder.HasOne(x => x.SinhVien)
                .WithMany() // Một sinh viên có thể có nhiều biên bản vi phạm
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index để tìm kiếm nhanh theo mã biên bản hoặc sinh viên
            builder.HasIndex(x => x.MaBienBan).IsUnique();
            builder.HasIndex(x => x.SinhVienId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}