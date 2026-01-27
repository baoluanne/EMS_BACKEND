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
        public KtxCutru? HopDongHienTai => CuTruKtxs?.FirstOrDefault(c => c.TrangThai == KtxCutruTrangThai.DangO);
        [NotMapped]
        public string TrangThaiDisplay => TrangThai == KtxGiuongTrangThai.Trong ? "Trống" : "Đã có người";

        [NotMapped]
        public string MaGiuongDisplay => MaGiuong ?? "N/A";

        [NotMapped]
        public string ThongTinCuTruHienTai
        {
            get
            {
                var cuTru = CuTruKtxs?.FirstOrDefault(x => x.TrangThai == 0);
                return cuTru != null
                    ? $"{cuTru.SinhVien?.HoDem} {cuTru.SinhVien?.Ten} - Từ {cuTru.NgayBatDau:dd/MM/yyyy}"
                    : "Chưa có người ở";
            }
        }
    }
}