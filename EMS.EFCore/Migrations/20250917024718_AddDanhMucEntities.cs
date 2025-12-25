using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddDanhMucEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_BacDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_BanDiemTN",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_BangTotNghiep",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_KhoiNganh_IDKhoiNganh",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_LoaiDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ThoiGianDaoTao",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KyTuMaSV",
                table: "ThoiGianDaoTao",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHinhThucThi",
                table: "HinhThucThi",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HinhThucThi",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdBieuMauDanhSachDuThi",
                table: "HinhThucThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenChuyenNganh",
                table: "ChuyenNganh",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ChuyenNganh",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "ChuyenNganh",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "ChuyenNganh",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTiengAnh",
                table: "ChuyenNganh",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenVietTat",
                table: "ChuyenNganh",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanhMucBieuMau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaBieuMau = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenBieuMau = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LoaiFile = table.Column<int>(type: "integer", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdKhoaQuanLy = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_DanhMucBieuMau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucBieuMau_Khoa_IdKhoaQuanLy",
                        column: x => x.IdKhoaQuanLy,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucBieuMau_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucBieuMau_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucHoSoHSSV",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHoSo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucHoSoHSSV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoanChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoanChi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoanChi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucKhoanChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoanThuHocPhi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoanThu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoanThu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    CapSoHoaDonDienTu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_DanhMucKhoanThuHocPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiKhoanThu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiKhoanThu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    XuatHoaDonDienTu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    HinhThucThu = table.Column<int>(type: "integer", nullable: true),
                    PhanBoDoanThu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MaTKNganHang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucLoaiKhoanThuNgoaiHocPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiThuPhi_MonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiThuPhi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiThuPhi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    CapSoHoaDonDienTu = table.Column<bool>(type: "boolean", nullable: true),
                    CongThucQuyDoi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MaTKNganHang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucLoaiThuPhi_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNganhDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaNganh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenNganh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TenTiengAnh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TenVietTat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MaTuyenSinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STT = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    KhoiThi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KyTuMaSV = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IdKhoiNganh = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucNganhDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucNganhDaoTao_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucNganhDaoTao_KhoiNganh_IdKhoiNganh",
                        column: x => x.IdKhoiNganh,
                        principalTable: "KhoiNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNoiDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiNoiDung = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_DanhMucNoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucNoiDung_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucNoiDung_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiChucVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_LoaiChucVu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiChucVu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiChucVu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhoanThu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_LoaiKhoanThu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiKhoanThu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiKhoanThu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_LoaiSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiSinhVien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiSinhVien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TieuChiTuyenSinh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_TieuChiTuyenSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucCanSuLop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaChucVu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenChucVu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    HoatDongDoan = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IdLoaiChucVu = table.Column<Guid>(type: "uuid", nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DiemCong = table.Column<float>(type: "numeric(5,2)", nullable: true),
                    STT = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucCanSuLop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucCanSuLop_LoaiChucVu_IdLoaiChucVu",
                        column: x => x.IdLoaiChucVu,
                        principalTable: "LoaiChucVu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucCanSuLop_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucCanSuLop_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoanThuNgoaiHocPhi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoanThu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoanThu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SoTien = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    IdLoaiKhoanThu = table.Column<Guid>(type: "uuid", nullable: false),
                    DonViTinh = table.Column<int>(type: "integer", nullable: true),
                    ThueVAT = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    GomThueVAT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_DanhMucKhoanThuNgoaiHocPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuNgoaiHocPhi_LoaiKhoanThu_IdLoaiKhoanThu",
                        column: x => x.IdLoaiKhoanThu,
                        principalTable: "LoaiKhoanThu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoanThuTuDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoanThu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoanThu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SoTien = table.Column<double>(type: "numeric(18,2)", nullable: true),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    IdLoaiKhoanThu = table.Column<Guid>(type: "uuid", nullable: false),
                    ThueVAT = table.Column<double>(type: "numeric(5,2)", nullable: true),
                    GomThueVAT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DonViTinh = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucKhoanThuTuDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuTuDo_LoaiKhoanThu_IdLoaiKhoanThu",
                        column: x => x.IdLoaiKhoanThu,
                        principalTable: "LoaiKhoanThu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhungHoSoHSSV",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHoSo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    BatBuoc = table.Column<bool>(type: "boolean", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdTieuChiTuyenSinh = table.Column<Guid>(type: "uuid", nullable: true),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiSinhVien = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucKhungHoSoHSSV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_LoaiSinhVien_IdLoaiSinhVien",
                        column: x => x.IdLoaiSinhVien,
                        principalTable: "LoaiSinhVien",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucKhungHoSoHSSV_TieuChiTuyenSinh_IdTieuChiTuyenSinh",
                        column: x => x.IdTieuChiTuyenSinh,
                        principalTable: "TieuChiTuyenSinh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                columns: new[] { "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_IdBieuMauDanhSachDuThi",
                table: "HinhThucThi",
                column: "IdBieuMauDanhSachDuThi");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi",
                column: "MaHinhThucThi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh",
                column: "MaChuyenNganh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucBieuMau_IdKhoaQuanLy",
                table: "DanhMucBieuMau",
                column: "IdKhoaQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucBieuMau_NguoiCapNhapId",
                table: "DanhMucBieuMau",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucBieuMau_NguoiTaoId",
                table: "DanhMucBieuMau",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_IdLoaiChucVu",
                table: "DanhMucCanSuLop",
                column: "IdLoaiChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_MaChucVu",
                table: "DanhMucCanSuLop",
                column: "MaChucVu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_NguoiCapNhapId",
                table: "DanhMucCanSuLop",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_NguoiTaoId",
                table: "DanhMucCanSuLop",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_MaHoSo",
                table: "DanhMucHoSoHSSV",
                column: "MaHoSo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucHoSoHSSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_NguoiTaoId",
                table: "DanhMucHoSoHSSV",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_MaKhoanChi",
                table: "DanhMucKhoanChi",
                column: "MaKhoanChi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_NguoiCapNhapId",
                table: "DanhMucKhoanChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_NguoiTaoId",
                table: "DanhMucKhoanChi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuHocPhi",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_NguoiTaoId",
                table: "DanhMucKhoanThuHocPhi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_IdLoaiKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "IdLoaiKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiTaoId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_IdLoaiKhoanThu",
                table: "DanhMucKhoanThuTuDo",
                column: "IdLoaiKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_MaKhoanThu",
                table: "DanhMucKhoanThuTuDo",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_NguoiTaoId",
                table: "DanhMucKhoanThuTuDo",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdBacDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdLoaiSinhVien",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdLoaiSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdTieuChiTuyenSinh",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdTieuChiTuyenSinh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_MaHoSo_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                columns: new[] { "MaHoSo", "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_NguoiTaoId",
                table: "DanhMucKhungHoSoHSSV",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_MaLoaiKhoanThu",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "MaLoaiKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiTaoId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_MaLoaiThuPhi",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "MaLoaiThuPhi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiTaoId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_IdKhoa",
                table: "DanhMucNganhDaoTao",
                column: "IdKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_IdKhoiNganh",
                table: "DanhMucNganhDaoTao",
                column: "IdKhoiNganh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaNganh",
                table: "DanhMucNganhDaoTao",
                column: "MaNganh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaTuyenSinh",
                table: "DanhMucNganhDaoTao",
                column: "MaTuyenSinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_NguoiCapNhapId",
                table: "DanhMucNganhDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_NguoiTaoId",
                table: "DanhMucNganhDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_LoaiNoiDung_NoiDung",
                table: "DanhMucNoiDung",
                columns: new[] { "LoaiNoiDung", "NoiDung" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_NguoiCapNhapId",
                table: "DanhMucNoiDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_NguoiTaoId",
                table: "DanhMucNoiDung",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_NguoiCapNhapId",
                table: "LoaiChucVu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_NguoiTaoId",
                table: "LoaiChucVu",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhoanThu_NguoiCapNhapId",
                table: "LoaiKhoanThu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhoanThu_NguoiTaoId",
                table: "LoaiKhoanThu",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSinhVien_NguoiCapNhapId",
                table: "LoaiSinhVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSinhVien_NguoiTaoId",
                table: "LoaiSinhVien",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiTuyenSinh_NguoiCapNhapId",
                table: "TieuChiTuyenSinh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiTuyenSinh_NguoiTaoId",
                table: "TieuChiTuyenSinh",
                column: "NguoiTaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucThi_DanhMucBieuMau_IdBieuMauDanhSachDuThi",
                table: "HinhThucThi",
                column: "IdBieuMauDanhSachDuThi",
                principalTable: "DanhMucBieuMau",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_BacDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdBacDaoTao",
                principalTable: "BacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangDiemTN_NamId",
                table: "ThoiGianDaoTao",
                column: "BangDiemTN_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao",
                column: "BangTotNghiep_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_KhoiNganh_IDKhoiNganh",
                table: "ThoiGianDaoTao",
                column: "IDKhoiNganh",
                principalTable: "KhoiNganh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_LoaiDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdLoaiDaoTao",
                principalTable: "LoaiDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucThi_DanhMucBieuMau_IdBieuMauDanhSachDuThi",
                table: "HinhThucThi");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_BacDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangDiemTN_NamId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_KhoiNganh_IDKhoiNganh",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_LoaiDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropTable(
                name: "DanhMucBieuMau");

            migrationBuilder.DropTable(
                name: "DanhMucCanSuLop");

            migrationBuilder.DropTable(
                name: "DanhMucHoSoHSSV");

            migrationBuilder.DropTable(
                name: "DanhMucKhoanChi");

            migrationBuilder.DropTable(
                name: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropTable(
                name: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropTable(
                name: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropTable(
                name: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropTable(
                name: "DanhMucNganhDaoTao");

            migrationBuilder.DropTable(
                name: "DanhMucNoiDung");

            migrationBuilder.DropTable(
                name: "LoaiChucVu");

            migrationBuilder.DropTable(
                name: "LoaiKhoanThu");

            migrationBuilder.DropTable(
                name: "LoaiSinhVien");

            migrationBuilder.DropTable(
                name: "TieuChiTuyenSinh");

            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_IdBieuMauDanhSachDuThi",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "KyTuMaSV",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "IdBieuMauDanhSachDuThi",
                table: "HinhThucThi");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "STT",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "TenTiengAnh",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "TenVietTat",
                table: "ChuyenNganh");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ThoiGianDaoTao",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHinhThucThi",
                table: "HinhThucThi",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HinhThucThi",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenChuyenNganh",
                table: "ChuyenNganh",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ChuyenNganh",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdBacDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_BacDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdBacDaoTao",
                principalTable: "BacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_BanDiemTN",
                table: "ThoiGianDaoTao",
                column: "BangDiemTN_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_BangTotNghiep",
                table: "ThoiGianDaoTao",
                column: "BangTotNghiep_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_KhoiNganh_IDKhoiNganh",
                table: "ThoiGianDaoTao",
                column: "IDKhoiNganh",
                principalTable: "KhoiNganh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_LoaiDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdLoaiDaoTao",
                principalTable: "LoaiDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
