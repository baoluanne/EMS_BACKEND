using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuTruKtx");

            migrationBuilder.DropTable(
                name: "ViPhamNoiQuyKTX");

            migrationBuilder.DropTable(
                name: "YeuCauSuaChua");

            migrationBuilder.DropTable(
                name: "DonKtx");

            migrationBuilder.DropTable(
                name: "HoaDonKtx");

            migrationBuilder.DropTable(
                name: "TaiSanKtx");

            migrationBuilder.DropTable(
                name: "GiuongKtx");

            migrationBuilder.DropTable(
                name: "ChiSoDienNuoc");

            migrationBuilder.DropTable(
                name: "PhongKtx");

            migrationBuilder.DropTable(
                name: "ToaNhaKtx");

            migrationBuilder.CreateTable(
                name: "KtxToaNha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenToaNha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LoaiToaNha = table.Column<int>(type: "integer", maxLength: 50, nullable: true),
                    SoTang = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxToaNha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxToaNha_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxToaNha_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxViPhamNoiQuy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    NoiDungViPham = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    HinhThucXuLy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DiemTru = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    NgayViPham = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxViPhamNoiQuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxViPhamNoiQuy_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxViPhamNoiQuy_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxViPhamNoiQuy_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KtxTang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ToaNhaId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenTang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LoaiTang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoLuongPhong = table.Column<int>(type: "integer", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxTang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxTang_KtxToaNha_ToaNhaId",
                        column: x => x.ToaNhaId,
                        principalTable: "KtxToaNha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxTang_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxTang_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxPhong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TangKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SoLuongGiuong = table.Column<int>(type: "integer", nullable: true),
                    LoaiPhong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxPhong_KtxTang_TangKtxId",
                        column: x => x.TangKtxId,
                        principalTable: "KtxTang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxPhong_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxPhong_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxChiSoDienNuoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    DienCu = table.Column<double>(type: "double precision", nullable: false),
                    DienMoi = table.Column<double>(type: "double precision", nullable: false),
                    NuocCu = table.Column<double>(type: "double precision", nullable: false),
                    NuocMoi = table.Column<double>(type: "double precision", nullable: false),
                    DaChot = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxChiSoDienNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxChiSoDienNuoc_KtxPhong_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxChiSoDienNuoc_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxChiSoDienNuoc_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxGiuong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaGiuong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxGiuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxGiuong_KtxPhong_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxGiuong_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxGiuong_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxGiuong_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KtxYeuCauSuaChua",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NoiDung = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "MoiGui"),
                    GhiChuXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ChiPhiPhatSinh = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    NgayGui = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    NgayXuLy = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxYeuCauSuaChua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxYeuCauSuaChua_KtxPhong_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxYeuCauSuaChua_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxYeuCauSuaChua_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxYeuCauSuaChua_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxYeuCauSuaChua_SinhVien_SinhVienId1",
                        column: x => x.SinhVienId1,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LoaiDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "DangKyMoi"),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "ChoDuyet"),
                    NgayGuiDon = table.Column<DateTime>(type: "date", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "date", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
                    IdGoiDichVu = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongDuocDuyetId = table.Column<Guid>(type: "uuid", nullable: true),
                    GiuongDuocDuyetId = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDon_DanhMucKhoanThuNgoaiHocPhi_IdGoiDichVu",
                        column: x => x.IdGoiDichVu,
                        principalTable: "DanhMucKhoanThuNgoaiHocPhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDon_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDon_KtxGiuong_GiuongDuocDuyetId",
                        column: x => x.GiuongDuocDuyetId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_KtxDon_KtxPhong_PhongDuocDuyetId",
                        column: x => x.PhongDuocDuyetId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_KtxDon_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDon_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDon_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KtxCutru",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "DangO"),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxCutru", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxCutru_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxCutru_KtxGiuong_GiuongKtxId",
                        column: x => x.GiuongKtxId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxCutru_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCutru_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCutru_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxCutru_SinhVien_SinhVienId1",
                        column: x => x.SinhVienId1,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDonChiTiet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDanhMucKhoanThu = table.Column<Guid>(type: "uuid", nullable: false),
                    SoLuong = table.Column<int>(type: "integer", nullable: false),
                    DonGia = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDonChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDonChiTiet_DanhMucKhoanThuNgoaiHocPhi_IdDanhMucKhoanThu",
                        column: x => x.IdDanhMucKhoanThu,
                        principalTable: "DanhMucKhoanThuNgoaiHocPhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonChiTiet_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxDonChiTiet_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonChiTiet_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDonChuyenPhong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongYeuCauId = table.Column<Guid>(type: "uuid", nullable: false),
                    LyDoChuyenPhong = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDonChuyenPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_KtxGiuong_GiuongHienTaiId",
                        column: x => x.GiuongHienTaiId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_KtxPhong_PhongHienTaiId",
                        column: x => x.PhongHienTaiId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_KtxPhong_PhongYeuCauId",
                        column: x => x.PhongYeuCauId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonChuyenPhong_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDonDangKyMoi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongYeuCauId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongYeuCauId = table.Column<Guid>(type: "uuid", nullable: true),
                    LyDo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDonDangKyMoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDonDangKyMoi_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxDonDangKyMoi_KtxGiuong_GiuongYeuCauId",
                        column: x => x.GiuongYeuCauId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonDangKyMoi_KtxPhong_PhongYeuCauId",
                        column: x => x.PhongYeuCauId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonDangKyMoi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonDangKyMoi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDonGiaHan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    LyDo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDonGiaHan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDonGiaHan_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxDonGiaHan_KtxGiuong_GiuongHienTaiId",
                        column: x => x.GiuongHienTaiId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonGiaHan_KtxPhong_PhongHienTaiId",
                        column: x => x.PhongHienTaiId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonGiaHan_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonGiaHan_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KtxDonRoiKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongHienTaiId = table.Column<Guid>(type: "uuid", nullable: false),
                    LyDoRoi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NgayRoiThucTe = table.Column<DateTime>(type: "date", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxDonRoiKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxDonRoiKtx_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KtxDonRoiKtx_KtxGiuong_GiuongHienTaiId",
                        column: x => x.GiuongHienTaiId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonRoiKtx_KtxPhong_PhongHienTaiId",
                        column: x => x.PhongHienTaiId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KtxDonRoiKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxDonRoiKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KtxChiSoDienNuoc_IdNguoiCapNhat",
                table: "KtxChiSoDienNuoc",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxChiSoDienNuoc_IdNguoiTao",
                table: "KtxChiSoDienNuoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxChiSoDienNuoc_Phong_Thang_Nam_Unique",
                table: "KtxChiSoDienNuoc",
                columns: new[] { "PhongKtxId", "Thang", "Nam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_DonKtxId",
                table: "KtxCutru",
                column: "DonKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_GiuongKtxId_TrangThai",
                table: "KtxCutru",
                columns: new[] { "GiuongKtxId", "TrangThai" },
                filter: "\"TrangThai\" = 'DangO'");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_IdNguoiCapNhat",
                table: "KtxCutru",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_IdNguoiTao",
                table: "KtxCutru",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_SinhVienId_TrangThai",
                table: "KtxCutru",
                columns: new[] { "SinhVienId", "TrangThai" },
                filter: "\"TrangThai\" = 'DangO'");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_SinhVienId1",
                table: "KtxCutru",
                column: "SinhVienId1");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_GiuongDuocDuyetId",
                table: "KtxDon",
                column: "GiuongDuocDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_IdGoiDichVu",
                table: "KtxDon",
                column: "IdGoiDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_IdHocKy",
                table: "KtxDon",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_IdNguoiCapNhat",
                table: "KtxDon",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_IdNguoiTao",
                table: "KtxDon",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_LoaiDon",
                table: "KtxDon",
                column: "LoaiDon");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_MaDon",
                table: "KtxDon",
                column: "MaDon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_PhongDuocDuyetId",
                table: "KtxDon",
                column: "PhongDuocDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_SinhVien_HocKy",
                table: "KtxDon",
                columns: new[] { "IdSinhVien", "IdHocKy" });

            migrationBuilder.CreateIndex(
                name: "IX_KtxDon_TrangThai",
                table: "KtxDon",
                column: "TrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChiTiet_DonKtxId_IdDanhMucKhoanThu",
                table: "KtxDonChiTiet",
                columns: new[] { "DonKtxId", "IdDanhMucKhoanThu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChiTiet_IdDanhMucKhoanThu",
                table: "KtxDonChiTiet",
                column: "IdDanhMucKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChiTiet_IdNguoiCapNhat",
                table: "KtxDonChiTiet",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChiTiet_IdNguoiTao",
                table: "KtxDonChiTiet",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_DonKtxId",
                table: "KtxDonChuyenPhong",
                column: "DonKtxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_GiuongHienTaiId",
                table: "KtxDonChuyenPhong",
                column: "GiuongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_IdNguoiCapNhat",
                table: "KtxDonChuyenPhong",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_IdNguoiTao",
                table: "KtxDonChuyenPhong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_PhongHienTaiId",
                table: "KtxDonChuyenPhong",
                column: "PhongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_PhongYeuCauId",
                table: "KtxDonChuyenPhong",
                column: "PhongYeuCauId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonDangKyMoi_DonKtxId",
                table: "KtxDonDangKyMoi",
                column: "DonKtxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonDangKyMoi_GiuongYeuCauId",
                table: "KtxDonDangKyMoi",
                column: "GiuongYeuCauId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonDangKyMoi_IdNguoiCapNhat",
                table: "KtxDonDangKyMoi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonDangKyMoi_IdNguoiTao",
                table: "KtxDonDangKyMoi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonDangKyMoi_PhongYeuCauId",
                table: "KtxDonDangKyMoi",
                column: "PhongYeuCauId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonGiaHan_DonKtxId",
                table: "KtxDonGiaHan",
                column: "DonKtxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonGiaHan_GiuongHienTaiId",
                table: "KtxDonGiaHan",
                column: "GiuongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonGiaHan_IdNguoiCapNhat",
                table: "KtxDonGiaHan",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonGiaHan_IdNguoiTao",
                table: "KtxDonGiaHan",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonGiaHan_PhongHienTaiId",
                table: "KtxDonGiaHan",
                column: "PhongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonRoiKtx_DonKtxId",
                table: "KtxDonRoiKtx",
                column: "DonKtxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonRoiKtx_GiuongHienTaiId",
                table: "KtxDonRoiKtx",
                column: "GiuongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonRoiKtx_IdNguoiCapNhat",
                table: "KtxDonRoiKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonRoiKtx_IdNguoiTao",
                table: "KtxDonRoiKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonRoiKtx_PhongHienTaiId",
                table: "KtxDonRoiKtx",
                column: "PhongHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_IdNguoiCapNhat",
                table: "KtxGiuong",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_IdNguoiTao",
                table: "KtxGiuong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_MaGiuong",
                table: "KtxGiuong",
                column: "MaGiuong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_PhongKtxId",
                table: "KtxGiuong",
                column: "PhongKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_SinhVienId",
                table: "KtxGiuong",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxPhong_IdNguoiCapNhat",
                table: "KtxPhong",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxPhong_IdNguoiTao",
                table: "KtxPhong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxPhong_MaPhong",
                table: "KtxPhong",
                column: "MaPhong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxPhong_TangKtxId",
                table: "KtxPhong",
                column: "TangKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxTang_IdNguoiCapNhat",
                table: "KtxTang",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxTang_IdNguoiTao",
                table: "KtxTang",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxTang_ToaNhaId",
                table: "KtxTang",
                column: "ToaNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxToaNha_IdNguoiCapNhat",
                table: "KtxToaNha",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxToaNha_IdNguoiTao",
                table: "KtxToaNha",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxToaNha_TenToaNha",
                table: "KtxToaNha",
                column: "TenToaNha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_IdNguoiCapNhat",
                table: "KtxViPhamNoiQuy",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_IdNguoiTao",
                table: "KtxViPhamNoiQuy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_SinhVienId",
                table: "KtxViPhamNoiQuy",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxYeuCauSuaChua_IdNguoiCapNhat",
                table: "KtxYeuCauSuaChua",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxYeuCauSuaChua_IdNguoiTao",
                table: "KtxYeuCauSuaChua",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxYeuCauSuaChua_PhongKtxId",
                table: "KtxYeuCauSuaChua",
                column: "PhongKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxYeuCauSuaChua_SinhVienId",
                table: "KtxYeuCauSuaChua",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxYeuCauSuaChua_SinhVienId1",
                table: "KtxYeuCauSuaChua",
                column: "SinhVienId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KtxChiSoDienNuoc");

            migrationBuilder.DropTable(
                name: "KtxCutru");

            migrationBuilder.DropTable(
                name: "KtxDonChiTiet");

            migrationBuilder.DropTable(
                name: "KtxDonChuyenPhong");

            migrationBuilder.DropTable(
                name: "KtxDonDangKyMoi");

            migrationBuilder.DropTable(
                name: "KtxDonGiaHan");

            migrationBuilder.DropTable(
                name: "KtxDonRoiKtx");

            migrationBuilder.DropTable(
                name: "KtxViPhamNoiQuy");

            migrationBuilder.DropTable(
                name: "KtxYeuCauSuaChua");

            migrationBuilder.DropTable(
                name: "KtxDon");

            migrationBuilder.DropTable(
                name: "KtxGiuong");

            migrationBuilder.DropTable(
                name: "KtxPhong");

            migrationBuilder.DropTable(
                name: "KtxTang");

            migrationBuilder.DropTable(
                name: "KtxToaNha");

            migrationBuilder.CreateTable(
                name: "ToaNhaKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LoaiToaNha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenToaNha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToaNhaKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToaNhaKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ToaNhaKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ViPhamNoiQuyKTX",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiemTru = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    HinhThucXuLy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayViPham = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NoiDungViPham = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViPhamNoiQuyKTX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViPhamNoiQuyKTX_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ViPhamNoiQuyKTX_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhongKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    ToaNhaId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiaPhong = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MaPhong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoLuongDaO = table.Column<int>(type: "integer", nullable: false),
                    SoLuongGiuong = table.Column<int>(type: "integer", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongKtx_ToaNhaKtx_ToaNhaId",
                        column: x => x.ToaNhaId,
                        principalTable: "ToaNhaKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiSoDienNuoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    DaChot = table.Column<bool>(type: "boolean", nullable: false),
                    DienCu = table.Column<double>(type: "double precision", nullable: false),
                    DienMoi = table.Column<double>(type: "double precision", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NuocCu = table.Column<double>(type: "double precision", nullable: false),
                    NuocMoi = table.Column<double>(type: "double precision", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiSoDienNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiSoDienNuoc_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiSoDienNuoc_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiSoDienNuoc_PhongKtx_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiuongKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MaGiuong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiuongKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiuongKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiuongKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiuongKtx_PhongKtx_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiuongKtx_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TaiSanKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GiaTri = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MaTaiSan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenTaiSan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TinhTrang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Tot")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSanKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiSanKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiSanKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiSanKtx_PhongKtx_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiSoDienNuocId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhuPhi = table.Column<decimal>(type: "numeric", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    TienDien = table.Column<decimal>(type: "numeric", nullable: false),
                    TienNuoc = table.Column<decimal>(type: "numeric", nullable: false),
                    TienPhong = table.Column<decimal>(type: "numeric", nullable: false),
                    TongTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonKtx_ChiSoDienNuoc_ChiSoDienNuocId",
                        column: x => x.ChiSoDienNuocId,
                        principalTable: "ChiSoDienNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HoaDonKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonKtx_PhongKtx_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongDuocDuyet = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongDuocDuyet = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongHienTai = table.Column<Guid>(type: "uuid", nullable: true),
                    phongMuonChuyen = table.Column<Guid>(type: "uuid", nullable: true),
                    Ghichu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LoaiDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LyDoChuyen = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MaDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayGuiDon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonKtx_GiuongKtx_GiuongDuocDuyet",
                        column: x => x.GiuongDuocDuyet,
                        principalTable: "GiuongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonKtx_PhongKtx_PhongDuocDuyet",
                        column: x => x.PhongDuocDuyet,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonKtx_PhongKtx_PhongHienTai",
                        column: x => x.PhongHienTai,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonKtx_PhongKtx_phongMuonChuyen",
                        column: x => x.phongMuonChuyen,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonKtx_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YeuCauSuaChua",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoaDonKtxId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaiSanKtxId = table.Column<Guid>(type: "uuid", nullable: true),
                    ChiPhiPhatSinh = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GhiChuXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    NgayHoanThanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayXuLy = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "MoiGui")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCauSuaChua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_HoaDonKtx_HoaDonKtxId",
                        column: x => x.HoaDonKtxId,
                        principalTable: "HoaDonKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_PhongKtx_PhongKtxId",
                        column: x => x.PhongKtxId,
                        principalTable: "PhongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_SinhVien_SinhVienId1",
                        column: x => x.SinhVienId1,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YeuCauSuaChua_TaiSanKtx_TaiSanKtxId",
                        column: x => x.TaiSanKtxId,
                        principalTable: "TaiSanKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CuTruKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: true),
                    GiuongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "DangO")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuTruKtx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuTruKtx_DonKtx_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "DonKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CuTruKtx_DonKtx_DonKtxId1",
                        column: x => x.DonKtxId1,
                        principalTable: "DonKtx",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuTruKtx_GiuongKtx_GiuongKtxId",
                        column: x => x.GiuongKtxId,
                        principalTable: "GiuongKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuTruKtx_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuTruKtx_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuTruKtx_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuTruKtx_SinhVien_SinhVienId1",
                        column: x => x.SinhVienId1,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDienNuoc_IdNguoiCapNhat",
                table: "ChiSoDienNuoc",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDienNuoc_IdNguoiTao",
                table: "ChiSoDienNuoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam",
                table: "ChiSoDienNuoc",
                columns: new[] { "PhongKtxId", "Thang", "Nam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_DonKtxId",
                table: "CuTruKtx",
                column: "DonKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_DonKtxId1",
                table: "CuTruKtx",
                column: "DonKtxId1");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_GiuongKtxId_TrangThai",
                table: "CuTruKtx",
                columns: new[] { "GiuongKtxId", "TrangThai" },
                filter: "\"TrangThai\" = 'DangO'");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_IdNguoiCapNhat",
                table: "CuTruKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_IdNguoiTao",
                table: "CuTruKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_SinhVienId_TrangThai",
                table: "CuTruKtx",
                columns: new[] { "SinhVienId", "TrangThai" },
                filter: "\"TrangThai\" = 'DangO'");

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_SinhVienId1",
                table: "CuTruKtx",
                column: "SinhVienId1");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_GiuongDuocDuyet",
                table: "DonKtx",
                column: "GiuongDuocDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_IdNguoiCapNhat",
                table: "DonKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_IdNguoiTao",
                table: "DonKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_IdSinhVien",
                table: "DonKtx",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_MaDon",
                table: "DonKtx",
                column: "MaDon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_PhongDuocDuyet",
                table: "DonKtx",
                column: "PhongDuocDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_PhongHienTai",
                table: "DonKtx",
                column: "PhongHienTai");

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_phongMuonChuyen",
                table: "DonKtx",
                column: "phongMuonChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_IdNguoiCapNhat",
                table: "GiuongKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_IdNguoiTao",
                table: "GiuongKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_MaGiuong",
                table: "GiuongKtx",
                column: "MaGiuong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_PhongKtxId",
                table: "GiuongKtx",
                column: "PhongKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_SinhVienId",
                table: "GiuongKtx",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonKtx_ChiSoDienNuocId",
                table: "HoaDonKtx",
                column: "ChiSoDienNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonKtx_IdNguoiCapNhat",
                table: "HoaDonKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonKtx_IdNguoiTao",
                table: "HoaDonKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonKtx_Phong_Thang_Nam_Unique",
                table: "HoaDonKtx",
                columns: new[] { "PhongKtxId", "Thang", "Nam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhongKtx_IdNguoiCapNhat",
                table: "PhongKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhongKtx_IdNguoiTao",
                table: "PhongKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhongKtx_MaPhong",
                table: "PhongKtx",
                column: "MaPhong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhongKtx_ToaNhaId",
                table: "PhongKtx",
                column: "ToaNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiSanKtx_IdNguoiCapNhat",
                table: "TaiSanKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TaiSanKtx_IdNguoiTao",
                table: "TaiSanKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TaiSanKtx_PhongKtxId",
                table: "TaiSanKtx",
                column: "PhongKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_ToaNhaKtx_IdNguoiCapNhat",
                table: "ToaNhaKtx",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ToaNhaKtx_IdNguoiTao",
                table: "ToaNhaKtx",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ToaNhaKtx_TenToaNha",
                table: "ToaNhaKtx",
                column: "TenToaNha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViPhamNoiQuyKTX_IdNguoiCapNhat",
                table: "ViPhamNoiQuyKTX",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ViPhamNoiQuyKTX_IdNguoiTao",
                table: "ViPhamNoiQuyKTX",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ViPhamNoiQuyKTX_SinhVienId",
                table: "ViPhamNoiQuyKTX",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_HoaDonKtxId",
                table: "YeuCauSuaChua",
                column: "HoaDonKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_IdNguoiCapNhat",
                table: "YeuCauSuaChua",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_IdNguoiTao",
                table: "YeuCauSuaChua",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_PhongKtxId",
                table: "YeuCauSuaChua",
                column: "PhongKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_SinhVienId",
                table: "YeuCauSuaChua",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_SinhVienId1",
                table: "YeuCauSuaChua",
                column: "SinhVienId1");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_TaiSanKtxId",
                table: "YeuCauSuaChua",
                column: "TaiSanKtxId");
        }
    }
}
