using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.ClassManagement
{
    public class LopHocPhan : AuditableEntity
    {
        //Mã định danh học phần
        public required string MaLopHocPhan { get; set; }
        public required string TenLopHocPhan { get; set; }
        public required string MaHocPhan { get; set; }
        // Liên kết chính
        public Guid IdMonHoc { get; set; }
        public MonHoc? MonHoc { get; set; }
        // Bối cảnh đào tạo
        public Guid IdHocKy { get; set; }
        public HocKy? HocKy { get; set; }

        public Guid IdCoSo { get; set; }
        public CoSoDaoTao? CoSo { get; set; }

        public Guid IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }

        public Guid IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }

        public Guid? IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }

        public Guid? IdGiangVien { get; set; }
        public GiangVien? GiangVien { get; set; }

        // Quản lý và phân loại
        public Guid IdKhoaChuQuan { get; set; }
        public Khoa? KhoaChuQuan { get; set; }

        public string? LopBanDau { get; set; } // TODO: to be clarified
        public LoaiLHPEnum? LoaiLHP { get; set; }

        public Guid IdLoaiMonHoc { get; set; }
        public LoaiMonHoc? LoaiMonHoc { get; set; }

        public Guid? IdHinhThucThi { get; set; }
        public HinhThucThi? HinhThucThi { get; set; }
        public LoaiMonLTTHEnum? LoaiMonLTTH { get; set; }
        public TrangThaiLopHocPhanEnum? TrangThai { get; set; } = TrangThaiLopHocPhanEnum.MoLop;
        // Thông tin vận hành
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SoLuongToiDa { get; set; }
        public int SoLuongHienTai { get; set; }

        // Navigation Property: Một LopHocPhan có nhiều DangKyHocPhan
        public ICollection<SinhVienDangKiHocPhan> DangKyHocPhans { get; set; } = new List<SinhVienDangKiHocPhan>();
        public virtual ICollection<LopHocPhan_LopDuKien> LopDuKiens { get; set; } = new List<LopHocPhan_LopDuKien>();

        // Others
        public string? GhiChu { get; set; }

        // Cần thiết cho chức năng Đăng ký Tự động(Theo dõi nguồn gốc tạo lớp).
        public bool? IsTuDongTao { get; set; }

        // Lưu trữ CTK được dùng để tạo LHP (Nếu LHP được mở theo kế hoạch).
        public Guid? IdChuongTrinhKhungTinChi { get; set; }
        public ChuongTrinhKhungTinChi? ChuongTrinhKhungTinChi { get; set; }

        public virtual ICollection<BangDiemChiTiet>? BangDiemChiTiets { get; set; } = new List<BangDiemChiTiet>();

    }
}