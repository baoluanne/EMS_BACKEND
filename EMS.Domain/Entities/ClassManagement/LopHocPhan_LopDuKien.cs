using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.ClassManagement
{
    public class LopHocPhan_LopDuKien : AuditableEntity
    {
        public Guid IdLopHocPhan { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }
        public Guid IdLopDuKien { get; set; } // Id Lớp ban đầu
        public LopHoc? LopDuKien { get; set; } // Lớp ban đầu
        public string? GhiChu { get; set; }
    }
}
