using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.ClassManagement
{
    public class ChuyenDoiHocPhan : AuditableEntity
    {
        public required Guid IdChuyenLop { get; set; }
        public ChuyenLop? ChuyenLop { get; set; }

        public required Guid IdMonHocCu { get; set; }
        public MonHoc? MonHocCu { get; set; }

        public decimal DiemCu { get; set; } // Lấy từ BangDiemChiTiet.DiemTongKet của môn cũ
        public int TinChiCu { get; set; } // Số tín chỉ của môn cũ
        public Guid? IdBangDiemCu { get; set; }
        public BangDiemChiTiet? BangDiemCu { get; set; }

        // Thông tin môn học ĐÍCH (New Subject)
        public required Guid IdMonHocMoi { get; set; }
        public MonHoc? MonHocMoi { get; set; }
        public int TinChiMoi { get; set; } // Số tín chỉ của môn mới

        // Tham chiếu đến bản ghi điểm MỚI được tạo ra (trong BangDiemChiTiet)
        public Guid? IdBangDiemMoi { get; set; }
        public BangDiemChiTiet? BangDiemMoi { get; set; }


        public PhanLoaiChuyenLopEnum PhanLoai { get; set; }
        public decimal? DiemChuyenDoiDuocApDung { get; set; } // Điểm được áp dụng sau khi chuyển đổi (nếu có)
        // Ghi chú và Trạng thái duyệt
        public string? GhiChu { get; set; }
        public bool IsDaThucThi { get; set; } // Đã thực thi/ghi điểm vào BangDiemChiTiet
    }
}
