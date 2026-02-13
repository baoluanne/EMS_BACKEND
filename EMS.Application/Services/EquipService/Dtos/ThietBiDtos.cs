using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Application.Services.EquipService.Dtos
{
    public class NhapHangLoatDto
    {
        public int SoLuong { get; set; }
        public string TenThietBi { get; set; }
        public Guid LoaiThietBiId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public string Model { get; set; }
        public string ThongSoKyThuat { get; set; }
        public int? NamSanXuat { get; set; }
        public DateTime? NgayMua { get; set; }
        public DateTime? NgayHetHanBaoHanh { get; set; }
        public decimal? NguyenGia { get; set; }
        public decimal? GiaTriKhauHao { get; set; }
        public TrangThaiThietBiEnum TrangThai { get; set; } = TrangThaiThietBiEnum.MoiNhap;
        public string GhiChu { get; set; }
        public Guid? PhongHocId { get; set; }
        public string PrefixMaThietBi { get; set; }
    }
    public class MobileScanResult
    {
        public Guid Id { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string HinhAnhUrl { get; set; }
        public string TrangThaiText { get; set; }
        public int TrangThaiCode { get; set; }
        public string ViTri { get; set; } // Hiển thị: "Trong kho", "Phòng học", v.v.

        // Các cờ cho phép (Backend quyết định logic này)
        public bool AllowMuon { get; set; }
        public bool AllowTra { get; set; }
        public bool AllowThanhLy { get; set; }
    }
    public class MobileBorrowRequest
    {
        public Guid ThietBiId { get; set; }
        public string MaDoiTuong { get; set; }
        private DateTime _ngayMuon;
        public DateTime NgayMuon
        {
            get => _ngayMuon;
            // Ép Kind thành Utc để không làm thay đổi giá trị giờ nhưng đúng chuẩn Postgres
            set => _ngayMuon = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
