using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucNoiDung: AuditableEntity
    {
        public required string LoaiNoiDung { get; set; }
        public required string NoiDung { get; set; }
        public bool IsVisible { get; set; }
    }
}