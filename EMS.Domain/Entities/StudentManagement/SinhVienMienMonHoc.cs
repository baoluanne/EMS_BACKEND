using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.StudentManagement
{
    public class SinhVienMienMonHoc : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        public Guid? IdQuyetDinh { get; set; }
        public QuyetDinh? QuyetDinh { get; set; }
        public required Guid IdMonHocBacDaoTao { get; set; }
        public MonHocBacDaoTao? MonHocBacDaoTao { get; set; }
    }
}