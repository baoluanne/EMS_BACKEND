using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using static ClosedXML.Excel.XLPredefinedFormat;
using DateTime = System.DateTime;

namespace EMS.Domain.Entities.KtxManagement
{
    public class DonKtx : AuditableEntity
    {
        public readonly object PhongMuonChuyenNav;

        [Key]
        public Guid Id { get; set; }

        public Guid IdSinhVien { get; set; }

        public string? MaDon { get; set; }

        public string? LoaiDon { get; set; }

        public string? TrangThai { get; set; }

        public DateTime NgayGuiDon { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayHetHan { get; set; }

        public string? Ghichu { get; set; }

        public Guid? PhongHienTai { get; set; }

        public Guid? phongMuonChuyen { get; set; }

        public string? LyDoChuyen { get; set; }

        public Guid? PhongDuocDuyet { get; set; }

        public Guid? GiuongDuocDuyet { get; set; }

        [ForeignKey("IdSinhVien")]
        public virtual SinhVien? SinhVien { get; set; }

        [ForeignKey("PhongDuocDuyet")]
        public virtual PhongKtx? PhongKtx { get; set; }

        [ForeignKey("PhongHienTai")]
        public virtual PhongKtx? PhongHienTainav { get; set; }

        [ForeignKey("phongMuonChuyen")]
        public virtual PhongKtx? PhongMongMuonnav { get; set; }

        [ForeignKey("GiuongDuocDuyet")]
        public virtual GiuongKtx? GiuongKtx { get; set; }

        public virtual ICollection<CuTruKtx> CuTruKtxs { get; set; } = new List<CuTruKtx>();
    }
}
