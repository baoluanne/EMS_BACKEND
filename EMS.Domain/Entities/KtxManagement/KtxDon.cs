using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDon : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        [ForeignKey("IdSinhVien")]
        public virtual SinhVien SinhVien { get; set; } = null!;

        public Guid IdHocKy { get; set; }
        [ForeignKey("IdHocKy")]
        public virtual HocKy HocKy { get; set; } = null!;

        public string? MaDon { get; set; }
        public string? LoaiDon { get; set; }
        public string? TrangThai { get; set; }

        public DateTime NgayGuiDon { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public DateTime? NgayOThucTe { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<KtxDonChiTiet> DonKtxChiTiets { get; set; } = new List<KtxDonChiTiet>();
        public virtual ICollection<KtxDonPhongGiuong> DonKtxPhongGiuongs { get; set; } = new List<KtxDonPhongGiuong>();
        public virtual ICollection<KtxCutru> CuTruKtxs { get; set; } = new List<KtxCutru>();
    }
}