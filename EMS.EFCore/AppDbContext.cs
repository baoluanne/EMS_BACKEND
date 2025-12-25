using EMS.Domain.Entities;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Entities.TimeTable;
using EMS.EFCore.Configurations;
using EMS.EFCore.Configurations.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EMS.EFCore;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override int SaveChanges()
    {
        UpdateAuditableEntities();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        var now = DateTime.UtcNow;

        var httpContext = _httpContextAccessor.HttpContext;
        var userName = httpContext?.Items["preferred_username"] ?? "";

        //var user = Users.FirstOrDefault(x => x.UserName.Equals(userName));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.NgayTao = now;
                entry.Entity.NgayCapNhat = now;

                // entry.Entity.CreatedBy = user;
                // entry.Entity.CreatedById = user?.Id;
                //
                // entry.Entity.ModifiedBy = user;
                // entry.Entity.ModifiedById = user?.Id;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.NgayCapNhat = now;
                // entry.Entity.ModifiedBy = user;
                // entry.Entity.ModifiedById = user?.Id;

                if (entry.Property(x => x.NgayTao).IsModified)
                {
                    entry.Property(x => x.NgayTao).IsModified = false;
                    // entry.Property(x => x.CreatedById).IsModified = false;
                }
            }
        }
    }

    // DbSet properties for all entities
    public DbSet<ApDungQuyCheHocVu> ApDungQuyCheHocVu { get; set; } = null!;
    public DbSet<BacDaoTao> BacDaoTao { get; set; } = null!;
    public DbSet<CaHoc> CaHoc { get; set; } = null!;
    public DbSet<ChungChi> ChungChi { get; set; } = null!;
    public DbSet<ChuyenNganh> ChuyenNganh { get; set; } = null!;
    public DbSet<ChuyenLop> ChuyenLop { get; set; } = null!;
    public DbSet<CoSoDaoTao> CoSoDaoTao { get; set; } = null!;
    public DbSet<DanhMucHocBong> DanhMucHocBong { get; set; } = null!;
    public DbSet<DanhMucPhongBan> DanhMucPhongBan { get; set; } = null!;
    public DbSet<DanhSachKhoaSuDung> DanhSachKhoaSuDung { get; set; } = null!;
    public DbSet<DayNha> DayNha { get; set; } = null!;
    public DbSet<DiaDiemPhong> DiaDiemPhong { get; set; } = null!;
    public DbSet<GiangVien> GiangVien { get; set; } = null!;
    public DbSet<HanhViViPham> HanhViViPham { get; set; } = null!;
    public DbSet<HinhThucDaoTao> HinhThucDaoTao { get; set; } = null!;
    public DbSet<HinhThucThi> HinhThucThi { get; set; } = null!;
    public DbSet<HinhThucXuLyVPQCThi> HinhThucXuLyVPQCThi { get; set; } = null!;
    public DbSet<HocVi> HocVi { get; set; } = null!;
    public DbSet<HTXLViPhamQCThi> HTXLViPhamQCThi { get; set; } = null!;
    public DbSet<KhenThuong> KhenThuong { get; set; } = null!;
    public DbSet<Khoa> Khoa { get; set; } = null!;
    public DbSet<KhoaHoc> KhoaHoc { get; set; } = null!;
    public DbSet<KhoiKienThuc> KhoiKienThuc { get; set; } = null!;
    public DbSet<KhoiNganh> KhoiNganh { get; set; } = null!;
    public DbSet<KieuLamTron> KieuLamTron { get; set; } = null!;
    public DbSet<KieuMonHoc> KieuMonHoc { get; set; } = null!;
    public DbSet<LopHocPhan> LopHocPhan { get; set; } = null!;
    public DbSet<LoaiChungChi> LoaiChungChi { get; set; } = null!;
    public DbSet<LoaiDaoTao> LoaiDaoTao { get; set; } = null!;
    public DbSet<LoaiGiangVien> LoaiGiangVien { get; set; } = null!;
    public DbSet<LoaiHanhViViPham> LoaiHanhViViPham { get; set; } = null!;
    public DbSet<LoaiHinhGiangDay> LoaiHinhGiangDay { get; set; } = null!;
    public DbSet<LoaiKhenThuong> LoaiKhenThuong { get; set; } = null!;
    public DbSet<LoaiMonHoc> LoaiMonHoc { get; set; } = null!;
    public DbSet<LoaiPhong> LoaiPhong { get; set; } = null!;
    public DbSet<LoaiTiet> LoaiTiet { get; set; } = null!;
    public DbSet<LopNienChe> LopNienChe { get; set; } = null!;
    public DbSet<LyDoXinPhong> LyDoXinPhong { get; set; } = null!;
    public DbSet<MonHoc> MonHoc { get; set; } = null!;
    public DbSet<MucDoViPham> MucDoViPham { get; set; } = null!;
    public DbSet<NamHoc> NamHoc { get; set; } = null!;
    public DbSet<NganhHoc> NganhHoc { get; set; } = null!;
    public DbSet<NguoiDung> NguoiDung { get; set; } = null!;
    public DbSet<NhomLoaiHanhViViPham> NhomLoaiHanhViViPham { get; set; } = null!;
    public DbSet<NhomLoaiKhenThuong> NhomLoaiKhenThuong { get; set; } = null!;
    public DbSet<PhongHoc> PhongHoc { get; set; } = null!;
    public DbSet<QuyCheHocVu> QuyCheHocVu { get; set; } = null!;
    public DbSet<QuyChe_NienChe> QuyChe_NienChe { get; set; } = null!;
    public DbSet<QuyChe_TinChi> QuyChe_TinChi { get; set; } = null!;
    public DbSet<QuyetDinh> QuyetDinh { get; set; } = null!;
    public DbSet<QuyUocCotDiem_NC> QuyUocCotDiem_NC { get; set; } = null!;
    public DbSet<QuyUocCotDiem_TC> QuyUocCotDiem_TC { get; set; } = null!;
    public DbSet<ThoiGianDaoTao> ThoiGianDaoTao { get; set; } = null!;
    public DbSet<ThongTinChung_QuyCheTC> ThongTinChung_QuyCheTC { get; set; } = null!;
    public DbSet<TieuChuanXetDanhHieu> TieuChuanXetDanhHieu { get; set; } = null!;
    public DbSet<TieuChuanXetHocBong> TieuChuanXetHocBong { get; set; } = null!;
    public DbSet<TinhChatMonHoc> TinhChatMonHoc { get; set; } = null!;
    public DbSet<ToBoMon> ToBoMon { get; set; } = null!;
    public DbSet<TrangThaiLopHP> TrangThaiLopHP { get; set; } = null!;
    public DbSet<TrangThaiXetQuyUoc> TrangThaiXetQuyUoc { get; set; } = null!;
    public DbSet<XetLLHB_QuyCheTC> XetLLHB_QuyCheTC { get; set; } = null!;
    public DbSet<QuyUocCotDiem_MonHoc> QuyUocCotDiem_MonHoc { get; set; } = null!;
    public DbSet<PhanMonLopHoc> PhanMonLopHoc { get; set; } = null!;
    public DbSet<ChiTietChuongTrinhKhung_NienChe> ChiTietChuongTrinhKhung_NienChe { get; set; } = null!;
    public DbSet<ChuongTrinhKhungNienChe> ChuongTrinhKhungNienChe { get; set; } = null!;
    public DbSet<MonHocBacDaoTao> MonHocBacDaoTao { get; set; } = null!;
    public DbSet<NamHoc_HocKy> NamHoc_HocKy { get; set; } = null!;
    public DbSet<HocKy> HocKy { get; set; } = null!;
    public DbSet<HoSoSV> HoSoSV { get; set; } = null!;
    public DbSet<KeHoachDaoTao_NienChe> KeHoachDaoTao_NienChe { get; set; } = null!;
    public DbSet<KeHoachDaoTao_TinChi> KeHoachDaoTao_TinChi { get; set; } = null!;
    public DbSet<DanhMucBieuMau> DanhMucBieuMau { get; set; } = null!;
    public DbSet<LoaiQuyetDinh>? LoaiQuyetDinh { get; set; } = null!;

    // New DanhMuc entities
    public DbSet<DanhMucCanSuLop> DanhMucCanSuLop { get; set; } = null!;

    public DbSet<DanhMucHoSoHSSV> DanhMucHoSoHSSV { get; set; } = null!;
    public DbSet<DanhMucKhoanChi> DanhMucKhoanChi { get; set; } = null!;
    public DbSet<DanhMucKhoanThuHocPhi> DanhMucKhoanThuHocPhi { get; set; } = null!;
    public DbSet<DanhMucKhoanThuNgoaiHocPhi> DanhMucKhoanThuNgoaiHocPhi { get; set; } = null!;
    public DbSet<DanhMucKhoanThuTuDo> DanhMucKhoanThuTuDo { get; set; } = null!;
    public DbSet<DanhMucKhungHoSoHSSV> DanhMucKhungHoSoHSSV { get; set; } = null!;
    public DbSet<DanhMucLoaiKhoanThuNgoaiHocPhi> DanhMucLoaiKhoanThuNgoaiHocPhi { get; set; } = null!;
    public DbSet<DanhMucLoaiThuPhi_MonHoc> DanhMucLoaiThuPhi_MonHoc { get; set; } = null!;
    public DbSet<DanhMucNganhDaoTao> DanhMucNganhDaoTao { get; set; } = null!;
    public DbSet<DanhMucNoiDung> DanhMucNoiDung { get; set; } = null!;
    public DbSet<DanhMucQuocTich> DanhMucQuocTich { get; set; } = null!;
    public DbSet<DanhMucDoiTuongUuTien> DanhMucDoiTuongUuTien { get; set; } = null!;
    public DbSet<DanhMucTonGiao> DanhMucTonGiao { get; set; } = null!;
    public DbSet<DanhMucDanToc> DanhMucDanToc { get; set; } = null!;

    // ClassManagement entities
    public DbSet<DangKyMonHoc> DangKyMonHoc { get; set; } = null!;
    public DbSet<LopHoc> LopHoc { get; set; } = null!;
    public DbSet<LopHocPhan_LopDuKien> LopHocPhan_LopDuKien { get; set; } = null!;

    // New entities for danhmuc-be branch
    public DbSet<LoaiChucVu> LoaiChucVu { get; set; } = null!;
    public DbSet<LoaiKhoanThu> LoaiKhoanThu { get; set; } = null!;
    public DbSet<TieuChiTuyenSinh> TieuChiTuyenSinh { get; set; } = null!;
    public DbSet<LoaiSinhVien> LoaiSinhVien { get; set; } = null!;
    public DbSet<PhanChuyenNganh> PhanChuyenNganh { get; set; } = null!;
    public DbSet<ChuyenTruong> ChuyenTruong { get; set; } = null!;
    public DbSet<DanhSachSinhVienDuocInThe> DanhSachSinhVienDuocInThe { get; set; } = null!;
    public DbSet<LichHocThi> LichHocThi { get; set; } = null!;
    public DbSet<NhatKyCapNhatTrangThaiSv> NhatKyCapNhatTrangThaiSv { get; set; } = null!;
    public DbSet<SinhVien> SinhVien { get; set; } = null!;
    public DbSet<SinhVienDangKiHocPhan> SinhVienDangKiHocPhan { get; set; } = null!;
    public DbSet<SinhVienNganh2> SinhVienNganh2 { get; set; } = null!;
    public DbSet<SinhVienMienMonHoc> SinhVienMienMonHoc { get; set; } = null!;
    public DbSet<ThongKeInBieuMau> ThongKeInBieuMau { get; set; } = null!;
    public DbSet<TiepNhanHoSoSv> TiepNhanHoSoSv { get; set; } = null!;
    public DbSet<TinhThanh> TinhThanh { get; set; } = null!;
    public DbSet<QuanHuyen> QuanHuyen { get; set; } = null!;
    public DbSet<PhuongXa> PhuongXa { get; set; } = null!;

    // Thoi khoa bieu
    public DbSet<ThoiKhoaBieu> ThoiKhoaBieu { get; set; } = null!;
    public DbSet<MonTienQuyet> MonTienQuyet { get; set; } = null!;
    public DbSet<BangDiemChiTiet> BangDiemChiTiet { get; set; } = null!;
    public DbSet<ChuyenDoiHocPhan> ChuyenDoiHocPhan { get; set; } = null!;

    public DbSet<CongNoSinhVien> CongNoSinhViens { get; set; } = null!;
    public DbSet<PhieuThuSinhVien> PhieuThuSinhViens { get; set; } = null!;
    public DbSet<PhieuChiSinhVien> PhieuChiSinhViens { get; set; } = null!;
    public DbSet<CongNoChiTiet> CongNoChiTiets { get; set; } = null!;
    public DbSet<HoaDonDienTuSinhVien> HoaDonDienTuSinhViens { get; set; } = null!;
    public DbSet<MienGiamSinhVien> MienGiamSinhViens { get; set; } = null!;
    public DbSet<ChinhSachMienGiam> ChinhSachMienGiams { get; set; } = null!;

    public DbSet<ToaNhaKtx> toaNhaKtxes { get; set; } = null!;
    public DbSet<PhongKtx> phongKtxes { get; set; } = null!;
    public DbSet<GiuongKtx> giuongKtxes { get; set; } = null!;
    public DbSet<DonKtx> DonKtxes { get; set; } = null!;
    public DbSet<ViPhamNoiQuyKTX> ViPhamNoiQuyKTXes { get; set; } = null!;
    public DbSet<ChiSoDienNuoc> ChiSoDienNuocs { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations explicitly
        /*modelBuilder.ApplyConfiguration(new ApDungQuyCheHocVuConfiguration());
        modelBuilder.ApplyConfiguration(new BacDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new CaHocConfiguration());
        modelBuilder.ApplyConfiguration(new ChungChiConfiguration());
        modelBuilder.ApplyConfiguration(new ChuyenNganhConfiguration());
        modelBuilder.ApplyConfiguration(new ChuyenLopConfiguration());
        modelBuilder.ApplyConfiguration(new CoSoDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucHocBongConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucPhongBanConfiguration());
        modelBuilder.ApplyConfiguration(new DanhSachKhoaSuDungConfiguration());
        modelBuilder.ApplyConfiguration(new DayNhaConfiguration());
        modelBuilder.ApplyConfiguration(new DiaDiemPhongConfiguration());
        modelBuilder.ApplyConfiguration(new GiangVienConfiguration());
        modelBuilder.ApplyConfiguration(new HanhViViPhamConfiguration());
        modelBuilder.ApplyConfiguration(new HinhThucDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new HinhThucThiConfiguration());
        modelBuilder.ApplyConfiguration(new HinhThucXuLyVPQCThiConfiguration());
        modelBuilder.ApplyConfiguration(new HocViConfiguration());
        modelBuilder.ApplyConfiguration(new KhenThuongConfiguration());
        modelBuilder.ApplyConfiguration(new KhoaConfiguration());
        modelBuilder.ApplyConfiguration(new KhoaHocConfiguration());
        modelBuilder.ApplyConfiguration(new KhoiKienThucConfiguration());
        modelBuilder.ApplyConfiguration(new KhoiNganhConfiguration());
        modelBuilder.ApplyConfiguration(new KieuLamTronConfiguration());
        modelBuilder.ApplyConfiguration(new KieuMonHocConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiChungChiConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiGiangVienConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiHanhViViPhamConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiHinhGiangDayConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiKhenThuongConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiMonHocConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiPhongConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiTietConfiguration());
        modelBuilder.ApplyConfiguration(new LopNienCheConfiguration());
        modelBuilder.ApplyConfiguration(new LyDoXinPhongConfiguration());
        modelBuilder.ApplyConfiguration(new MonHocConfiguration());
        modelBuilder.ApplyConfiguration(new MucDoViPhamConfiguration());
        modelBuilder.ApplyConfiguration(new NamHocConfiguration());
        modelBuilder.ApplyConfiguration(new NganhHocConfiguration());
        modelBuilder.ApplyConfiguration(new NguoiDungConfiguration());
        modelBuilder.ApplyConfiguration(new NhomLoaiHanhViViPhamConfiguration());
        modelBuilder.ApplyConfiguration(new NhomLoaiKhenThuongConfiguration());
        modelBuilder.ApplyConfiguration(new PhongHocConfiguration());
        modelBuilder.ApplyConfiguration(new QuyCheHocVuConfiguration());
        modelBuilder.ApplyConfiguration(new QuyChe_NienCheConfiguration());
        modelBuilder.ApplyConfiguration(new QuyChe_TinChiConfiguration());
        modelBuilder.ApplyConfiguration(new QuyetDinhConfiguration());
        modelBuilder.ApplyConfiguration(new QuyUocCotDiem_NCConfiguration());
        modelBuilder.ApplyConfiguration(new QuyUocCotDiem_TCConfiguration());
        modelBuilder.ApplyConfiguration(new ThoiGianDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new ThongTinChung_QuyCheTCConfiguration());
        modelBuilder.ApplyConfiguration(new TieuChuanXetDanhHieuConfiguration());
        modelBuilder.ApplyConfiguration(new TieuChuanXetHocBongConfiguration());
        modelBuilder.ApplyConfiguration(new TinhChatMonHocConfiguration());
        modelBuilder.ApplyConfiguration(new ToBoMonConfiguration());
        modelBuilder.ApplyConfiguration(new TrangThaiLopHPConfiguration());
        modelBuilder.ApplyConfiguration(new TrangThaiXetQuyUocConfiguration());
        modelBuilder.ApplyConfiguration(new XetLLHB_QuyCheTCConfiguration());
        modelBuilder.ApplyConfiguration(new QuyUocCotDiem_MonHocConfiguration());
        modelBuilder.ApplyConfiguration(new PhanMonLopHocConfiguration());
        modelBuilder.ApplyConfiguration(new ChiTietChuongTrinhKhung_NienCheConfiguration());
        modelBuilder.ApplyConfiguration(new ChuongTrinhKhungNienCheConfiguration());
        modelBuilder.ApplyConfiguration(new MonHocBacDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new NamHoc_HocKyConfiguration());
        modelBuilder.ApplyConfiguration(new HocKyConfiguration());
        modelBuilder.ApplyConfiguration(new HoSoSVConfiguration());
        modelBuilder.ApplyConfiguration(new KeHoachDaoTao_NienCheConfiguration());
        modelBuilder.ApplyConfiguration(new KeHoachDaoTao_TinChiConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucBieuMauConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiQuyetDinhConfiguration());

        // New DanhMuc configurations
        modelBuilder.ApplyConfiguration(new DanhMucCanSuLopConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucHoSoHSSVConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucKhoanChiConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucKhoanThuHocPhiConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucKhoanThuNgoaiHocPhiConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucKhoanThuTuDoConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucKhungHoSoHSSVConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucLoaiKhoanThuNgoaiHocPhiConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucLoaiThuPhi_MonHocConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucNganhDaoTaoConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucNoiDungConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucTonGiaoConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucDoiTuongUuTienConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucQuocTichConfiguration());
        modelBuilder.ApplyConfiguration(new DanhMucDanTocConfiguration());

        // ClassManagement configurations
        modelBuilder.ApplyConfiguration(new DangKyMonHocConfiguration());
        modelBuilder.ApplyConfiguration(new LopHocConfiguration());
        modelBuilder.ApplyConfiguration(new LopHocPhan_LopDuKienConfiguration());

        // New entity configurations
        modelBuilder.ApplyConfiguration(new LoaiChucVuConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiKhoanThuConfiguration());
        modelBuilder.ApplyConfiguration(new TieuChiTuyenSinhConfiguration());
        modelBuilder.ApplyConfiguration(new LoaiSinhVienConfiguration());
        modelBuilder.ApplyConfiguration(new PhanChuyenNganhConfiguration());
        modelBuilder.ApplyConfiguration(new ChuyenTruongConfiguration());
        modelBuilder.ApplyConfiguration(new DanhSachSinhVienDuocInTheConfiguration());
        modelBuilder.ApplyConfiguration(new LichHocThiConfiguration());
        modelBuilder.ApplyConfiguration(new NhatKyCapNhatTrangThaiSvConfiguration());
        modelBuilder.ApplyConfiguration(new SinhVienConfiguration());
        modelBuilder.ApplyConfiguration(new SinhVienDangKiHocPhanConfiguration());
        modelBuilder.ApplyConfiguration(new SinhVienNganh2Configuration());
        modelBuilder.ApplyConfiguration(new SinhVienMienMonHocConfiguration());
        modelBuilder.ApplyConfiguration(new ThongKeInBieuMauConfiguration());
        modelBuilder.ApplyConfiguration(new TiepNhanHoSoSvConfiguration());

        // thoi khoa bieu
        modelBuilder.ApplyConfiguration(new ThoiKhoaBieuConfiguration());

        modelBuilder.ApplyConfiguration(new MonTienQuyetConfiguration());
        modelBuilder.ApplyConfiguration(new BangDiemChiTietConfiguration());*/

        // Apply all configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
