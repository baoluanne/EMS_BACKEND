using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxViPhamNoiQuy : AuditableEntity
    {
        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;

        public string NoiDungViPham { get; set; } = string.Empty;
        public string? HinhThucXuLy { get; set; }
        public int DiemTru { get; set; }
        public DateTime NgayViPham { get; set; }
    }
}