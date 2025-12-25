using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class BacDaoTao : AuditableEntity
    {
        public required string MaBacDaoTao { get; set; }
        public required string TenBacDaoTao { get; set; }
        public string? DaoTaoMonVanHoa { get; set; }
        public string? HinhThucDaoTao { get; set; }
        public string? KyTuMaSinhVien { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
        public string? KyTuMaHoSoTuyenSinh { get; set; }
        public string? TenTiengAnh { get; set; }
        public bool? IsVisible { get; set; }
        public string? TenLoaiBangCapTN { get; set; }
        public string? TenLoaiBangCapTN_ENG { get; set; }
        public string? PhongBanKyBM { get; set; }
    }
}