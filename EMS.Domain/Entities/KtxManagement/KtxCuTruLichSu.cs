using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxCuTruLichSu : AuditableEntity
    {
        public Guid CuTruId { get; set; }
        [ForeignKey("CuTruId")]
        public virtual KtxCutru? CuTru { get; set; } = null!;

        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; } = null!;

        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon? DonKtx { get; set; } = null!;

        public KtxLoaiDon LoaiDon { get; set; }

        public Guid? PhongCuId { get; set; }
        [ForeignKey("PhongCuId")]
        public virtual KtxPhong? PhongCu { get; set; }

        public Guid? GiuongCuId { get; set; }
        [ForeignKey("GiuongCuId")]
        public virtual KtxGiuong? GiuongCu { get; set; }

        public Guid PhongMoiId { get; set; }
        [ForeignKey("PhongMoiId")]
        public virtual KtxPhong? PhongMoi { get; set; } = null!;

        public Guid GiuongMoiId { get; set; }
        [ForeignKey("GiuongMoiId")]
        public virtual KtxGiuong? GiuongMoi { get; set; } = null!;

        public Guid? IdHocKy { get; set; }
        [ForeignKey("IdHocKy")]
        public virtual HocKy? HocKy { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayRoiDuKien { get; set; }
        public DateTime? NgayRoiThucTe { get; set; }

        public KtxCutruTrangThai TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public DateTime NgayGhiLichSu { get; set; }
    }
}