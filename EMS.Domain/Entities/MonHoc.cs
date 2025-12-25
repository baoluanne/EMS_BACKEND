using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class MonHoc : AuditableEntity
    {
        public required string MaMonHoc { get; set; }
        public required string TenMonHoc { get; set; }
        public string? MaTuQuan { get; set; }
        public string? TenTiengAnh { get; set; }
        public string? TenVietTat { get; set; }
        public string? GhiChu { get; set; }
        public bool? IsKhongTinhTBC { get; set; }
        public required Guid IdLoaiMonHoc { get; set; }
        public LoaiMonHoc? LoaiMonHoc { get; set; }
        public required Guid IdKhoa { get; set; }
        public Khoa? Khoa { get; set; }
        public Guid? IdToBoMon { get; set; }
        public ToBoMon? ToBoMon { get; set; }
        public Guid? IdLoaiTiet { get; set; }
        public LoaiTiet? LoaiTiet { get; set; }
        public Guid? IdKhoiKienThuc { get; set; }
        public KhoiKienThuc? KhoiKienThuc { get; set; }
        public Guid? IdTinhChatMonHoc { get; set; }
        public TinhChatMonHoc? TinhChatMonHoc { get; set; }

        public float SoTinChi { get; set; }

        public virtual ICollection<MonTienQuyet>? MonHocCanCoTienQuyet { get; set; }
        public virtual ICollection<MonTienQuyet>? CacMonSuDungLamTienQuyet { get; set; }
        public virtual ICollection<MonHocBacDaoTao> MonHocBacDaoTaos { get; set; } = new List<MonHocBacDaoTao>();
        public virtual ICollection<BangDiemChiTiet> BangDiemChiTiets { get; set; } = new List<BangDiemChiTiet>();
    }
}
