using EMS.Domain.Enums;

namespace EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices.Dtos
{
    public class CapNhatTrangThaiSinhVien
    {
        public TrangThaiSinhVienEnum TrangThaiMoi { get; set; }
        public string SoQuyetDinh { get; set; } = string.Empty;
        public DateTime NgayRaQuyetDinh { get; set; }
        public Guid IdLoaiQuyetDinh { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? NgayTao { get; set; }

        public List<string> IdSinhViens { get; set; } = [];
    }
}
