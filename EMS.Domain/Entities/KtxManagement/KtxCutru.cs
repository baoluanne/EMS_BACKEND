using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxCutru : AuditableEntity
    {
        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual KtxPhong PhongKtx { get; set; } = null!;

        public Guid GiuongKtxId { get; set; }
        [ForeignKey("GiuongKtxId")]
        public virtual KtxGiuong GiuongKtx { get; set; } = null!;

        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid? IdHocKy { get; set; }
        [ForeignKey("IdHocKy")]
        public virtual HocKy? HocKy { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayRoiKtx { get; set; }

        public KtxCutruTrangThai TrangThai { get; set; } = KtxCutruTrangThai.DangO;

        public string? GhiChu { get; set; }

        [NotMapped]
        public string ThoiGianLuuTru => (HocKy != null && HocKy.TuNgay.HasValue && HocKy.DenNgay.HasValue)
            ? $"Từ {HocKy.TuNgay.Value:MM/yyyy} đến {HocKy.DenNgay.Value:MM/yyyy}"
            : string.Empty;
    }
}