using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDon : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        [ForeignKey("IdSinhVien")]
        public virtual SinhVien? SinhVien { get; set; } = null!;

        public Guid IdHocKy { get; set; }
        [ForeignKey("IdHocKy")]
        public virtual HocKy? HocKy { get; set; } = null!;

        public string? MaDon { get; set; }
        public KtxLoaiDon LoaiDon { get; set; } = KtxLoaiDon.DangKyMoi;
        public KtxDonTrangThai TrangThai { get; set; } = KtxDonTrangThai.ChoDuyet;

        public DateTime NgayGuiDon { get; set; }
        public DateTime NgayDuyet { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }

        public Guid? IdGoiDichVu { get; set; }
        [ForeignKey("IdGoiDichVu")]
        public virtual DanhMucKhoanThuNgoaiHocPhi? GoiDichVu { get; set; }

        public Guid? PhongDuocDuyetId { get; set; }
        [ForeignKey("PhongDuocDuyetId")]
        public virtual KtxPhong? PhongDuocDuyet { get; set; }

        public Guid? GiuongDuocDuyetId { get; set; }
        [ForeignKey("GiuongDuocDuyetId")]
        public virtual KtxGiuong? GiuongDuocDuyet { get; set; }

        public string? GhiChu { get; set; }

        public virtual ICollection<KtxDonChiTiet> DonKtxChiTiets { get; set; } = new List<KtxDonChiTiet>();
        public virtual KtxDonDangKyMoi? DangKyMoi { get; set; }
        public virtual KtxDonGiaHan? GiaHan { get; set; }
        public virtual KtxDonChuyenPhong? ChuyenPhong { get; set; }
        public virtual KtxDonRoiKtx? RoiKtx { get; set; }
    }
}