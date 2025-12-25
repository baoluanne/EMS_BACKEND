using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities
{
    public class DanhMucKhoanThuTuDo: AuditableEntity
    {
        public required string MaKhoanThu { get; set; }
        public required string TenKhoanThu { get; set; }
        public double? SoTien { get; set; }
        public int? STT { get; set; }
        public Guid IdLoaiKhoanThu { get; set; }
        public LoaiKhoanThu? LoaiKhoanThu { get; set; }
        
        public double? ThueVAT  { get; set; }
        public bool GomThueVAT { get; set; } = false;
        public bool IsVisible { get; set; } = false;
        public DonViTinh? DonViTinh { get; set; }
        public string? GhiChu { get; set; }


    }
}