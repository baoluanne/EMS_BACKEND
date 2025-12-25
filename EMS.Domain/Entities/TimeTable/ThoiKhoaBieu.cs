using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Domain.Entities.TimeTable
{
    public class ThoiKhoaBieu: AuditableEntity
    {
        public required Guid IdLopHocPhan { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }
        
        public Guid? IdPhongHoc { get; set; }
        public PhongHoc? PhongHoc { get; set; }
        
        public Guid? IdGiangVien { get; set; }
        public GiangVien? GiangVien { get; set; }
        
        [Range(2, 8)]
        public required int Thu { get; set; }
        
        [Range(1, 50)]
        public required int TietBatDau  { get; set; }
        
        [Range(1, 50)]
        public required int SoTiet { get; set; }

        public string? TuanHoc { get; set; }
        
        public string? GhiChu { get; set; }
    }
}