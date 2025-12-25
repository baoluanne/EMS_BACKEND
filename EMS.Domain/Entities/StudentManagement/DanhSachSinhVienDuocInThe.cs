using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.StudentManagement
{
    public class DanhSachSinhVienDuocInThe: AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien SinhVien { get; set; }
        public bool CoHinhTheSv { get; set; }
        public DateTime? NgayImportHinhTheSv { get; set; }
    }
}
