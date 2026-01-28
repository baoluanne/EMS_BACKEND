using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxViPhamNoiQuy : AuditableEntity
    {
        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; } = null!;

        public Guid? CuTruId { get; set; }
        [ForeignKey("CuTruId")]
        public virtual KtxCutru? CuTru { get; set; }

        public Guid? IdHocKy { get; set; }
        [ForeignKey("IdHocKy")]
        public virtual HocKy? HocKy { get; set; }

        public string MaBienBan { get; set; } = string.Empty;
        public LoaiViPhamNoiQuy LoaiViPham { get; set; }
        public int DiemTru { get; set; }
        public int LanViPham { get; set; }
        public DateTime NgayViPham { get; set; }
    }
}