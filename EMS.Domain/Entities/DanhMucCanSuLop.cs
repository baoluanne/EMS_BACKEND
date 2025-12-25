using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucCanSuLop: AuditableEntity
    {
        public required string MaChucVu { get; set; }
        public required string TenChucVu { get; set; }
        public bool HoatDongDoan  { get; set; } = false;
        public Guid? IdLoaiChucVu { get; set; }
        public LoaiChucVu? LoaiChucVu { get; set; }
        public string? TenTiengAnh { get; set; }
        public float? DiemCong { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}