using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HinhThucThi : AuditableEntity
    {
        public required string MaHinhThucThi { get; set; }
        public required string TenHinhThucThi { get; set; }
        public int? STT { get; set; }
        public decimal? HeSoChamThi { get; set; }
        public int? SoGiangVien { get; set; }
        public string? GhiChu { get; set; }
        public Guid? IdBieuMauDanhSachDuThi { get; set; }
        public DanhMucBieuMau? BieuMauDanhSachDuThi { get; set; }
        
        
    }
}
