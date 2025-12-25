using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyChe_NienChe : AuditableEntity
    {
        public required Guid IdQuyCheHocVu { get; set; }
        public required QuyCheHocVu? QuyCheHocVu { get; set; }
        public decimal? HeSoDiemLT { get; set; }
        public decimal? HeSoDiemTH { get; set; }
        public bool IsTinhTheoDiemLT { get; set; }
        public bool IsCotDiemKTTK { get; set; }
        public decimal? CotDiemKTTK { get; set; }
        public bool IsRangBuocDiemTK { get; set; }
        public decimal? DDDS_DiemThuongKy { get; set; }
        public decimal? DDDS_DiemTBMon { get; set; }
        public decimal? DDDS_DiemThiTotNghiep { get; set; }
        public decimal? DDDS_DiemTBTK { get; set; }
        public decimal? DDDS_DiemTBHK { get; set; }
        public decimal? DDDS_DiemTBTN { get; set; }
        public decimal? DDDS_DiemKTMon { get; set; }
        public decimal? DDDS_DiemTBChung { get; set; }
        public decimal? DDDS_DiemToanKhoa { get; set; }
        public bool DKDT_IsDaDongHP { get; set; }
        public bool DKDT_IsDTBThuongKy { get; set; }
        public decimal? DKDT_DTBThuongKy { get; set; }
        public bool DKDT_IsKhongVangQua { get; set; }
        public decimal? DKDT_PTTongVang { get; set; }
        public decimal? DKDT_PTLyThuyet { get; set; }
        public decimal? DKDT_PTThucHanh { get; set; }
        public decimal? DKTH_DiemThoiHocMoiHK { get; set; }
        public decimal? DKTH_SoDVHTKhongDatHK { get; set; }
        public decimal? DKTH_DiemTLNam2 { get; set; }
        public decimal? DKTH_SoDVHTKhongDatN2 { get; set; }
        public decimal? DKTH_DiemTLNam3 { get; set; }
        public decimal? DKTH_SoDVHTKhongDatN3 { get; set; }
        public bool DKTH_IsXetHanhKiem { get; set; }
        public float? DKTH_SoNamXetHanhKiem { get; set; }
        public bool DKTH_IsAutoCheckDongHP { get; set; }
        public decimal? HB_DiemTB { get; set; }
        public decimal? HB_DiemHK { get; set; }
        public decimal? HB_DiemTBToiThieu { get; set; }
        public decimal? DH_DiemTB { get; set; }
        public decimal? DH_DiemHanhKiem { get; set; }
        public decimal? DKHT_DTBHocKy { get; set; }
        public decimal? DKHT_SoDVHTKhongDatHK { get; set; }
        public decimal? DKHT_DTBNam { get; set; }
        public decimal? DKHT_SoDVHTKhongDatN { get; set; }
        public decimal? DKHT_DiemTichLuyN2 { get; set; }
        public decimal? DKHT_SoDVHTKhongDatN2 { get; set; }
        public decimal? DKHT_DiemTichLuyN3 { get; set; }
        public decimal? DKHT_SoDVHTKhongDatN3 { get; set; }
    }
}
