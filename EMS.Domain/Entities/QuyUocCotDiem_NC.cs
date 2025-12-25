using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyUocCotDiem_NC : AuditableEntity
    {
        public required string TenQuyUoc { get; set; }
        public QuyChe_NienChe? QuyChe_NienChe { get; set; }
        public required Guid IdQuyChe_NienChe { get; set; }
        public KieuMonHoc? KieuMon { get; set; } 
        public required Guid IdKieuMon { get; set; }
        public Guid? IdKieuLamTron { get; set; }
        public KieuLamTron? KieuLamTron { get; set; }
        public bool? IsKhongTinhTBC { get; set; }
        public decimal? DiemTBC { get; set; }
        public bool? IsChiDiemCuoiKy { get; set; }
        public bool? IsChiDanhGia { get; set; }
        public bool? IsSuDung { get; set; }
        public decimal? ChuyenCan { get; set; }
        public decimal? ThuongXuyen1 { get; set; }
        public decimal? ThuongXuyen2 { get; set; }
        public decimal? ThuongXuyen3 { get; set; }
        public decimal? ThuongXuyen4 { get; set; }
        public decimal? ThuongXuyen5 { get; set; }
        public int? SoCotChuyenCan { get; set; }
        public int? SoCotThucHanh   { get; set; }
        public bool? HeSoTheoDVHT { get; set; }
        public int? SoCotLTHS1 { get; set; }
        public int? SoCotLTHS2 { get; set; }
        public int? SoCotLTHS3 { get; set; }
        public int? SoCotTHHS1 { get; set; }
        public int? SoCotTHHS2 { get; set; }
        public int? SoCotTHHS3 { get; set; }
        public decimal? HeSoTBTK { get; set; }
        public decimal? HeSoCK { get; set; }
        public bool? HeSoTheoLTTH_TC { get; set; } // Hệ số theo lý thuyết thực hành tín chỉ
        public decimal? HeSoLT { get; set; }
        public decimal? HeSoTH   { get; set; }
        public bool? IsApDungQuyCheNghe { get; set; }
        public bool? IsApDungQuyCheMonVH { get; set; }
        public bool? IsRangBuocDCK { get; set; }
        public decimal? DiemRangBuocCK { get; set; }
        public bool? IsXetDuThiGK { get; set; }
        public bool? IsKhongApDungHSCD { get; set; } // Hệ số cột điểm
        public decimal? DRB_CotDiemGK { get; set; } // Điểm ràng buộc - Cột điểm Giữa kỳ
        public decimal? DRB_CotDiemCC { get; set; } // Điểm ràng buộc - Cột điểm chuyên cần
        public decimal? DRB_DiemThuongKy { get; set; }
        public decimal? DRB_DiemGiuaKy { get; set; }
        public decimal? DRB_DiemChuyenCan { get; set; }
        public decimal? DRB_DiemTieuLuan { get; set; }
        public int? SoCotDiemGK { get; set; }
        public int? SoCotDiemCC { get; set; }
        public string? DRB_CongThucTinhDTB_TK { get; set; } // Công thức tính điểm trung bình thường kỳ
        public string? DRB_GhiChu { get; set; }
        public decimal? DRB_ThangDiemMax { get; set; }
    }
}