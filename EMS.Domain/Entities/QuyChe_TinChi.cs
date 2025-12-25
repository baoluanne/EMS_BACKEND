using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyChe_TinChi : AuditableEntity
    {
        public required Guid IdQuyCheHocVu { get; set; }
        public required QuyCheHocVu? QuyCheHocVu { get; set; }
        public int? SoTinhChiNoToiHT { get; set; }
        public bool IsRangBuocDKT { get; set; }
        public decimal? HeSoDiemLT { get; set; }
        public decimal? HeSoDiemTH { get; set; }
        public bool IsTinhTheoDiemLT { get; set; }
        public bool IsSoCotDiemKTTK { get; set; }
        public decimal? SoCotDiemKTTK { get; set; }
        public decimal? DDDS_DiemThuongKy { get; set; }
        public decimal? DDDS_DiemTBMon { get; set; }
        public decimal? DDDS_DiemTBChung { get; set; }
        public decimal? DDDS_DiemTKMon { get; set; }
        public decimal? DDDS_DiemTBHK { get; set; }
        public bool DKDT_DaDongHP { get; set; }
        public bool DKDT_IsDiemTBThuongKy { get; set; }
        public decimal? DKDT_DiemTBThuongKy { get; set; }
        public bool DKDT_IsDiemTBThuongXuyen { get; set; }
        public decimal? DKDT_DiemTBThuongXuyen { get; set; }
        public bool DKDT_IsDiemGiuaKy { get; set; }
        public decimal? DKDT_DiemGiuaKy { get; set; }
        public bool DKDT_IsDiemTieuLuan { get; set; }
        public decimal? DKDT_DiemTieuLuan { get; set; }
        public bool DKDT_IsKhongVangQua { get; set; }
        public decimal? DKDT_PTTongVang { get; set; }
        public decimal? DKDT_PTLyThuyet { get; set; }
        public decimal? DKDT_PTThucHanh { get; set; }
        public decimal? DKTH_DiemThoiHocMoiHK { get; set; }
        public decimal? DKTH_SoHKCanhBaoMax { get; set; }
        public decimal? DKTH_DiemHKDau { get; set; }
        public decimal? DKTH_DiemHKLienTiep { get; set; }
        public decimal? DKTH_HKLienTiep { get; set; }
        public decimal? DKTH_DiemHKTiepTheo { get; set; }
        public bool DKTH_IsXetTamNgung { get; set; }
        public decimal? DKTH_XetTamNgungTu { get; set; }
        public decimal? DKTH_XetTamNgungDen { get; set; }
        public int? DKTH_SoTNDiemF { get; set; }
        public bool DKTH_IsKiemTraNoHP { get; set; }
        public bool DKTH_IsSoLanVP { get; set; }
        public int? DKTH_SoLanVP { get; set; }
        public Guid? DKTH_IdMucDoVP { get; set; }
        public MucDoViPham? DKTH_MucDoVP { get; set; }
        public bool DKTH_IsShowGCMonHocRot { get; set; }
        public bool DKTH_IsShowGCMonHocKhac { get; set; }
        public bool HBXL_IsThangDiem10 { get; set; }
        public bool HBXL_IsDiemHaBacTu { get; set; }
        public decimal? HBXL_DiemHaBacTu { get; set; }
        public bool HBXL_IsSoLanVPKL { get; set; }
        public int? HBXL_SoLanVPKL { get; set; }
        public Guid? HBXL_IdMucDoVPKL { get; set; }
        public MucDoViPham? HBXL_MucDoVPKL { get; set; }
        public bool HBXL_IsSoLanVPQC { get; set; }
        public int? HBXL_SoLanVPQC { get; set; }
        public Guid? HBXL_IdMucDoVPQC { get; set; }
        public MucDoViPham? HBXL_MucDoVPQC { get; set; }
        public bool HBXL_IsSoMonTLHL { get; set; }
        public int? HBXL_SoMonTLHL { get; set; }
        public bool HBXL_IsTLHLChiLayMonTBC { get; set; }
        public bool HBXL_IsTLHLChiLauMonCTK { get; set; }
        public decimal? DH_DiemTB { get; set; }
        public decimal? DH_DiemHK { get; set; }
        public float? DH_SoTCDangKy { get; set; }
        public decimal? HB_DiemTrungBinh { get; set; }
        public decimal? HB_DiemTBToiThieu { get; set; }
        public decimal? HB_SoTCDangKy { get; set; }
        public decimal? HB_SoTCDKNam { get; set; }

    }
}
