using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities
{
    public class DanhMucBieuMau : AuditableEntity
    {
        public required string MaBieuMau { get; set; }
        public required string TenBieuMau { get; set; }
        public required LoaiFile LoaiFile { get; set; }
        public string? GhiChu { get; set; }

        public Guid IdKhoaQuanLy { get; set; }
        public Khoa? KhoaQuanLy { get; set; }
    }
}