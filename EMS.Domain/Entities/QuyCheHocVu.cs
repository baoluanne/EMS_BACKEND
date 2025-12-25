using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyCheHocVu : AuditableEntity
    {
        public required string MaQuyChe { get; set; }
        public required string TenQuyChe { get; set; }
        public string? BieuThuc { get; set; }
        public bool IsNienChe { get; set; }
        public string? GhiChu { get; set; }
        public bool DKDT_IsDongHocPhi { get; set; }
        public bool DKDT_IsDiemTBTK { get; set; }
        public decimal? DKDT_DiemTBTK { get; set; }
        public bool DKDT_IsDiemTBTH { get; set; }
        public decimal? DKDT_DiemTBTH { get; set; }
        public bool DKDT_IsKhongVangQua { get; set; }
        public decimal? DKDT_TongTietVang { get; set; }
        public decimal? DKDT_LyThuyet { get; set; }
        public decimal? DKDT_ThucHanh { get; set; }
        public decimal? DKDT_DuocThiLai { get; set; }
        public decimal? DDDS_DiemThanhPhan { get; set; }
        public decimal? DDDS_DiemCuoiKy { get; set; }
        public decimal? DDDS_DiemTBThuongKy { get; set; }
        public decimal? DDDS_DiemTBTH { get; set; }
        public decimal? DDDS_DiemTB { get; set; }
        public decimal? DDDS_DiemTBHK { get; set; }
        public decimal? DDDS_DiemTN { get; set; }
        public decimal? DDDS_DiemTK { get; set; }
        public string? DDDS_KieuLamTron { get; set; }
    }
}
