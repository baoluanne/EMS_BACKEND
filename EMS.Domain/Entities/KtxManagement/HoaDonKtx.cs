using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class HoaDonKtx : AuditableEntity
    {
        public Guid Id { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public decimal TienDien { get; set; }
        public decimal TienNuoc { get; set; }
        public decimal TienPhong { get; set; }
        public decimal PhuPhi { get; set; }
        public decimal TongTien { get; set; }

        public string TrangThai { get; set; } = "ChuaThanhToan";
        public DateTime? NgayThanhToan { get; set; }
        public string? GhiChu { get; set; }

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual PhongKtx? PhongKtx { get; set; }

        public Guid? ChiSoDienNuocId { get; set; }
        [ForeignKey("ChiSoDienNuocId")]
        public virtual ChiSoDienNuoc? ChiSoDienNuoc { get; set; }
        public virtual ICollection<YeuCauSuaChua> YeuCauSuaChuas { get; set; } = new List<YeuCauSuaChua>();
    }
}