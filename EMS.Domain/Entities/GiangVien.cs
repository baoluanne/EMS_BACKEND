using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class GiangVien : AuditableEntity
    {
        public required string MaGiangVien { get; set; }
        public required string HoDem { get; set; }
        public required string Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public required Guid IdLoaiGiangVien { get; set; }
        public LoaiGiangVien? LoaiGiangVien { get; set; }
        public required Guid IdKhoa { get; set; }
        public Khoa? Khoa { get; set; }
        public Guid? IdHocVi { get; set; }
        public HocVi? HocVi { get; set; }
        public Guid? IDToBoMon { get; set; }
        public ToBoMon? ToBoMon { get; set; }
        public string? TenVietTat { get; set; }
        public decimal? HSGV_LT { get; set; }
        public decimal? HSGV_TH { get; set; }
        public string? PhuongTien { get; set; }
        public DateTime? NgayChamDutHopDong { get; set; }
        public bool? IsCoiThi { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsKhongChamCong { get; set; }
        public bool? IsChamDutHopDong { get; set; }
    }
} 