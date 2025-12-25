using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyetDinh: AuditableEntity
    {
        public required string SoQuyetDinh { get; set; }
        public required string TenQuyetDinh { get; set; }
        public DateTime? NgayRaQuyetDinh { get; set; }
        public string? NguoiRaQD { get; set; }
        
        public DateTime? NgayKyQuyetDinh { get; set; }
        public string? NguoiKyQD { get; set; }
       
        public Guid? IdLoaiQuyetDinh { get; set; }
        public LoaiQuyetDinh? LoaiQuyetDinh { get; set; }
        
        public string? NoiDung { get; set; }
    }
}