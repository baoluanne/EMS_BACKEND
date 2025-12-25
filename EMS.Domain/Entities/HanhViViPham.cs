using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HanhViViPham : AuditableEntity
    {
        public required string MaHanhVi { get; set; }
        public required string TenHanhVi { get; set; }
        public int? DiemTru { get; set; }
        public string? NoiDung { get; set; }
        public int? DiemTruToiDa { get; set; }
        public bool IsViPhamNoiTru { get; set; }
        public bool IsKhongSuDung { get; set; }
        public int? MucDo { get; set; }
        public string? GhiChu { get; set; }
        public Guid IdLoaiHanhVi { get; set; }
        public LoaiHanhViViPham? LoaiHanhVi { get; set; }
    }
}