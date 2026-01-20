using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Enums;

namespace EMS.Application.Services.KtxService
{
    public class DonKtxRequest
    {
        public Guid IdSinhVien { get; set; }
        public Guid IdHocKy { get; set; }
        public KtxLoaiDon LoaiDon { get; set; }
        public Guid? IdGoiDichVu { get; set; }
        public string? GhiChu { get; set; }

        public DangKyMoiDetail? DangKyMoi { get; set; }
        public ChuyenPhongDetail? ChuyenPhong { get; set; }
        public GiaHanDetail? GiaHan { get; set; }
        public RoiKtxDetail? RoiKtx { get; set; }
    }

    public class DangKyMoiDetail
    {
        public Guid PhongYeuCauId { get; set; }
        public Guid? GiuongYeuCauId { get; set; }
        public string? LyDo { get; set; }
    }

    public class ChuyenPhongDetail
    {
        public Guid PhongHienTaiId { get; set; }
        public Guid GiuongHienTaiId { get; set; }
        public Guid PhongYeuCauId { get; set; }
        public string? LyDoChuyenPhong { get; set; }
    }

    public class GiaHanDetail
    {
        public Guid PhongHienTaiId { get; set; }
        public Guid GiuongHienTaiId { get; set; }
        public string? LyDo { get; set; }
    }

    public class RoiKtxDetail
    {
        public Guid PhongHienTaiId { get; set; }
        public Guid GiuongHienTaiId { get; set; }
        public string LyDoRoi { get; set; } = string.Empty;
    }
    public class RejectRequestDto
    {
        public string GhiChu { get; set; } = string.Empty;
    }
}
