using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    public class CongNoSinhVien : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }
        public Guid NamHocHocKyId { get; set; }

        public DateTime HanNop { get; set; }
        public string? GhiChu { get; set; }

        public decimal SoTienPhaiThu => ChiTiets.Sum(x => x.SoTien);

        public decimal DaThu { get; set; } = 0;

        public decimal TongMienGiam { get; set; } = 0;

        public decimal ConNo => SoTienPhaiThu - DaThu - TongMienGiam;

        public bool DaDongDu => ConNo <= 0;

        public SinhVien SinhVien { get; set; } = null!;
        public NamHoc_HocKy NamHocHocKy { get; set; } = null!;

        public ICollection<CongNoChiTiet> ChiTiets { get; set; } = new List<CongNoChiTiet>();
        public ICollection<PhieuThuSinhVien> PhieuThus { get; set; } = new List<PhieuThuSinhVien>();
        public ICollection<MienGiamSinhVien> MienGiams { get; set; } = new List<MienGiamSinhVien>();

    }
}