using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TieuChuanXetHocBong : AuditableEntity
    {
        public required int STT { get; set; }
        public required string Nhom { get; set; }
        public required string HocBong { get; set; }
        public required double HocLucDiem10Tu { get; set; }
        public required double HocLucDiem10Den { get; set; }
        public double? HocLucDiem4Tu { get; set; }
        public double? HocLucDiem4Den { get; set; }
        public required double HanhKiemTu { get; set; }
        public required double HanhKiemDen { get; set; }
        public decimal? SoTien { get; set; }
        public decimal? PhanTramSoTien  { get; set; }
        public string? GhiChu { get; set; }
    }
}