using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TinhChatMonHoc : AuditableEntity
    {
        public required string MaTinhChatMonHoc { get; set; }
        public required string TenTinhChatMonHoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
