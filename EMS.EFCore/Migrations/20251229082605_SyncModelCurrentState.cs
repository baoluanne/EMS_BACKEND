using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelCurrentState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ToaNhaKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        TenToaNha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
            //        LoaiToaNha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ToaNhaKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ToaNhaKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ToaNhaKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ViPhamNoiQuyKTX",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
            //        NoiDungViPham = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
            //        HinhThucXuLy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
            //        DiemTru = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
            //        NgayViPham = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ViPhamNoiQuyKTX", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ViPhamNoiQuyKTX_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ViPhamNoiQuyKTX_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
            //            column: x => x.SinhVienId,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PhongKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        MaPhong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
            //        ToaNhaId = table.Column<Guid>(type: "uuid", nullable: false),
            //        SoLuongGiuong = table.Column<int>(type: "integer", nullable: false),
            //        SoLuongDaO = table.Column<int>(type: "integer", nullable: false),
            //        TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
            //        GiaPhong = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PhongKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PhongKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_PhongKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_PhongKtx_ToaNhaKtx_ToaNhaId",
            //            column: x => x.ToaNhaId,
            //            principalTable: "ToaNhaKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChiSoDienNuoc",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        Thang = table.Column<int>(type: "integer", nullable: false),
            //        Nam = table.Column<int>(type: "integer", nullable: false),
            //        DienCu = table.Column<double>(type: "double precision", nullable: false),
            //        DienMoi = table.Column<double>(type: "double precision", nullable: false),
            //        NuocCu = table.Column<double>(type: "double precision", nullable: false),
            //        NuocMoi = table.Column<double>(type: "double precision", nullable: false),
            //        DaChot = table.Column<bool>(type: "boolean", nullable: false),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChiSoDienNuoc", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ChiSoDienNuoc_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ChiSoDienNuoc_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ChiSoDienNuoc_PhongKtx_PhongKtxId",
            //            column: x => x.PhongKtxId,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GiuongKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        MaGiuong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
            //        SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
            //        PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GiuongKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_GiuongKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_GiuongKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_GiuongKtx_PhongKtx_PhongKtxId",
            //            column: x => x.PhongKtxId,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_GiuongKtx_SinhVien_SinhVienId",
            //            column: x => x.SinhVienId,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TaiSanKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        MaTaiSan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
            //        TenTaiSan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
            //        TinhTrang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Tot"),
            //        GiaTri = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
            //        GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
            //        PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TaiSanKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TaiSanKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TaiSanKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TaiSanKtx_PhongKtx_PhongKtxId",
            //            column: x => x.PhongKtxId,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HoaDonKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        Thang = table.Column<int>(type: "integer", nullable: false),
            //        Nam = table.Column<int>(type: "integer", nullable: false),
            //        TienDien = table.Column<decimal>(type: "numeric", nullable: false),
            //        TienNuoc = table.Column<decimal>(type: "numeric", nullable: false),
            //        TienPhong = table.Column<decimal>(type: "numeric", nullable: false),
            //        PhuPhi = table.Column<decimal>(type: "numeric", nullable: false),
            //        TongTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
            //        TrangThai = table.Column<string>(type: "text", nullable: false),
            //        NgayThanhToan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        GhiChu = table.Column<string>(type: "text", nullable: true),
            //        PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        ChiSoDienNuocId = table.Column<Guid>(type: "uuid", nullable: true),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HoaDonKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_HoaDonKtx_ChiSoDienNuoc_ChiSoDienNuocId",
            //            column: x => x.ChiSoDienNuocId,
            //            principalTable: "ChiSoDienNuoc",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_HoaDonKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_HoaDonKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_HoaDonKtx_PhongKtx_PhongKtxId",
            //            column: x => x.PhongKtxId,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DonKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
            //        MaDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        LoaiDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        NgayGuiDon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        NgayHetHan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        Ghichu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
            //        PhongHienTai = table.Column<Guid>(type: "uuid", nullable: true),
            //        phongMuonChuyen = table.Column<Guid>(type: "uuid", nullable: true),
            //        LyDoChuyen = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
            //        PhongDuocDuyet = table.Column<Guid>(type: "uuid", nullable: true),
            //        GiuongDuocDuyet = table.Column<Guid>(type: "uuid", nullable: true),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DonKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DonKtx_GiuongKtx_GiuongDuocDuyet",
            //            column: x => x.GiuongDuocDuyet,
            //            principalTable: "GiuongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DonKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_DonKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_DonKtx_PhongKtx_PhongDuocDuyet",
            //            column: x => x.PhongDuocDuyet,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DonKtx_PhongKtx_PhongHienTai",
            //            column: x => x.PhongHienTai,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DonKtx_PhongKtx_phongMuonChuyen",
            //            column: x => x.phongMuonChuyen,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DonKtx_SinhVien_IdSinhVien",
            //            column: x => x.IdSinhVien,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "YeuCauSuaChua",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
            //        NoiDung = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
            //        TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "MoiGui"),
            //        GhiChuXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
            //        ChiPhiPhatSinh = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
            //        NgayGui = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
            //        NgayXuLy = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        NgayHoanThanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
            //        PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        TaiSanKtxId = table.Column<Guid>(type: "uuid", nullable: true),
            //        HoaDonKtxId = table.Column<Guid>(type: "uuid", nullable: true),
            //        SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_YeuCauSuaChua", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_HoaDonKtx_HoaDonKtxId",
            //            column: x => x.HoaDonKtxId,
            //            principalTable: "HoaDonKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_PhongKtx_PhongKtxId",
            //            column: x => x.PhongKtxId,
            //            principalTable: "PhongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_SinhVien_SinhVienId",
            //            column: x => x.SinhVienId,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_SinhVien_SinhVienId1",
            //            column: x => x.SinhVienId1,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_YeuCauSuaChua_TaiSanKtx_TaiSanKtxId",
            //            column: x => x.TaiSanKtxId,
            //            principalTable: "TaiSanKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CuTruKtx",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
            //        GiuongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
            //        NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
            //        NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
            //        TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "DangO"),
            //        GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
            //        DonKtxId = table.Column<Guid>(type: "uuid", nullable: true),
            //        DonKtxId1 = table.Column<Guid>(type: "uuid", nullable: true),
            //        IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
            //        NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CuTruKtx", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_DonKtx_DonKtxId",
            //            column: x => x.DonKtxId,
            //            principalTable: "DonKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_DonKtx_DonKtxId1",
            //            column: x => x.DonKtxId1,
            //            principalTable: "DonKtx",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_GiuongKtx_GiuongKtxId",
            //            column: x => x.GiuongKtxId,
            //            principalTable: "GiuongKtx",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_NguoiDung_IdNguoiCapNhat",
            //            column: x => x.IdNguoiCapNhat,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_NguoiDung_IdNguoiTao",
            //            column: x => x.IdNguoiTao,
            //            principalTable: "NguoiDung",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_CuTruKtx_SinhVien_SinhVienId",
            //            column: x => x.SinhVienId,
            //            principalTable: "SinhVien",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChiSoDienNuoc_IdNguoiCapNhat",
            //    table: "ChiSoDienNuoc",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChiSoDienNuoc_IdNguoiTao",
            //    table: "ChiSoDienNuoc",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam",
            //    table: "ChiSoDienNuoc",
            //    columns: new[] { "PhongKtxId", "Thang", "Nam" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_DonKtxId",
            //    table: "CuTruKtx",
            //    column: "DonKtxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_DonKtxId1",
            //    table: "CuTruKtx",
            //    column: "DonKtxId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_GiuongKtxId_TrangThai",
            //    table: "CuTruKtx",
            //    columns: new[] { "GiuongKtxId", "TrangThai" },
            //    filter: "\"TrangThai\" = 'DangO'");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_IdNguoiCapNhat",
            //    table: "CuTruKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_IdNguoiTao",
            //    table: "CuTruKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CuTruKtx_SinhVienId_TrangThai",
            //    table: "CuTruKtx",
            //    columns: new[] { "SinhVienId", "TrangThai" },
            //    filter: "\"TrangThai\" = 'DangO'");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_GiuongDuocDuyet",
            //    table: "DonKtx",
            //    column: "GiuongDuocDuyet");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_IdNguoiCapNhat",
            //    table: "DonKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_IdNguoiTao",
            //    table: "DonKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_IdSinhVien",
            //    table: "DonKtx",
            //    column: "IdSinhVien");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_PhongDuocDuyet",
            //    table: "DonKtx",
            //    column: "PhongDuocDuyet");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_PhongHienTai",
            //    table: "DonKtx",
            //    column: "PhongHienTai");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonKtx_phongMuonChuyen",
            //    table: "DonKtx",
            //    column: "phongMuonChuyen");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GiuongKtx_IdNguoiCapNhat",
            //    table: "GiuongKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GiuongKtx_IdNguoiTao",
            //    table: "GiuongKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GiuongKtx_PhongKtxId",
            //    table: "GiuongKtx",
            //    column: "PhongKtxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GiuongKtx_SinhVienId",
            //    table: "GiuongKtx",
            //    column: "SinhVienId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HoaDonKtx_ChiSoDienNuocId",
            //    table: "HoaDonKtx",
            //    column: "ChiSoDienNuocId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HoaDonKtx_IdNguoiCapNhat",
            //    table: "HoaDonKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HoaDonKtx_IdNguoiTao",
            //    table: "HoaDonKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HoaDonKtx_PhongKtxId_Thang_Nam",
            //    table: "HoaDonKtx",
            //    columns: new[] { "PhongKtxId", "Thang", "Nam" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PhongKtx_IdNguoiCapNhat",
            //    table: "PhongKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PhongKtx_IdNguoiTao",
            //    table: "PhongKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PhongKtx_ToaNhaId",
            //    table: "PhongKtx",
            //    column: "ToaNhaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TaiSanKtx_IdNguoiCapNhat",
            //    table: "TaiSanKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TaiSanKtx_IdNguoiTao",
            //    table: "TaiSanKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TaiSanKtx_PhongKtxId",
            //    table: "TaiSanKtx",
            //    column: "PhongKtxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ToaNhaKtx_IdNguoiCapNhat",
            //    table: "ToaNhaKtx",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ToaNhaKtx_IdNguoiTao",
            //    table: "ToaNhaKtx",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ViPhamNoiQuyKTX_IdNguoiCapNhat",
            //    table: "ViPhamNoiQuyKTX",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ViPhamNoiQuyKTX_IdNguoiTao",
            //    table: "ViPhamNoiQuyKTX",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ViPhamNoiQuyKTX_SinhVienId",
            //    table: "ViPhamNoiQuyKTX",
            //    column: "SinhVienId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_HoaDonKtxId",
            //    table: "YeuCauSuaChua",
            //    column: "HoaDonKtxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_IdNguoiCapNhat",
            //    table: "YeuCauSuaChua",
            //    column: "IdNguoiCapNhat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_IdNguoiTao",
            //    table: "YeuCauSuaChua",
            //    column: "IdNguoiTao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_PhongKtxId",
            //    table: "YeuCauSuaChua",
            //    column: "PhongKtxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_SinhVienId",
            //    table: "YeuCauSuaChua",
            //    column: "SinhVienId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_SinhVienId1",
            //    table: "YeuCauSuaChua",
            //    column: "SinhVienId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuCauSuaChua_TaiSanKtxId",
            //    table: "YeuCauSuaChua",
            //    column: "TaiSanKtxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropTable(
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
                name: "ToaNhaKtx");*/
        }
    }
}
