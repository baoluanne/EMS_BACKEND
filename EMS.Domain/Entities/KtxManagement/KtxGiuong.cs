using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxGiuong : AuditableEntity
    {
        public string? MaGiuong { get; set; }

        public Guid? SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; }

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual KtxPhong? Phong { get; set; } = null!;

        public KtxGiuongTrangThai TrangThai { get; set; } = KtxGiuongTrangThai.Trong;

        public virtual ICollection<KtxCutru> CuTruKtxs { get; set; } = new List<KtxCutru>();

        [NotMapped]
        public KtxCutru? HopDongHienTai => CuTruKtxs
            .FirstOrDefault(c => c.TrangThai == KtxCutruTrangThai.DangO && c.NgayRoiKtx >= DateTime.Now);

        [NotMapped]
        public string TrangThaiDisplay => TrangThai switch
        {
            KtxGiuongTrangThai.Trong => "Trống",
            KtxGiuongTrangThai.DaCoNguoi => "Đã có người",
            _ => "Không xác định"
        };
        [NotMapped]
        public string MaGiuongDisplay
        {
            get
            {
                if (Phong == null)
                    return "Chưa có thông tin phòng";

                var maPhongDisplay = Phong.MaPhongDisplay; // Dùng property ở trên
                var maGiuongFormatted = string.IsNullOrEmpty(MaGiuong)
                    ? ""
                    : (int.TryParse(MaGiuong.Trim(), out int num) ? num.ToString("D2") : MaGiuong.PadLeft(2, '0'));

                return $"{maPhongDisplay}-{maGiuongFormatted}";
            }
        }
        [NotMapped]
        public string ThongTinHopDongHienTai => HopDongHienTai != null
            ? $"{HopDongHienTai.SinhVien?.HoDem +" " +HopDongHienTai.SinhVien?.Ten} - Từ {HopDongHienTai.NgayBatDau:dd/MM/yyyy} đến {HopDongHienTai.NgayRoiKtx:dd/MM/yyyy}"
            : "Không có hợp đồng";
    }
}