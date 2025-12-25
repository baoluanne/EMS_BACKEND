using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HTXLViPhamQCThi : AuditableEntity
    {
        public required string MaXLQC { get; set; }
        public required string TenXLQC { get; set; }
        public int? PhanTramDiemTru { get; set; }
        public int? MucDo { get; set; }
        public int? DiemTruRL { get; set; }
        public string? GhiChu { get; set; }
    }
}