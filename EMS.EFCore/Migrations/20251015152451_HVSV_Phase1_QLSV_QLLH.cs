using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class HVSV_Phase1_QLSV_QLLH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaCaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    TenCaHoc = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Thu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Tiet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BuoiHoc = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoSoSV",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHoSo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DaNhan = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    InBienNhan = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    XemIn = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    SoBanIn = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MaVach = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CongNoHocPhi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KhoanThuKhac = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoSV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoSV_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoSoSV_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenQuyetDinh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NgayQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguoiKy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyetDinh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLop = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLop = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TenTiengAnh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SiSoDuKien = table.Column<int>(type: "integer", nullable: false),
                    SiSoHienTai = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    SiSoDangHoc = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNganhHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiangVienChuNhiem = table.Column<Guid>(type: "uuid", nullable: true),
                    IdCoVanHocTap = table.Column<Guid>(type: "uuid", nullable: true),
                    IDCaHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    KyTuMSSV = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    SoHopDong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoQuyetDinhThanhLapLop = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayHopDong = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayRaQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHoc_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_CaHoc_IDCaHoc",
                        column: x => x.IDCaHoc,
                        principalTable: "CaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LopHoc_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_GiangVien_IdCoVanHocTap",
                        column: x => x.IdCoVanHocTap,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LopHoc_GiangVien_IdGiangVienChuNhiem",
                        column: x => x.IdGiangVienChuNhiem,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LopHoc_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_NganhHoc_IdNganhHoc",
                        column: x => x.IdNganhHoc,
                        principalTable: "NganhHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLopHocPhan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLopHocPhan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MaHocPhan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiangVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNamHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    SoLuongToiDa = table.Column<int>(type: "integer", nullable: true),
                    SoLuongHienTai = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    SoTinChi = table.Column<int>(type: "integer", nullable: false),
                    SoTietLyThuyet = table.Column<int>(type: "integer", nullable: false),
                    SoTietThucHanh = table.Column<int>(type: "integer", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    IdKhoaChuQuan = table.Column<Guid>(type: "uuid", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_GiangVien_IdGiangVien",
                        column: x => x.IdGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_Khoa_IdKhoaChuQuan",
                        column: x => x.IdKhoaChuQuan,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_NamHoc_IdNamHoc",
                        column: x => x.IdNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopHocPhan_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SoBaoDanh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ThuTuNhanHoSo = table.Column<int>(type: "integer", nullable: true),
                    MaSinhVien = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MaBarcode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HoDem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<int>(type: "integer", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DonViCuDiHoc = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DanToc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TonGiao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HoKhauThuongTru = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DiaChiLienLac = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TenTinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenHuyen = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenPhuongXa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoiSinhTinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoiSinhHuyen = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoiSinhPhuongXa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdLopHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLopNienChe = table.Column<Guid>(type: "uuid", nullable: true),
                    LoaiSinhVien = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NguyenQuan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TenDoiTuong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenDoiTuongChinhSach = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KhuVuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhanHe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TruongTotNghiep = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NgayVaoDoan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayVaoDang = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SoCMND = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NoiCapCMND = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NoiCap = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CoSo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KhoaHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNganh = table.Column<Guid>(type: "uuid", nullable: true),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNganh2 = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayNhapHoc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HoTenCha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgheNghiepCha = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HoTenMe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgheNghiepMe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SoDienThoai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SoDienThoaiPhuHuynh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SoDienThoai2 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SoDienThoai3 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    EmailTruong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenNganHang = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ChiNhanhNganHang = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MaBHXHBHYT = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    QuocTich = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TruongLop12 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DotRaQuyetDinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ChucVu = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DonViCongTac = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HinhTheSinhVienUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NgayImportAnhTheSv = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayCapNhatAnhThe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AnhCMNDMatTruoc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhCMNDMatSau = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhBangTotNghiep = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhHocBa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhGiayKhaiSinh = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhHoKhau = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhCMTQuanSu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhGiayUuTien = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AnhKhac = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HoSoDaXacThuc = table.Column<bool>(type: "boolean", nullable: false),
                    NgayXacThucHoSo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiXacThuc = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChuHoSo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVien_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_LopNienChe_IdLopNienChe",
                        column: x => x.IdLopNienChe,
                        principalTable: "LopNienChe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_NganhHoc_IdNganh",
                        column: x => x.IdNganh,
                        principalTable: "NganhHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_NganhHoc_IdNganh2",
                        column: x => x.IdNganh2,
                        principalTable: "NganhHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_NguoiDung_IdNguoiXacThuc",
                        column: x => x.IdNguoiXacThuc,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChuyenLop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopCu = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopMoi = table.Column<Guid>(type: "uuid", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayRaQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayChuyenLop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhanLoaiChuyenLop = table.Column<int>(type: "integer", nullable: false),
                    TrichYeu = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IdQuyetDinh = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenLop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenLop_LopHoc_IdLopCu",
                        column: x => x.IdLopCu,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenLop_LopHoc_IdLopMoi",
                        column: x => x.IdLopMoi,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenLop_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenLop_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenLop_QuyetDinh_IdQuyetDinh",
                        column: x => x.IdQuyetDinh,
                        principalTable: "QuyetDinh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenLop_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenTruong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GioiTinh = table.Column<int>(type: "integer", nullable: true),
                    IdCoSo = table.Column<Guid>(type: "uuid", nullable: true),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNganhHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: true),
                    TuTaoMaSinhVien = table.Column<bool>(type: "boolean", nullable: false),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenTruong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_CoSoDaoTao_IdCoSo",
                        column: x => x.IdCoSo,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_NganhHoc_IdNganhHoc",
                        column: x => x.IdNganhHoc,
                        principalTable: "NganhHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenTruong_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DangKyMonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDangKy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: true),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNamHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiDuyet = table.Column<Guid>(type: "uuid", nullable: true),
                    LyDoDuyet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SoTinChi = table.Column<int>(type: "integer", nullable: false),
                    DiemQuaTrinh = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: true),
                    DiemCuoiKy = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: true),
                    DiemTongKet = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: true),
                    DiemChu = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    DiemSo4 = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: true),
                    KetQua = table.Column<bool>(type: "boolean", nullable: true),
                    SoBuoiVang = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LyDoVang = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsMienGiam = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LanHoc = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    HocPhi = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    DaDongHocPhi = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    NgayDongHocPhi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_LopHocPhan_IdLopHocPhan",
                        column: x => x.IdLopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_NamHoc_IdNamHoc",
                        column: x => x.IdNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_NguoiDung_IdNguoiDuyet",
                        column: x => x.IdNguoiDuyet,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DangKyMonHoc_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachSinhVienDuocInThe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    CoHinhTheSv = table.Column<bool>(type: "boolean", nullable: false),
                    NgayImportHinhTheSv = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachSinhVienDuocInThe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhSachSinhVienDuocInThe_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichHocThi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDotHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiLich = table.Column<int>(type: "integer", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: false),
                    NgayThi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TenPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHocThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichHocThi_HocKy_IdDotHoc",
                        column: x => x.IdDotHoc,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHocThi_LopHocPhan_IdLopHocPhan",
                        column: x => x.IdLopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHocThi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LichHocThi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LichHocThi_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyCapNhatTrangThaiSv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiCu = table.Column<int>(type: "integer", nullable: false),
                    TrangThaiMoi = table.Column<int>(type: "integer", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NgayQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdQuyetDinh = table.Column<Guid>(type: "uuid", nullable: false),
                    QuyetDinhId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyCapNhatTrangThaiSv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatKyCapNhatTrangThaiSv_QuyetDinh_QuyetDinhId",
                        column: x => x.QuyetDinhId,
                        principalTable: "QuyetDinh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatKyCapNhatTrangThaiSv_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanChuyenNganh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenNganhCu = table.Column<Guid>(type: "uuid", nullable: true),
                    IdChuyenNganhMoi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNamHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiPhanChuyen = table.Column<int>(type: "integer", nullable: false),
                    NgayPhanChuyen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LyDoPhanChuyen = table.Column<string>(type: "text", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    IdNguoiDuyet = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayDuyet = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LyDoTuChoi = table.Column<string>(type: "text", nullable: true),
                    DiemXet = table.Column<decimal>(type: "numeric", nullable: true),
                    ThuTuUuTien = table.Column<int>(type: "integer", nullable: true),
                    NgayHieuLuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanChuyenNganh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_ChuyenNganh_IdChuyenNganhCu",
                        column: x => x.IdChuyenNganhCu,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_ChuyenNganh_IdChuyenNganhMoi",
                        column: x => x.IdChuyenNganhMoi,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_NamHoc_IdNamHoc",
                        column: x => x.IdNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_NguoiDung_IdNguoiDuyet",
                        column: x => x.IdNguoiDuyet,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanChuyenNganh_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienDangKiHocPhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiDangKyLHP = table.Column<int>(type: "integer", nullable: false),
                    HocPhi = table.Column<bool>(type: "boolean", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguonDangKy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdNguoiDangKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienDangKiHocPhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienDangKiHocPhan_LopHocPhan_IdLopHocPhan",
                        column: x => x.IdLopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiDangKy",
                        column: x => x.IdNguoiDangKy,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienDangKiHocPhan_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienMienMonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyetDinh = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienMienMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienMienMonHoc_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienMienMonHoc_QuyetDinh_IdQuyetDinh",
                        column: x => x.IdQuyetDinh,
                        principalTable: "QuyetDinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienMienMonHoc_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienNganh2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHoc1 = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHoc2 = table.Column<Guid>(type: "uuid", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayQuyetDinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiRaQuyetDinh = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienNganh2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_LopHoc_IdLopHoc1",
                        column: x => x.IdLopHoc1,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_LopHoc_IdLopHoc2",
                        column: x => x.IdLopHoc2,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                        column: x => x.IdNguoiRaQuyetDinh,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVienNganh2_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongKeInBieuMau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdBieuMau = table.Column<Guid>(type: "uuid", nullable: false),
                    MayIn = table.Column<string>(type: "text", nullable: true),
                    NgayIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiIn = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKeInBieuMau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongKeInBieuMau_DanhMucBieuMau_IdBieuMau",
                        column: x => x.IdBieuMau,
                        principalTable: "DanhMucBieuMau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongKeInBieuMau_NguoiDung_IdNguoiIn",
                        column: x => x.IdNguoiIn,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongKeInBieuMau_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThongKeInBieuMau_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThongKeInBieuMau_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TiepNhanHoSoSv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHoSoSV = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTiepNhan = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiXuLy = table.Column<Guid>(type: "uuid", nullable: false),
                    NguoiXuLyId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiepNhanHoSoSv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_HoSoSV_IdHoSoSV",
                        column: x => x.IdHoSoSV,
                        principalTable: "HoSoSV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiTiepNhan",
                        column: x => x.IdNguoiTiepNhan,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiXuLyId",
                        column: x => x.NguoiXuLyId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiepNhanHoSoSv_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaHoc_MaCaHoc",
                table: "CaHoc",
                column: "MaCaHoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaHoc_NguoiCapNhapId",
                table: "CaHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_CaHoc_NguoiTaoId",
                table: "CaHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_IdLopCu",
                table: "ChuyenLop",
                column: "IdLopCu");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_IdLopMoi",
                table: "ChuyenLop",
                column: "IdLopMoi");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_IdQuyetDinh",
                table: "ChuyenLop",
                column: "IdQuyetDinh");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_IdSinhVien",
                table: "ChuyenLop",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_NgayChuyenLop",
                table: "ChuyenLop",
                column: "NgayChuyenLop");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_NguoiCapNhapId",
                table: "ChuyenLop",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_NguoiTaoId",
                table: "ChuyenLop",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_PhanLoaiChuyenLop",
                table: "ChuyenLop",
                column: "PhanLoaiChuyenLop");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdBacDaoTao",
                table: "ChuyenTruong",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdChuyenNganh",
                table: "ChuyenTruong",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdCoSo",
                table: "ChuyenTruong",
                column: "IdCoSo");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdKhoaHoc",
                table: "ChuyenTruong",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdLoaiDaoTao",
                table: "ChuyenTruong",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdLopHoc",
                table: "ChuyenTruong",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdNganhHoc",
                table: "ChuyenTruong",
                column: "IdNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdSinhVien",
                table: "ChuyenTruong",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_NguoiCapNhapId",
                table: "ChuyenTruong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_NguoiTaoId",
                table: "ChuyenTruong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdHocKy",
                table: "DangKyMonHoc",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdLopHocPhan",
                table: "DangKyMonHoc",
                column: "IdLopHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdMonHoc_TrangThai",
                table: "DangKyMonHoc",
                columns: new[] { "IdMonHoc", "TrangThai" });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdNamHoc",
                table: "DangKyMonHoc",
                column: "IdNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdNguoiDuyet",
                table: "DangKyMonHoc",
                column: "IdNguoiDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdSinhVien_IdMonHoc_IdHocKy_IdNamHoc",
                table: "DangKyMonHoc",
                columns: new[] { "IdSinhVien", "IdMonHoc", "IdHocKy", "IdNamHoc" });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdSinhVien_TrangThai",
                table: "DangKyMonHoc",
                columns: new[] { "IdSinhVien", "TrangThai" });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_MaDangKy",
                table: "DangKyMonHoc",
                column: "MaDangKy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_NguoiCapNhapId",
                table: "DangKyMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_NguoiTaoId",
                table: "DangKyMonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachSinhVienDuocInThe_IdSinhVien",
                table: "DanhSachSinhVienDuocInThe",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachSinhVienDuocInThe_NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachSinhVienDuocInThe_NguoiTaoId",
                table: "DanhSachSinhVienDuocInThe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoSV_MaHoSo",
                table: "HoSoSV",
                column: "MaHoSo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoSoSV_NguoiCapNhapId",
                table: "HoSoSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoSV_NguoiTaoId",
                table: "HoSoSV",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_IdDotHoc",
                table: "LichHocThi",
                column: "IdDotHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_IdLopHocPhan",
                table: "LichHocThi",
                column: "IdLopHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_IdSinhVien",
                table: "LichHocThi",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_NguoiCapNhapId",
                table: "LichHocThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_NguoiTaoId",
                table: "LichHocThi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdBacDaoTao",
                table: "LopHoc",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IDCaHoc",
                table: "LopHoc",
                column: "IDCaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdChuyenNganh",
                table: "LopHoc",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdCoSoDaoTao",
                table: "LopHoc",
                column: "IdCoSoDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdCoVanHocTap",
                table: "LopHoc",
                column: "IdCoVanHocTap");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdGiangVienChuNhiem",
                table: "LopHoc",
                column: "IdGiangVienChuNhiem");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdLoaiDaoTao",
                table: "LopHoc",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdNganhHoc",
                table: "LopHoc",
                column: "IdNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_Khoa_BacDaoTao_LoaiDaoTao",
                table: "LopHoc",
                columns: new[] { "IdKhoa", "IdBacDaoTao", "IdLoaiDaoTao" });

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_KhoaHoc_NganhHoc_MaLop",
                table: "LopHoc",
                columns: new[] { "IdKhoaHoc", "IdNganhHoc", "MaLop" });

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaLop",
                table: "LopHoc",
                column: "MaLop",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_NguoiCapNhapId",
                table: "LopHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_NguoiTaoId",
                table: "LopHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdGiangVien",
                table: "LopHocPhan",
                column: "IdGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdHocKy",
                table: "LopHocPhan",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdKhoaChuQuan",
                table: "LopHocPhan",
                column: "IdKhoaChuQuan");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdLopHoc",
                table: "LopHocPhan",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdMonHoc",
                table: "LopHocPhan",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdNamHoc",
                table: "LopHocPhan",
                column: "IdNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_MaLopHocPhan",
                table: "LopHocPhan",
                column: "MaLopHocPhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_NguoiCapNhapId",
                table: "LopHocPhan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_NguoiTaoId",
                table: "LopHocPhan",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdSinhVien",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_NguoiTaoId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "QuyetDinhId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdChuyenNganhCu",
                table: "PhanChuyenNganh",
                column: "IdChuyenNganhCu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdChuyenNganhMoi",
                table: "PhanChuyenNganh",
                column: "IdChuyenNganhMoi");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdHocKy",
                table: "PhanChuyenNganh",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdNamHoc",
                table: "PhanChuyenNganh",
                column: "IdNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdNguoiDuyet",
                table: "PhanChuyenNganh",
                column: "IdNguoiDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdSinhVien",
                table: "PhanChuyenNganh",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_NguoiCapNhapId",
                table: "PhanChuyenNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_NguoiTaoId",
                table: "PhanChuyenNganh",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_NguoiCapNhapId",
                table: "QuyetDinh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_NguoiTaoId",
                table: "QuyetDinh",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_SoQuyetDinh",
                table: "QuyetDinh",
                column: "SoQuyetDinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdBacDaoTao",
                table: "SinhVien",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdChuyenNganh",
                table: "SinhVien",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdLoaiDaoTao",
                table: "SinhVien",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdLopHoc",
                table: "SinhVien",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdLopNienChe",
                table: "SinhVien",
                column: "IdLopNienChe");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNganh",
                table: "SinhVien",
                column: "IdNganh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNganh2",
                table: "SinhVien",
                column: "IdNganh2");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNguoiXacThuc",
                table: "SinhVien",
                column: "IdNguoiXacThuc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_NguoiCapNhapId",
                table: "SinhVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_NguoiTaoId",
                table: "SinhVien",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdLopHocPhan",
                table: "SinhVienDangKiHocPhan",
                column: "IdLopHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdSinhVien",
                table: "SinhVienDangKiHocPhan",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_NguoiTaoId",
                table: "SinhVienDangKiHocPhan",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_IdMonHoc",
                table: "SinhVienMienMonHoc",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_IdQuyetDinh",
                table: "SinhVienMienMonHoc",
                column: "IdQuyetDinh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_IdSinhVien",
                table: "SinhVienMienMonHoc",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_NguoiCapNhapId",
                table: "SinhVienMienMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_NguoiTaoId",
                table: "SinhVienMienMonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdKhoaHoc",
                table: "SinhVienNganh2",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdLopHoc1",
                table: "SinhVienNganh2",
                column: "IdLopHoc1");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdLopHoc2",
                table: "SinhVienNganh2",
                column: "IdLopHoc2");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                column: "IdNguoiRaQuyetDinh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdSinhVien",
                table: "SinhVienNganh2",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_NguoiCapNhapId",
                table: "SinhVienNganh2",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_NguoiTaoId",
                table: "SinhVienNganh2",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_IdBieuMau",
                table: "ThongKeInBieuMau",
                column: "IdBieuMau");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_IdNguoiIn",
                table: "ThongKeInBieuMau",
                column: "IdNguoiIn");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_NguoiCapNhapId",
                table: "ThongKeInBieuMau",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_NguoiTaoId",
                table: "ThongKeInBieuMau",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_SinhVienId",
                table: "ThongKeInBieuMau",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_IdHoSoSV",
                table: "TiepNhanHoSoSv",
                column: "IdHoSoSV");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiTiepNhan",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_IdSinhVien",
                table: "TiepNhanHoSoSv",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_NguoiCapNhapId",
                table: "TiepNhanHoSoSv",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_NguoiTaoId",
                table: "TiepNhanHoSoSv",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_NguoiXuLyId",
                table: "TiepNhanHoSoSv",
                column: "NguoiXuLyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuyenLop");

            migrationBuilder.DropTable(
                name: "ChuyenTruong");

            migrationBuilder.DropTable(
                name: "DangKyMonHoc");

            migrationBuilder.DropTable(
                name: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropTable(
                name: "LichHocThi");

            migrationBuilder.DropTable(
                name: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropTable(
                name: "PhanChuyenNganh");

            migrationBuilder.DropTable(
                name: "SinhVienDangKiHocPhan");

            migrationBuilder.DropTable(
                name: "SinhVienMienMonHoc");

            migrationBuilder.DropTable(
                name: "SinhVienNganh2");

            migrationBuilder.DropTable(
                name: "ThongKeInBieuMau");

            migrationBuilder.DropTable(
                name: "TiepNhanHoSoSv");

            migrationBuilder.DropTable(
                name: "LopHocPhan");

            migrationBuilder.DropTable(
                name: "QuyetDinh");

            migrationBuilder.DropTable(
                name: "HoSoSV");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "CaHoc");
        }
    }
}
