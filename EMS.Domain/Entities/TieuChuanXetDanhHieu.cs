using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
        public class TieuChuanXetDanhHieu : AuditableEntity
        {
            public int? STT { get; set; }
            public string? NhomDanhHieu { get; set; }
            public required double HocLuc10Tu { get; set; }
            public required double HocLuc10Den { get; set; }
            public double? HocLuc4Tu { get; set; }
            public double? HocLuc4Den { get; set; }
            public required double HanhKiemTu { get; set; }
            public required double HanhKiemDen { get; set; }
            public string? GhiChu { get; set; }
        }
}