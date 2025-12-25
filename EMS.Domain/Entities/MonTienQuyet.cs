using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class MonTienQuyet : AuditableEntity
    {
        public required Guid IdMonHoc { get; set; } // Môn học đang được xét
        public required Guid IdMonTienQuyet { get; set; } // Môn học phải hoàn thành trước

        public decimal? YeuCauDiemToiThieu { get; set; } // Điểm tối thiểu (Ví dụ: 5.0 hoặc điểm C)
        public string? GhiChu { get; set; }

        public MonHoc? MonHoc { get; set; } // (Môn hiện tại)
        public MonHoc? MonHocTienQuyet { get; set; } // (Môn tiên quyết)
    }
}
