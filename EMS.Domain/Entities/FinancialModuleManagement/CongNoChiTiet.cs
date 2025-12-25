using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    public class CongNoChiTiet : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CongNoId { get; set; }
        public Guid LoaiKhoanThuId { get; set; } 

        public decimal SoTien { get; set; }
        public string? GhiChu { get; set; } 

        public CongNoSinhVien CongNo { get; set; } = null!;
    }
}