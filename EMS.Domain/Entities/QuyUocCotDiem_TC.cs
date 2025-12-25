using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyUocCotDiem_TC : AuditableEntity
    {
        public required string TenQuyUoc { get; set; }
        public QuyChe_TinChi? QuyChe_TinChi { get; set; } // But need to require in the UI and validation
        public required Guid IdQuyChe_TinChi { get; set; }
        public KieuMonHoc? KieuMon { get; set; }
        public required Guid IdKieuMon { get; set; }
        public Guid? IdKieuLamTron { get; set; }
        public KieuLamTron? KieuLamTron { get; set; }
        public bool? IsKhongTinhTBC { get; set; }
        public decimal? DiemTBC { get; set; }
        public bool? IsChiDiemCuoiKy { get; set; }
        public bool? IsChiDanhGia { get; set; }
        public bool? IsXetDuThiGiuaKy { get; set; }
        public bool? IsSuDung { get; set; }
        public decimal? ChuyenCan { get; set; }
        public decimal? ThuongXuyen1 { get; set; }
        public decimal? ThuongXuyen2 { get; set; }
        public decimal? ThuongXuyen3 { get; set; }
        public decimal? ThuongXuyen4 { get; set; }
        public decimal? ThuongXuyen5 { get; set; }
        public decimal? TieuLuan_BTL { get; set; }
        public decimal? CuoiKy { get; set; }
        public int? SoCotDiemTH { get; set; }
        public bool? IsHSLTTH_TC { get; set; }
        public decimal? HeSoTH { get; set; }
        public decimal? HeSoLT { get; set; }
        public bool? IsDiemRangBuocCK { get; set; }
        public decimal? DiemRangBuocCK { get; set; }
        public decimal? DRB_CotDiemGK { get; set; } // Điểm ràng buộc - Cột điểm Giữa kỳ
        public decimal? DRB_CotDiemCC { get; set; } // Điểm ràng buộc - Cột điểm chuyên cần
        public decimal? DRB_DiemThuongKy { get; set; }
        public decimal? DRB_DiemGiuaKy { get; set; }
        public string? DRB_CongThucTinhDTB_TK { get; set; } // Công thức tính điểm trung bình thường kỳ
        public string? DRB_GhiChu { get; set; }
        public decimal? DRB_DiemChuyenCan { get; set; }
        public decimal? DRB_DiemTieuLuan { get; set; }
        public decimal? DRB_ThangDiemMax { get; set; }
    }
}