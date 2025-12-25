using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.StudentManagement
{
    public class SinhVien : AuditableEntity
    {
        public string MaHoSo { get; set; }
        public string SoBaoDanh { get; set; }
        public int? ThuTuNhanHoSo { get; set; }
        public string MaSinhVien { get; set; }
        public string MaBarcode { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public GioiTinhEnum GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DonViCuDiHoc { get; set; }
        public Guid? IdHKTTTinh { get; set; }
        public TinhThanh? HKTTTinh { get; set; }

        public Guid? IdHKTTHuyen { get; set; }
        public QuanHuyen? HKTTHuyen { get; set; }

        public Guid? IdHKTTPhuongXa { get; set; }
        public PhuongXa? HKTTPhuongXa { get; set; }

        public string? HKTTSoNhaThonXom { get; set; }

        public Guid? IdDCLLTinh { get; set; }
        public TinhThanh? DCLLTinh { get; set; }

        public Guid? IdDCLLHuyen { get; set; }
        public QuanHuyen? DCLLHuyen { get; set; }

        public Guid? IdDCLLPhuongXa { get; set; }
        public PhuongXa? DCLLPhuongXa { get; set; }

        public string? DCLLSoNhaThonXom { get; set; }

        public string? HoKhauTamTru { get; set; }
        public string? DiaChiLienLac { get; set; }

        public Guid? IdTenTinh { get; set; }
        public TinhThanh? TenTinh { get; set; }

        public Guid? IdTenHuyen { get; set; }
        public QuanHuyen? TenHuyen { get; set; }

        public Guid? IdTenPhuongXa { get; set; }
        public PhuongXa? TenPhuongXa { get; set; }

        public Guid? IdNoiSinhTinh { get; set; }
        public TinhThanh? NoiSinhTinh { get; set; }

        public Guid? IdNoiSinhHuyen { get; set; }
        public QuanHuyen? NoiSinhHuyen { get; set; }

        public Guid? IdNoiSinhPhuongXa { get; set; }
        public PhuongXa? NoiSinhPhuongXa { get; set; }

        public Guid? IdTHPTTinh { get; set; }
        public TinhThanh? THPTTinh { get; set; }

        public Guid? IdTHPTHuyen { get; set; }
        public QuanHuyen? THPTHuyen { get; set; }

        public Guid? IdTHPTPhuongXa { get; set; }
        public PhuongXa? THPTPhuongXa { get; set; }

        public Guid IdLopHoc { get; set; } // Lớp danh nghĩa của sinh viên khi mới vào đăng ký ngành
        public Guid? IdLopNienChe { get; set; }
        public Guid? IdLoaiSinhVien { get; set; }
        public LoaiSinhVien? LoaiSinhVien { get; set; }
        public string? NguyenQuan { get; set; }
        public string? KhuVuc { get; set; }
        public string? PhanHe { get; set; }
        public string? TruongTotNghiep { get; set; }
        public DateTime? NgayVaoDoan { get; set; }
        public DateTime? NgayVaoDang { get; set; }
        public string? SoCMND { get; set; }
        public DateTime? NgayCap { get; set; }
        public string? NoiCapCMND { get; set; }
        public string? NoiCap { get; set; }
        public Guid? IdCoSo { get; set; }
        public CoSoDaoTao? CoSoDaoTao { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public Guid? IdNganh { get; set; }
        public NganhHoc? Nganh { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }
        public Guid? IdNganh2 { get; set; }
        public NganhHoc? Nganh2 { get; set; }
        public DateTime? NgayNhapHoc { get; set; }
        public string? HoTenCha { get; set; }
        public string? NgheNghiepCha { get; set; }
        public string? HoTenMe { get; set; }
        public string? NgheNghiepMe { get; set; }
        public string? SoDienThoai { get; set; }
        public string? SoDienThoaiPhuHuynh { get; set; }
        public string? SoDienThoai2 { get; set; }
        public string? SoDienThoai3 { get; set; }
        public string? Email { get; set; }
        public string? EmailTruong { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? TenNganHang { get; set; }
        public string? ChiNhanhNganHang { get; set; }
        public string? MaBHXHBHYT { get; set; }
        public TrangThaiSinhVienEnum TrangThai { get; set; }
        public string? TruongLop12 { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string? DotRaQuyetDinh { get; set; }
        public string? ChucVu { get; set; }
        public string? DonViCongTac { get; set; }

        public LoaiCuTru? LoaiCuTru { get; set; }

        public KiemTraSinhVien? KiemTraSinhVien { get; set; }
        public DoiTuongChinhSach? DoiTuongChinhSach { get; set; }

        public Guid? IdDoiTuongUuTien { get; set; }
        public DanhMucDoiTuongUuTien? DoiTuongUuTien { get; set; }

        public Guid? IdDanToc { get; set; }
        public DanhMucDanToc? DanToc { get; set; }

        public Guid? IdTonGiao { get; set; }
        public DanhMucTonGiao? TonGiao { get; set; }

        public Guid? IdQuocTich { get; set; }
        public DanhMucQuocTich? QuocTich { get; set; }

        // Navigation Property: Một LopHocPhan có nhiều DangKyHocPhan
        public ICollection<SinhVienDangKiHocPhan> DangKyHocPhans { get; set; } = new List<SinhVienDangKiHocPhan>();
        public ICollection<SinhVienMienMonHoc> MonHocDuocMiens { get; set; } = new List<SinhVienMienMonHoc>();

        public ICollection<DanhSachSinhVienDuocInThe> DanhSachSinhVienDuocInThes { get; set; } =
            new List<DanhSachSinhVienDuocInThe>();

        public string? GhiChu { get; set; }

        // Photo and ID Card Management Fields
        /// <summary>
        /// Đường dẫn ảnh thẻ sinh viên
        /// </summary>
        public string? HinhTheSinhVienUrl { get; set; }

        public DateTime? NgayImportAnhTheSv { get; set; }
        public DateTime? NgayCapNhatAnhThe { get; set; }


        /// <summary>
        /// Đường dẫn ảnh CMND/CCCD mặt trước
        /// </summary>
        public string? AnhCMNDMatTruoc { get; set; }

        /// <summary>
        /// Đường dẫn ảnh CMND/CCCD mặt sau
        /// </summary>
        public string? AnhCMNDMatSau { get; set; }

        /// <summary>
        /// Đường dẫn ảnh bằng tốt nghiệp THPT
        /// </summary>
        public string? AnhBangTotNghiep { get; set; }

        /// <summary>
        /// Đường dẫn ảnh học bạ THPT
        /// </summary>
        public string? AnhHocBa { get; set; }

        /// <summary>
        /// Đường dẫn ảnh giấy khai sinh
        /// </summary>
        public string? AnhGiayKhaiSinh { get; set; }

        /// <summary>
        /// Đường dẫn ảnh hộ khẩu
        /// </summary>
        public string? AnhHoKhau { get; set; }

        /// <summary>
        /// Đường dẫn ảnh chứng minh thư quân sự (nếu có)
        /// </summary>
        public string? AnhCMTQuanSu { get; set; }

        /// <summary>
        /// Đường dẫn ảnh giấy chứng nhận ưu tiên (nếu có)
        /// </summary>
        public string? AnhGiayUuTien { get; set; }

        /// <summary>
        /// Đường dẫn ảnh khác (các giấy tờ bổ sung)
        /// </summary>
        public string? AnhKhac { get; set; }

        /// <summary>
        /// Trạng thái xác thực hồ sơ
        /// </summary>
        public bool HoSoDaXacThuc { get; set; } = false;

        /// <summary>
        /// Ngày xác thực hồ sơ
        /// </summary>
        public DateTime? NgayXacThucHoSo { get; set; }

        /// <summary>
        /// ID người xác thực hồ sơ
        /// </summary>
        public Guid? IdNguoiXacThuc { get; set; }

        /// <summary>
        /// Ghi chú về hồ sơ
        /// </summary>
        public string? GhiChuHoSo { get; set; }

        // Navigation Properties for new fields
        /// <summary>
        /// Người xác thực hồ sơ
        /// </summary>
        public virtual NguoiDung? NguoiXacThuc { get; set; }

        /// <summary>
        /// Lớp học hành chính
        /// </summary>
        public virtual LopHoc? LopHoc { get; set; }

        /// <summary>
        /// Lớp niên chế
        /// </summary>
        public virtual LopNienChe? LopNienChe { get; set; }

        /// <summary>
        /// Danh sách công nợ của sinh viên
        /// </summary>
        public virtual ICollection<CongNoSinhVien> CongNos { get; set; } = new List<CongNoSinhVien>();

        /// <summary>
        /// Lịch sử đóng tiền (Phiếu thu)
        /// </summary>
        public virtual ICollection<PhieuThuSinhVien> PhieuThus { get; set; } = new List<PhieuThuSinhVien>();

        /// <summary>
        /// Danh sách miễn giảm/học bổng
        /// </summary>
        public virtual ICollection<MienGiamSinhVien> MienGiams { get; set; } = new List<MienGiamSinhVien>();

        /// <summary>
        /// Danh sách phiếu chi/hoàn tiền
        /// </summary>
        public virtual ICollection<PhieuChiSinhVien> PhieuChis { get; set; } = new List<PhieuChiSinhVien>();
        public virtual ICollection<BangDiemChiTiet>? BangDiemChiTiets { get; set; }
        public virtual ICollection<CuTruKtx> CuTruKtxs { get; set; } = new List<CuTruKtx>();
        [NotMapped]
        public string? FullName
        {
            get
            {
                var fullName = $"{HoDem} {Ten}".Trim();
                return fullName;
            }
        }

        [NotMapped] public string? AnhSinhVienUrl { get; set; }
    }
}