using EMS.Domain.Entities; // Giả định nơi chứa các entity MonHoc, SinhVien
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BangDiemChiTietConfiguration : IEntityTypeConfiguration<BangDiemChiTiet>
{
    public void Configure(EntityTypeBuilder<BangDiemChiTiet> builder)
    {
        builder.ToTable("BangDiemChiTiet");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdSinhVien).IsRequired();
        builder.Property(x => x.IdMonHoc).IsRequired();
        builder.Property(x => x.DiemTongKet).IsRequired();
        builder.Property(x => x.LanHoc).IsRequired();
        builder.Property(x => x.IsDiemCaoNhat).IsRequired();

        // IdLopHocPhan có thể NULL (ví dụ: điểm chuyển đổi không qua LHP)
        builder.Property(x => x.IdLopHocPhan).IsRequired(false);
        // IdChuyenDoiHocPhan có thể NULL (ví dụ: điểm thi thực tế)
        builder.Property(x => x.IdChuyenDoiHocPhan).IsRequired(false);

        // --- 2. Cấu hình Quan hệ (Relationships) ---

        // Quan hệ 1-N: SinhVien -> BangDiemChiTiet (SinhVien có nhiều bản ghi điểm)
        builder.HasOne(x => x.SinhVien)
            .WithMany(x => x.BangDiemChiTiets) // Giả định SinhVien không có ICollection<BangDiemChiTiet>
            .HasForeignKey(x => x.IdSinhVien)
            .OnDelete(DeleteBehavior.Cascade); // Xóa SV -> Xóa điểm

        // Quan hệ 1-N: MonHoc -> BangDiemChiTiet (MonHoc có nhiều bản ghi điểm)
        builder.HasOne(x => x.MonHoc)
            .WithMany(x => x.BangDiemChiTiets) // Giả định MonHoc không có ICollection<BangDiemChiTiet>
            .HasForeignKey(x => x.IdMonHoc)
            .OnDelete(DeleteBehavior.Restrict); // Không cho xóa Môn học nếu còn điểm

        // Quan hệ 1-N: LopHocPhan -> BangDiemChiTiet (LHP có nhiều bản ghi điểm)
        builder.HasOne(x => x.LopHocPhan) // Dùng Navigation Property
            .WithMany(x => x.BangDiemChiTiets)
            .HasForeignKey(x => x.IdLopHocPhan)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Không xóa LHP nếu còn điểm

        // Quan hệ 1-1 (One-to-One): ChuyenDoiHocPhan -> BangDiemChiTiet (BangDiemMoi)
        // Bản ghi điểm này (BangDiemChiTiet) được tạo ra từ 1 bản ghi chuyển đổi duy nhất.
        // Đây là quan hệ từ BangDiemChiTiet (child) đến ChuyenDoiHocPhan (parent).
        builder.HasOne(x => x.ChuyenDoiHocPhan)
            .WithOne(cdhp => cdhp.BangDiemMoi) // Liên kết ngược lại: ChuyenDoiHocPhan.BangDiemMoi
            .HasForeignKey<BangDiemChiTiet>(x => x.IdChuyenDoiHocPhan)
            .IsRequired(false) // Điểm thực tế (không chuyển đổi) thì IdChuyenDoiHocPhan = NULL
            .OnDelete(DeleteBehavior.Restrict);

        // Lưu ý: Cần đảm bảo rằng trong class ChuyenDoiHocPhan đã cấu hình quan hệ BangDiemCu/BangDiemMoi
        // Đây là cấu hình cho IdChuyenDoiHocPhan tham chiếu đến Id của ChuyenDoiHocPhan.

        // --- 3. Index/Unique Constraint ---

        // Index tổng hợp: Đảm bảo mỗi lần học của 1 sinh viên/môn học là duy nhất
        builder.HasIndex(x => new { x.IdSinhVien, x.IdMonHoc, x.LanHoc })
               .IsUnique();

        // Index phụ: Tăng tốc truy vấn điểm cao nhất
        builder.HasIndex(x => new { x.IdSinhVien, x.IdMonHoc, x.IsDiemCaoNhat });
    }
}