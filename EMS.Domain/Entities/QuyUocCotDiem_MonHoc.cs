using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyUocCotDiem_MonHoc : AuditableEntity
    {
        public Guid IdQuyUocCotDiem_NC { get; set; }  // But check it as required in the UI and validation
        public QuyUocCotDiem_NC QuyUocCotDiem_NC { get; set; }
        public Guid IdQuyUocCotDiem_TC { get; set; }  // But check it as required in the UI and validation
        public QuyUocCotDiem_TC QuyUocCotDiem_TC { get; set; }
        public required Guid IdMonHocBacDaoTao { get; set; }
        public MonHocBacDaoTao MonHocBacDaoTao { get; set; }
        public required Guid IdTrangThaiXetQuyUoc { get; set; }
        public TrangThaiXetQuyUoc TrangThaiXetQuyUoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
