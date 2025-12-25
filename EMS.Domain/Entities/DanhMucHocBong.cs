using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucHocBong : AuditableEntity
    {
        public required string MaDanhMuc { get; set; }
        public required string TenDanhMuc { get; set; }
        public int? STT { get; set; }
    }
}