using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.StudentManagement
{
    public class TiepNhanHoSoSv : AuditableEntity
    {
        // sinh vien
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        // ho so
        public Guid IdHoSoSV { get; set; }
        public HoSoSV? HoSoSV { get; set; }

        public string? GhiChu { get; set; }

        public Guid? IdNguoiTiepNhan { get; set; }
        public NguoiDung? NguoiTiepNhan { get; set; }
        public Guid? IdNguoiXuLy { get; set; }
        public NguoiDung? NguoiXuLy { get; set; }

        public DateTime? NgayTiepNhan { get; set; }
        public DateTime? NgayXuLy { get; set; }

        public TrangThaiHoSoEnum TrangThai { get; set; } = TrangThaiHoSoEnum.ChoDuyet;
        public string? LyDoTuChoi { get; set; }

        public bool? InBienNhan { get; set; } = false;
        public bool? XemIn { get; set; } = false;
        public int? SoBanIn { get; set; } = 0;

        public string? MaVach { get; set; }
        public decimal? CongNoHocPhi { get; set; }
        public decimal? KhoanThuKhac { get; set; }
    }
}