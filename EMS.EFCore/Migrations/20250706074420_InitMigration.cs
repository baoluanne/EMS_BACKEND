using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Ho = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenDiem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HashedPassword = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_NguoiDung_IdNguoiCapNhap",
                        column: x => x.IdNguoiCapNhap,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NguoiDung_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Bang_BangDiem_TN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaBang_BangDiem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenBang_BangDiem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_Bang_BangDiem_TN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoSoDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaCoSo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenCoSo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_CoSoDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoSoDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoSoDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucHocBong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDanhMuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenDanhMuc = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucHocBong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucHocBong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucHocBong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucPhongBan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhongBan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenPhongBan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDaoTao = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_DanhMucPhongBan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucPhongBan_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucPhongBan_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HinhThucDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHinhThuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHinhThuc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_HinhThucDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhThucDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HinhThucDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHinhThucThi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHinhThucThi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    HeSoChamThi = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SoGiangVien = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_HinhThucThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhThucThi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HinhThucThi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HocVi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHocVi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHocVi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_HocVi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocVi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HocVi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HTXLViPhamQCThi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaXLQC = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenXLQC = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PhanTramDiemTru = table.Column<int>(type: "integer", nullable: true),
                    MucDo = table.Column<int>(type: "integer", nullable: true),
                    DiemTruRL = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_HTXLViPhamQCThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_Khoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Khoa_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Khoa_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhoaHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenKhoaHoc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nam = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CachViet = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_KhoaHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoaHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhoaHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhoiKienThuc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoiKienThuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhoiKienThuc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_KhoiKienThuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoiKienThuc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhoiKienThuc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhoiNganh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhoiNganh = table.Column<string>(type: "text", nullable: false),
                    TenKhoiNganh = table.Column<string>(type: "text", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_KhoiNganh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoiNganh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhoiNganh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KieuLamTron",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKieuLamTron = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKieuLamTron = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_KieuLamTron", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KieuLamTron_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KieuLamTron_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KieuMonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKieuMonHoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKieuMonHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_KieuMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KieuMonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KieuMonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiChungChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiChungChi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiChungChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiChungChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiChungChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiChungChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiangVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiGiangVien = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiGiangVien = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiGiangVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiGiangVien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiGiangVien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiHinhGiangDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiHinhGiangDay = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiHinhGiangDay = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiHinhGiangDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiMonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiMonHoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiMonHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiMonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiMonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiPhong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiPhong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiPhong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiTiet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiTiet = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiTiet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HeSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_LoaiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiTiet_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiTiet_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LyDoXinPhong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiXinPhong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiXinPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoThuTu = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_LyDoXinPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LyDoXinPhong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LyDoXinPhong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MucDoViPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaMucDoViPham = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenMucDoViPham = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_MucDoViPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MucDoViPham_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MucDoViPham_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NamHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NamHocValue = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NienHoc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TuNgay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoTuan = table.Column<float>(type: "real", precision: 5, scale: 2, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_NamHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NamHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NamHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NamHoc_HocKy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenDot = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: false),
                    SoTuan = table.Column<int>(type: "integer", nullable: false),
                    HeSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDangKyHP = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDangKyNoiTruTT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TuThang = table.Column<int>(type: "integer", nullable: true),
                    DenThang = table.Column<int>(type: "integer", nullable: true),
                    TuNgay = table.Column<int>(type: "integer", nullable: true),
                    DenNgay = table.Column<int>(type: "integer", nullable: true),
                    TenDayDu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NamHoc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_NamHoc_HocKy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NamHoc_HocKy_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NamHoc_HocKy_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhomLoaiHanhViViPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaNhomHanhVi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenNhomHanhVi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_NhomLoaiHanhViViPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhomLoaiKhenThuong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaNhomKhenThuong = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenNhomKhenThuong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_NhomLoaiKhenThuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoiDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenNoiDung = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_NoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoiDung_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NoiDung_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyCheHocVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaQuyChe = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TenQuyChe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BieuThuc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsNienChe = table.Column<bool>(type: "boolean", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DKDT_IsDongHocPhi = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_IsDiemTBTK = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemTBTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsDiemTBTH = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemTBTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsKhongVangQua = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_TongTietVang = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_LyThuyet = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_ThucHanh = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_DuocThiLai = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemThanhPhan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemCuoiKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTB = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTN = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_KieuLamTron = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_QuyCheHocVu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyCheHocVu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyCheHocVu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TieuChuanXetDanhHieu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    NhomDanhHieu = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HocLuc10Tu = table.Column<double>(type: "double precision", nullable: false),
                    HocLuc10Den = table.Column<double>(type: "double precision", nullable: false),
                    HocLuc4Tu = table.Column<double>(type: "double precision", nullable: true),
                    HocLuc4Den = table.Column<double>(type: "double precision", nullable: true),
                    HanhKiemTu = table.Column<double>(type: "double precision", nullable: false),
                    HanhKiemDen = table.Column<double>(type: "double precision", nullable: false),
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
                    table.PrimaryKey("PK_TieuChuanXetDanhHieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TieuChuanXetHocBong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: false),
                    Nhom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HocBong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HocLucDiem10Tu = table.Column<double>(type: "double precision", nullable: false),
                    HocLucDiem10Den = table.Column<double>(type: "double precision", nullable: false),
                    HocLucDiem4Tu = table.Column<double>(type: "double precision", nullable: true),
                    HocLucDiem4Den = table.Column<double>(type: "double precision", nullable: true),
                    HanhKiemTu = table.Column<double>(type: "double precision", nullable: false),
                    HanhKiemDen = table.Column<double>(type: "double precision", nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric", maxLength: 10, nullable: true),
                    PhanTramSoTien = table.Column<decimal>(type: "numeric", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_TieuChuanXetHocBong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TinhChatMonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTinhChatMonHoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenTinhChatMonHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_TinhChatMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinhChatMonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhChatMonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiLopHP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTrangThaiLop = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenTrangThaiLop = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_TrangThaiLopHP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrangThaiLopHP_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrangThaiLopHP_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiXetQuyUoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTrangThaiXetQuyUoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenTrangThaiXetQuyUoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_TrangThaiXetQuyUoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiaDiemPhong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDDPhong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenNhomDDPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    DiaDiem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BanKinh = table.Column<double>(type: "double precision", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_DiaDiemPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaDiemPhong_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaDiemPhong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiaDiemPhong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BacDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaBacDaoTao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenBacDaoTao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DaoTaoMonVanHoa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdHinhThucDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    KyTuMaSinhVien = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    KyTuMaHoSoTuyenSinh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: true),
                    TenLoaiBangCapTN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenLoaiBangCapTN_ENG = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_BacDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacDaoTao_HinhThucDaoTao_IdHinhThucDaoTao",
                        column: x => x.IdHinhThucDaoTao,
                        principalTable: "HinhThucDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BacDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BacDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToBoMon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaToBoMon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenToBoMon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_ToBoMon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToBoMon_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToBoMon_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ToBoMon_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NganhHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaNganhHoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenNganhHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenTiengAnh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MaTuyenSinh = table.Column<string>(type: "text", nullable: false),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    KhoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    KhoiThi = table.Column<string>(type: "text", nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: true),
                    TenVietTat = table.Column<string>(type: "text", nullable: true),
                    KyTuMaSV = table.Column<string>(type: "text", nullable: true),
                    IdKhoiNganh = table.Column<Guid>(type: "uuid", nullable: true),
                    KhoiNganhId = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_NganhHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NganhHoc_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NganhHoc_KhoiNganh_KhoiNganhId",
                        column: x => x.KhoiNganhId,
                        principalTable: "KhoiNganh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NganhHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NganhHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChungChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenLoaiChungChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KyHieu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    GiaTri = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HocPhi = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    LePhiThi = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThoiHan = table.Column<decimal>(type: "numeric", nullable: true),
                    DiemQuyDinh = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdLoaiChungChi = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ChungChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChungChi_LoaiChungChi_IdLoaiChungChi",
                        column: x => x.IdLoaiChungChi,
                        principalTable: "LoaiChungChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChungChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChungChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HinhThucXuLyVPQCThi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHinhThucXL = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenHinhThucXL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhanTramDiemTru = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DiemTruRL = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IdMucDo = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_HinhThucXuLyVPQCThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhThucXuLyVPQCThi_MucDoViPham_IdMucDo",
                        column: x => x.IdMucDo,
                        principalTable: "MucDoViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiHanhViViPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiHanhVi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenLoaiHanhVi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    STT = table.Column<int>(type: "integer", maxLength: 4, nullable: true),
                    DiemTruToiDa = table.Column<int>(type: "integer", nullable: true),
                    IsDiemTruCaoNhat = table.Column<bool>(type: "boolean", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdNhomLoaiHanhVi = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_LoaiHanhViViPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHanhViViPham_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHanhViViPham_NhomLoaiHanhViViPham_IdNhomLoaiHanhVi",
                        column: x => x.IdNhomLoaiHanhVi,
                        principalTable: "NhomLoaiHanhViViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhenThuong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenLoaiKhenThuong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaLoaiKhenThuong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DiemCongToiDa = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdNhomLoaiKhenThuong = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_LoaiKhenThuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiKhenThuong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiKhenThuong_NhomLoaiKhenThuong_IdNhomLoaiKhenThuong",
                        column: x => x.IdNhomLoaiKhenThuong,
                        principalTable: "NhomLoaiKhenThuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiHinhDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiDaoTao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiDaoTao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenTiengAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoThuTu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    HienThiGhiChu = table.Column<bool>(type: "boolean", nullable: true),
                    IdNoiDung = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucLoaiHinhDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucLoaiHinhDaoTao_NoiDung_IdNoiDung",
                        column: x => x.IdNoiDung,
                        principalTable: "NoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiDaoTao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiDaoTao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenTiengAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoThuTu = table.Column<decimal>(type: "numeric", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    HienThiGhiChu = table.Column<bool>(type: "boolean", nullable: true),
                    IdNoiDung = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_LoaiDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiDaoTao_NoiDung_IdNoiDung",
                        column: x => x.IdNoiDung,
                        principalTable: "NoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "QuyChe_NienChe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyCheHocVu = table.Column<Guid>(type: "uuid", nullable: false),
                    HeSoDiemLT = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoDiemTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsTinhTheoDiemLT = table.Column<bool>(type: "boolean", nullable: false),
                    IsCotDiemKTTK = table.Column<bool>(type: "boolean", nullable: false),
                    CotDiemKTTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsRangBuocDiemTK = table.Column<bool>(type: "boolean", nullable: false),
                    DDDS_DiemThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBMon = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemThiTotNghiep = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBTN = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemKTMon = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBChung = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemToanKhoa = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsDaDongHP = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_IsDTBThuongKy = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DTBThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsKhongVangQua = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_PTTongVang = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_PTLyThuyet = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_PTThucHanh = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemThoiHocMoiHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_SoDVHTKhongDatHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemTLNam2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_SoDVHTKhongDatN2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemTLNam3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_SoDVHTKhongDatN3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_IsXetHanhKiem = table.Column<bool>(type: "boolean", nullable: false),
                    DKTH_SoNamXetHanhKiem = table.Column<float>(type: "real", nullable: true),
                    DKTH_IsAutoCheckDongHP = table.Column<bool>(type: "boolean", nullable: false),
                    HB_DiemTB = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HB_DiemHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HB_DiemTBToiThieu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DH_DiemTB = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DH_DiemHanhKiem = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_DTBHocKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_SoDVHTKhongDatHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_DTBNam = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_SoDVHTKhongDatN = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_DiemTichLuyN2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_SoDVHTKhongDatN2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_DiemTichLuyN3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKHT_SoDVHTKhongDatN3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_QuyChe_NienChe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyChe_NienChe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_NienChe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_NienChe_QuyCheHocVu_IdQuyCheHocVu",
                        column: x => x.IdQuyCheHocVu,
                        principalTable: "QuyCheHocVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyChe_TinChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyCheHocVu = table.Column<Guid>(type: "uuid", nullable: false),
                    SoTinhChiNoToiHT = table.Column<int>(type: "integer", nullable: true),
                    IsRangBuocDKT = table.Column<bool>(type: "boolean", nullable: false),
                    HeSoDiemLT = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoDiemTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsTinhTheoDiemLT = table.Column<bool>(type: "boolean", nullable: false),
                    IsSoCotDiemKTTK = table.Column<bool>(type: "boolean", nullable: false),
                    SoCotDiemKTTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBMon = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBChung = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTKMon = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DDDS_DiemTBHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_DaDongHP = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_IsDiemTBThuongKy = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemTBThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsDiemTBThuongXuyen = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemTBThuongXuyen = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsDiemGiuaKy = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemGiuaKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsDiemTieuLuan = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_DiemTieuLuan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_IsKhongVangQua = table.Column<bool>(type: "boolean", nullable: false),
                    DKDT_PTTongVang = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_PTLyThuyet = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKDT_PTThucHanh = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemThoiHocMoiHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_SoHKCanhBaoMax = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemHKDau = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemHKLienTiep = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_HKLienTiep = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_DiemHKTiepTheo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_IsXetTamNgung = table.Column<bool>(type: "boolean", nullable: false),
                    DKTH_XetTamNgungTu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_XetTamNgungDen = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DKTH_SoTNDiemF = table.Column<int>(type: "integer", nullable: true),
                    DKTH_IsKiemTraNoHP = table.Column<bool>(type: "boolean", nullable: false),
                    DKTH_IsSoLanVP = table.Column<bool>(type: "boolean", nullable: false),
                    DKTH_SoLanVP = table.Column<int>(type: "integer", nullable: true),
                    DKTH_IdMucDoVP = table.Column<Guid>(type: "uuid", nullable: true),
                    DKTH_IsShowGCMonHocRot = table.Column<bool>(type: "boolean", nullable: false),
                    DKTH_IsShowGCMonHocKhac = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_IsThangDiem10 = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_IsDiemHaBacTu = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_DiemHaBacTu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HBXL_IsSoLanVPKL = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_SoLanVPKL = table.Column<int>(type: "integer", nullable: true),
                    HBXL_IdMucDoVPKL = table.Column<Guid>(type: "uuid", nullable: true),
                    HBXL_IsSoLanVPQC = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_SoLanVPQC = table.Column<int>(type: "integer", nullable: true),
                    HBXL_IdMucDoVPQC = table.Column<Guid>(type: "uuid", nullable: true),
                    HBXL_IsSoMonTLHL = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_SoMonTLHL = table.Column<int>(type: "integer", nullable: true),
                    HBXL_IsTLHLChiLayMonTBC = table.Column<bool>(type: "boolean", nullable: false),
                    HBXL_IsTLHLChiLauMonCTK = table.Column<bool>(type: "boolean", nullable: false),
                    DH_DiemTB = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DH_DiemHK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DH_SoTCDangKy = table.Column<float>(type: "real", nullable: true),
                    HB_DiemTrungBinh = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HB_DiemTBToiThieu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HB_SoTCDangKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HB_SoTCDKNam = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_QuyChe_TinChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_MucDoViPham_DKTH_IdMucDoVP",
                        column: x => x.DKTH_IdMucDoVP,
                        principalTable: "MucDoViPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_MucDoViPham_HBXL_IdMucDoVPKL",
                        column: x => x.HBXL_IdMucDoVPKL,
                        principalTable: "MucDoViPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_MucDoViPham_HBXL_IdMucDoVPQC",
                        column: x => x.HBXL_IdMucDoVPQC,
                        principalTable: "MucDoViPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChe_TinChi_QuyCheHocVu_IdQuyCheHocVu",
                        column: x => x.IdQuyCheHocVu,
                        principalTable: "QuyCheHocVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XetLLHB_QuyCheTC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyCheHocVu = table.Column<Guid>(type: "uuid", nullable: false),
                    NamThu = table.Column<int>(type: "integer", nullable: true),
                    TCTichLuyTu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    TCTichLuyDen = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DiemTBCTichLuy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_XetLLHB_QuyCheTC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_XetLLHB_QuyCheTC_QuyCheHocVu_IdQuyCheHocVu",
                        column: x => x.IdQuyCheHocVu,
                        principalTable: "QuyCheHocVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayNha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDayNha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenDayNha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoTang = table.Column<int>(type: "integer", nullable: true),
                    SoPhong = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdDiaDiemPhong = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_DayNha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayNha_DiaDiemPhong_IdDiaDiemPhong",
                        column: x => x.IdDiaDiemPhong,
                        principalTable: "DiaDiemPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayNha_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DayNha_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaGiangVien = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HoDem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SoDienThoai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdLoaiGiangVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocVi = table.Column<Guid>(type: "uuid", nullable: true),
                    IDToBoMon = table.Column<Guid>(type: "uuid", nullable: true),
                    TenVietTat = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    HSGV_LT = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    HSGV_TH = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    PhuongTien = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayChamDutHopDong = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsCoiThi = table.Column<bool>(type: "boolean", nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: true),
                    IsKhongChamCong = table.Column<bool>(type: "boolean", nullable: true),
                    IsChamDutHopDong = table.Column<bool>(type: "boolean", nullable: true),
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
                    table.PrimaryKey("PK_GiangVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangVien_HocVi_IdHocVi",
                        column: x => x.IdHocVi,
                        principalTable: "HocVi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiangVien_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangVien_LoaiGiangVien_IdLoaiGiangVien",
                        column: x => x.IdLoaiGiangVien,
                        principalTable: "LoaiGiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangVien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiangVien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiangVien_ToBoMon_IDToBoMon",
                        column: x => x.IDToBoMon,
                        principalTable: "ToBoMon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaMonHoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenMonHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaTuQuan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenVietTat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsKhongTinhTBC = table.Column<bool>(type: "boolean", nullable: true),
                    IdLoaiMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoa = table.Column<Guid>(type: "uuid", nullable: false),
                    IdToBoMon = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLoaiTiet = table.Column<Guid>(type: "uuid", nullable: true),
                    IdKhoiKienThuc = table.Column<Guid>(type: "uuid", nullable: true),
                    IdTinhChatMonHoc = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHoc_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_KhoiKienThuc_IdKhoiKienThuc",
                        column: x => x.IdKhoiKienThuc,
                        principalTable: "KhoiKienThuc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHoc_LoaiMonHoc_IdLoaiMonHoc",
                        column: x => x.IdLoaiMonHoc,
                        principalTable: "LoaiMonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_LoaiTiet_IdLoaiTiet",
                        column: x => x.IdLoaiTiet,
                        principalTable: "LoaiTiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHoc_TinhChatMonHoc_IdTinhChatMonHoc",
                        column: x => x.IdTinhChatMonHoc,
                        principalTable: "TinhChatMonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHoc_ToBoMon_IdToBoMon",
                        column: x => x.IdToBoMon,
                        principalTable: "ToBoMon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChuyenNganh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaChuyenNganh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenChuyenNganh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdNganhHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    MaNganhTuQuan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_ChuyenNganh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenNganh_NganhHoc_IdNganhHoc",
                        column: x => x.IdNganhHoc,
                        principalTable: "NganhHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenNganh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenNganh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HanhViViPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHanhVi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenHanhVi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DiemTru = table.Column<int>(type: "integer", nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DiemTruToiDa = table.Column<int>(type: "integer", nullable: true),
                    IsViPhamNoiTru = table.Column<bool>(type: "boolean", nullable: false),
                    IsKhongSuDung = table.Column<bool>(type: "boolean", nullable: false),
                    MucDo = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdLoaiHanhVi = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_HanhViViPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HanhViViPham_LoaiHanhViViPham_IdLoaiHanhVi",
                        column: x => x.IdLoaiHanhVi,
                        principalTable: "LoaiHanhViViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HanhViViPham_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HanhViViPham_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhenThuong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaKhenThuong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenKhenThuong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiemCong = table.Column<int>(type: "integer", nullable: true),
                    DiemCongToiDa = table.Column<int>(type: "integer", nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsViPhamNoiTru = table.Column<bool>(type: "boolean", nullable: false),
                    IdLoaiKhenThuong = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_KhenThuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhenThuong_LoaiKhenThuong_IdLoaiKhenThuong",
                        column: x => x.IdLoaiKhenThuong,
                        principalTable: "LoaiKhenThuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhenThuong_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhenThuong_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChuanDauRa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCoSo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiChungChi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChungChi = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_ChuanDauRa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_ChungChi_IdChungChi",
                        column: x => x.IdChungChi,
                        principalTable: "ChungChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_CoSoDaoTao_IdCoSo",
                        column: x => x.IdCoSo,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_LoaiChungChi_IdLoaiChungChi",
                        column: x => x.IdLoaiChungChi,
                        principalTable: "LoaiChungChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuanDauRa_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    BangTotNghiep_NamId = table.Column<Guid>(type: "uuid", nullable: true),
                    BangDiemTN_NamId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThoiGianKeHoach = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThoiGianToiThieu = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThoiGianToiDa = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IDKhoiNganh = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_ThoiGianDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_BanDiemTN",
                        column: x => x.BangDiemTN_NamId,
                        principalTable: "Bang_BangDiem_TN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_BangTotNghiep",
                        column: x => x.BangTotNghiep_NamId,
                        principalTable: "Bang_BangDiem_TN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_KhoiNganh_IDKhoiNganh",
                        column: x => x.IDKhoiNganh,
                        principalTable: "KhoiNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThoiGianDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyUocCotDiem_NC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenQuyUoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdQuyChe_NienChe = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKieuMon = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKieuLamTron = table.Column<Guid>(type: "uuid", nullable: true),
                    IsKhongTinhTBC = table.Column<bool>(type: "boolean", nullable: true),
                    DiemTBC = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsChiDiemCuoiKy = table.Column<bool>(type: "boolean", nullable: true),
                    IsChiDanhGia = table.Column<bool>(type: "boolean", nullable: true),
                    IsSuDung = table.Column<bool>(type: "boolean", nullable: true),
                    ChuyenCan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SoCotChuyenCan = table.Column<int>(type: "integer", nullable: true),
                    SoCotThucHanh = table.Column<int>(type: "integer", nullable: true),
                    HeSoTheoDVHT = table.Column<bool>(type: "boolean", nullable: true),
                    SoCotLTHS1 = table.Column<int>(type: "integer", nullable: true),
                    SoCotLTHS2 = table.Column<int>(type: "integer", nullable: true),
                    SoCotLTHS3 = table.Column<int>(type: "integer", nullable: true),
                    SoCotTHHS1 = table.Column<int>(type: "integer", nullable: true),
                    SoCotTHHS2 = table.Column<int>(type: "integer", nullable: true),
                    SoCotTHHS3 = table.Column<int>(type: "integer", nullable: true),
                    HeSoTBTK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoCK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoTheoLTTH_TC = table.Column<bool>(type: "boolean", nullable: true),
                    HeSoLT = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsApDungQuyCheNghe = table.Column<bool>(type: "boolean", nullable: true),
                    IsApDungQuyCheMonVH = table.Column<bool>(type: "boolean", nullable: true),
                    IsRangBuocDCK = table.Column<bool>(type: "boolean", nullable: true),
                    DiemRangBuocCK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsXetDuThiGK = table.Column<bool>(type: "boolean", nullable: true),
                    IsKhongApDungHSCD = table.Column<bool>(type: "boolean", nullable: true),
                    DRB_CotDiemGK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_CotDiemCC = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemGiuaKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemChuyenCan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemTieuLuan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SoCotDiemGK = table.Column<int>(type: "integer", nullable: true),
                    SoCotDiemCC = table.Column<int>(type: "integer", nullable: true),
                    DRB_CongThucTinhDTB_TK = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DRB_GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DRB_ThangDiemMax = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_QuyUocCotDiem_NC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_NC_KieuLamTron_IdKieuLamTron",
                        column: x => x.IdKieuLamTron,
                        principalTable: "KieuLamTron",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_NC_KieuMonHoc_IdKieuMon",
                        column: x => x.IdKieuMon,
                        principalTable: "KieuMonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_NC_QuyChe_NienChe_IdQuyChe_NienChe",
                        column: x => x.IdQuyChe_NienChe,
                        principalTable: "QuyChe_NienChe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApDungQuyCheHocVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyCheTC = table.Column<Guid>(type: "uuid", nullable: true),
                    IdQuyCheNC = table.Column<Guid>(type: "uuid", nullable: true),
                    ChoPhepNoMon = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    ChoPhepNoDVHT = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_ApDungQuyCheHocVu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApDungQuyCheHocVu_QuyChe_NienChe_IdQuyCheNC",
                        column: x => x.IdQuyCheNC,
                        principalTable: "QuyChe_NienChe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApDungQuyCheHocVu_QuyChe_TinChi_IdQuyCheTC",
                        column: x => x.IdQuyCheTC,
                        principalTable: "QuyChe_TinChi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyUocCotDiem_TC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenQuyUoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdQuyChe_TinChi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKieuMon = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKieuLamTron = table.Column<Guid>(type: "uuid", nullable: true),
                    IsKhongTinhTBC = table.Column<bool>(type: "boolean", nullable: true),
                    DiemTBC = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsChiDiemCuoiKy = table.Column<bool>(type: "boolean", nullable: true),
                    IsChiDanhGia = table.Column<bool>(type: "boolean", nullable: true),
                    IsXetDuThiGiuaKy = table.Column<bool>(type: "boolean", nullable: true),
                    IsSuDung = table.Column<bool>(type: "boolean", nullable: true),
                    ChuyenCan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThuongXuyen1 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThuongXuyen2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThuongXuyen3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThuongXuyen4 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    ThuongXuyen5 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    TieuLuan_BTL = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    CuoiKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SoCotDiemTH = table.Column<int>(type: "integer", nullable: true),
                    IsHSLTTH_TC = table.Column<bool>(type: "boolean", nullable: true),
                    HeSoTH = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HeSoLT = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    IsDiemRangBuocCK = table.Column<bool>(type: "boolean", nullable: true),
                    DiemRangBuocCK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_CotDiemGK = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_CotDiemCC = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemThuongKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemGiuaKy = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_CongThucTinhDTB_TK = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DRB_GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DRB_DiemChuyenCan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_DiemTieuLuan = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DRB_ThangDiemMax = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_QuyUocCotDiem_TC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_TC_KieuLamTron_IdKieuLamTron",
                        column: x => x.IdKieuLamTron,
                        principalTable: "KieuLamTron",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_TC_KieuMonHoc_IdKieuMon",
                        column: x => x.IdKieuMon,
                        principalTable: "KieuMonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_TC_QuyChe_TinChi_IdQuyChe_TinChi",
                        column: x => x.IdQuyChe_TinChi,
                        principalTable: "QuyChe_TinChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChung_QuyCheTC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyCheTC = table.Column<Guid>(type: "uuid", nullable: false),
                    DiemTKTrongSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DiemGKTrongSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DiemTieuLuanTrongSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    DiemCuoiKyTrongSo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_ThongTinChung_QuyCheTC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThongTinChung_QuyCheTC_QuyChe_TinChi_IdQuyCheTC",
                        column: x => x.IdQuyCheTC,
                        principalTable: "QuyChe_TinChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhongHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoBan = table.Column<int>(type: "integer", nullable: true),
                    SoChoNgoi = table.Column<int>(type: "integer", nullable: true),
                    SoChoThi = table.Column<int>(type: "integer", nullable: true),
                    IsNgungDungMayChieu = table.Column<bool>(type: "boolean", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdDayNha = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTCMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiPhong = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_PhongHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongHoc_DayNha_IdDayNha",
                        column: x => x.IdDayNha,
                        principalTable: "DayNha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhongHoc_LoaiPhong_IdLoaiPhong",
                        column: x => x.IdLoaiPhong,
                        principalTable: "LoaiPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhongHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongHoc_TinhChatMonHoc_IdTCMonHoc",
                        column: x => x.IdTCMonHoc,
                        principalTable: "TinhChatMonHoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonHocBacDaoTao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DVHT_TC = table.Column<double>(type: "double precision", precision: 5, scale: 2, nullable: true),
                    SoTinChi = table.Column<int>(type: "integer", nullable: true),
                    SoTietLyThuyet = table.Column<int>(type: "integer", nullable: true),
                    SoTietThucHanh = table.Column<int>(type: "integer", nullable: true),
                    TuHoc = table.Column<int>(type: "integer", nullable: true),
                    SoLanKTDinhKy = table.Column<int>(type: "integer", nullable: true),
                    ThucHanh = table.Column<int>(type: "integer", nullable: true),
                    LyThuyet = table.Column<int>(type: "integer", nullable: true),
                    MoRong = table.Column<int>(type: "integer", nullable: true),
                    SoTietLTT = table.Column<int>(type: "integer", nullable: true),
                    SoTietTHBT = table.Column<int>(type: "integer", nullable: true),
                    IsLyThuyet = table.Column<bool>(type: "boolean", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    SoTietTuHoc = table.Column<int>(type: "integer", nullable: true),
                    SoGioThucTap = table.Column<int>(type: "integer", nullable: true),
                    SoGioDoAnBTLon = table.Column<int>(type: "integer", nullable: true),
                    SoTietKT = table.Column<int>(type: "integer", nullable: true),
                    DVHT_HP = table.Column<double>(type: "double precision", precision: 5, scale: 2, nullable: true),
                    DVHT_Le = table.Column<double>(type: "double precision", precision: 5, scale: 2, nullable: true),
                    IsKhongTinhDiemTBC = table.Column<bool>(type: "boolean", nullable: true),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdHinhThucThi = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLoaiHinhGiangDay = table.Column<Guid>(type: "uuid", nullable: true),
                    IdLoaiTiet = table.Column<Guid>(type: "uuid", nullable: true),
                    MonHocId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_MonHocBacDaoTao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_HinhThucThi_IdHinhThucThi",
                        column: x => x.IdHinhThucThi,
                        principalTable: "HinhThucThi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_LoaiHinhGiangDay_IdLoaiHinhGiangDay",
                        column: x => x.IdLoaiHinhGiangDay,
                        principalTable: "LoaiHinhGiangDay",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_LoaiTiet_IdLoaiTiet",
                        column: x => x.IdLoaiTiet,
                        principalTable: "LoaiTiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocBacDaoTao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhKhungNienChe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaChuongTrinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenChuongTrinh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsBlock = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    GhiChuTiengAnh = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNganhHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ChuongTrinhKhungNienChe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_NganhHoc_IdNganhHoc",
                        column: x => x.IdNganhHoc,
                        principalTable: "NganhHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LopNienChe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLop = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLop = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNganh = table.Column<Guid>(type: "uuid", nullable: true),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_LopNienChe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopNienChe_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_NganhHoc_IdNganh",
                        column: x => x.IdNganh,
                        principalTable: "NganhHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopNienChe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyChuanDauRa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChungChi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsChuanDauRaBoSung = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_QuyChuanDauRa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_ChungChi_IdChungChi",
                        column: x => x.IdChungChi,
                        principalTable: "ChungChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyChuanDauRa_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhSachKhoaSuDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPhong = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaSuDung = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_DanhSachKhoaSuDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhSachKhoaSuDung_Khoa_IdKhoaSuDung",
                        column: x => x.IdKhoaSuDung,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhSachKhoaSuDung_PhongHoc_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "PhongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyUocCotDiem_MonHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyUocCotDiem_NC = table.Column<Guid>(type: "uuid", nullable: false),
                    IdQuyUocCotDiem_TC = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHocBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTrangThaiXetQuyUoc = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_QuyUocCotDiem_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_MonHocBacDaoTao_IdMonHocBacDaoTao",
                        column: x => x.IdMonHocBacDaoTao,
                        principalTable: "MonHocBacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_QuyUocCotDiem_NC_IdQuyUocCotDiem_NC",
                        column: x => x.IdQuyUocCotDiem_NC,
                        principalTable: "QuyUocCotDiem_NC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_QuyUocCotDiem_TC_IdQuyUocCotDiem_TC",
                        column: x => x.IdQuyUocCotDiem_TC,
                        principalTable: "QuyUocCotDiem_TC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyUocCotDiem_MonHoc_TrangThaiXetQuyUoc_IdTrangThaiXetQuyUoc",
                        column: x => x.IdTrangThaiXetQuyUoc,
                        principalTable: "TrangThaiXetQuyUoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChuongTrinhKhung_NienChe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsBatBuoc = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IdChuongTrinhKhung = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHocHeDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    HocKy = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_ChiTietChuongTrinhKhung_NienChe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietChuongTrinhKhung_NienChe_ChuongTrinhKhungNienChe_IdC~",
                        column: x => x.IdChuongTrinhKhung,
                        principalTable: "ChuongTrinhKhungNienChe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietChuongTrinhKhung_NienChe_MonHocBacDaoTao_IdMonHocHeD~",
                        column: x => x.IdMonHocHeDaoTao,
                        principalTable: "MonHocBacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanMonLopHoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHocBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopNienChe = table.Column<Guid>(type: "uuid", nullable: false),
                    HocKy = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_PhanMonLopHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanMonLopHoc_LopNienChe_IdLopNienChe",
                        column: x => x.IdLopNienChe,
                        principalTable: "LopNienChe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanMonLopHoc_MonHocBacDaoTao_IdMonHocBacDaoTao",
                        column: x => x.IdMonHocBacDaoTao,
                        principalTable: "MonHocBacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanMonLopHoc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanMonLopHoc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdQuyCheNC",
                table: "ApDungQuyCheHocVu",
                column: "IdQuyCheNC");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdQuyCheTC",
                table: "ApDungQuyCheHocVu",
                column: "IdQuyCheTC");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_NguoiCapNhapId",
                table: "ApDungQuyCheHocVu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_NguoiTaoId",
                table: "ApDungQuyCheHocVu",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_IdHinhThucDaoTao",
                table: "BacDaoTao",
                column: "IdHinhThucDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_NguoiCapNhapId",
                table: "BacDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_NguoiTaoId",
                table: "BacDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_MaBang_BangDiem",
                table: "Bang_BangDiem_TN",
                column: "MaBang_BangDiem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_NguoiCapNhapId",
                table: "Bang_BangDiem_TN",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_NguoiTaoId",
                table: "Bang_BangDiem_TN",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdChuongTrinhKhung",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdChuongTrinhKhung");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdMonHocHeDaoTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdMonHocHeDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiTaoId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdBacDaoTao",
                table: "ChuanDauRa",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdChungChi",
                table: "ChuanDauRa",
                column: "IdChungChi");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdCoSo",
                table: "ChuanDauRa",
                column: "IdCoSo");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdKhoaHoc",
                table: "ChuanDauRa",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdLoaiChungChi",
                table: "ChuanDauRa",
                column: "IdLoaiChungChi");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdLoaiDaoTao",
                table: "ChuanDauRa",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_NguoiCapNhapId",
                table: "ChuanDauRa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_NguoiTaoId",
                table: "ChuanDauRa",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChi_IdLoaiChungChi",
                table: "ChungChi",
                column: "IdLoaiChungChi");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChi_NguoiCapNhapId",
                table: "ChungChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChi_NguoiTaoId",
                table: "ChungChi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdBacDaoTao",
                table: "ChuongTrinhKhungNienChe",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdChuyenNganh",
                table: "ChuongTrinhKhungNienChe",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdCoSoDaoTao",
                table: "ChuongTrinhKhungNienChe",
                column: "IdCoSoDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdKhoaHoc",
                table: "ChuongTrinhKhungNienChe",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdLoaiDaoTao",
                table: "ChuongTrinhKhungNienChe",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdNganhHoc",
                table: "ChuongTrinhKhungNienChe",
                column: "IdNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_NguoiTaoId",
                table: "ChuongTrinhKhungNienChe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_IdNganhHoc",
                table: "ChuyenNganh",
                column: "IdNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_NguoiCapNhapId",
                table: "ChuyenNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_NguoiTaoId",
                table: "ChuyenNganh",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CoSoDaoTao_NguoiCapNhapId",
                table: "CoSoDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_CoSoDaoTao_NguoiTaoId",
                table: "CoSoDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHocBong_NguoiCapNhapId",
                table: "DanhMucHocBong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHocBong_NguoiTaoId",
                table: "DanhMucHocBong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_NguoiTaoId",
                table: "DanhMucLoaiHinhDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhongBan_NguoiCapNhapId",
                table: "DanhMucPhongBan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhongBan_NguoiTaoId",
                table: "DanhMucPhongBan",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung",
                column: "IdKhoaSuDung");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_IdPhong_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung",
                columns: new[] { "IdPhong", "IdKhoaSuDung" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_NguoiCapNhapId",
                table: "DanhSachKhoaSuDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_NguoiTaoId",
                table: "DanhSachKhoaSuDung",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DayNha_IdDiaDiemPhong",
                table: "DayNha",
                column: "IdDiaDiemPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DayNha_NguoiCapNhapId",
                table: "DayNha",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DayNha_NguoiTaoId",
                table: "DayNha",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemPhong_IdCoSoDaoTao",
                table: "DiaDiemPhong",
                column: "IdCoSoDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemPhong_NguoiCapNhapId",
                table: "DiaDiemPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemPhong_NguoiTaoId",
                table: "DiaDiemPhong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_IdHocVi",
                table: "GiangVien",
                column: "IdHocVi");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_IdKhoa",
                table: "GiangVien",
                column: "IdKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_IdLoaiGiangVien",
                table: "GiangVien",
                column: "IdLoaiGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_IDToBoMon",
                table: "GiangVien",
                column: "IDToBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_NguoiCapNhapId",
                table: "GiangVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_NguoiTaoId",
                table: "GiangVien",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HanhViViPham_IdLoaiHanhVi",
                table: "HanhViViPham",
                column: "IdLoaiHanhVi");

            migrationBuilder.CreateIndex(
                name: "IX_HanhViViPham_NguoiCapNhapId",
                table: "HanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HanhViViPham_NguoiTaoId",
                table: "HanhViViPham",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucDaoTao_NguoiCapNhapId",
                table: "HinhThucDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucDaoTao_NguoiTaoId",
                table: "HinhThucDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_NguoiCapNhapId",
                table: "HinhThucThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_NguoiTaoId",
                table: "HinhThucThi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_IdMucDo",
                table: "HinhThucXuLyVPQCThi",
                column: "IdMucDo");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_MaHinhThucXL",
                table: "HinhThucXuLyVPQCThi",
                column: "MaHinhThucXL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_NguoiTaoId",
                table: "HinhThucXuLyVPQCThi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVi_NguoiCapNhapId",
                table: "HocVi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVi_NguoiTaoId",
                table: "HocVi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HTXLViPhamQCThi_NguoiCapNhapId",
                table: "HTXLViPhamQCThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HTXLViPhamQCThi_NguoiTaoId",
                table: "HTXLViPhamQCThi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_IdLoaiKhenThuong",
                table: "KhenThuong",
                column: "IdLoaiKhenThuong");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_NguoiCapNhapId",
                table: "KhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_NguoiTaoId",
                table: "KhenThuong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_NguoiCapNhapId",
                table: "Khoa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_NguoiTaoId",
                table: "Khoa",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_NguoiCapNhapId",
                table: "KhoaHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_NguoiTaoId",
                table: "KhoaHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiKienThuc_NguoiCapNhapId",
                table: "KhoiKienThuc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiKienThuc_NguoiTaoId",
                table: "KhoiKienThuc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiNganh_NguoiCapNhapId",
                table: "KhoiNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiNganh_NguoiTaoId",
                table: "KhoiNganh",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuLamTron_NguoiCapNhapId",
                table: "KieuLamTron",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuLamTron_NguoiTaoId",
                table: "KieuLamTron",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuMonHoc_NguoiCapNhapId",
                table: "KieuMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuMonHoc_NguoiTaoId",
                table: "KieuMonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChungChi_NguoiCapNhapId",
                table: "LoaiChungChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChungChi_NguoiTaoId",
                table: "LoaiChungChi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_IdNoiDung",
                table: "LoaiDaoTao",
                column: "IdNoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_NguoiCapNhapId",
                table: "LoaiDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_NguoiTaoId",
                table: "LoaiDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiGiangVien_NguoiCapNhapId",
                table: "LoaiGiangVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiGiangVien_NguoiTaoId",
                table: "LoaiGiangVien",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHanhViViPham_IdNhomLoaiHanhVi",
                table: "LoaiHanhViViPham",
                column: "IdNhomLoaiHanhVi");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHanhViViPham_NguoiCapNhapId",
                table: "LoaiHanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHanhViViPham_NguoiTaoId",
                table: "LoaiHanhViViPham",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHinhGiangDay_NguoiCapNhapId",
                table: "LoaiHinhGiangDay",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHinhGiangDay_NguoiTaoId",
                table: "LoaiHinhGiangDay",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhenThuong_IdNhomLoaiKhenThuong",
                table: "LoaiKhenThuong",
                column: "IdNhomLoaiKhenThuong");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhenThuong_NguoiCapNhapId",
                table: "LoaiKhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhenThuong_NguoiTaoId",
                table: "LoaiKhenThuong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiMonHoc_NguoiCapNhapId",
                table: "LoaiMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiMonHoc_NguoiTaoId",
                table: "LoaiMonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiPhong_NguoiCapNhapId",
                table: "LoaiPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiPhong_NguoiTaoId",
                table: "LoaiPhong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTiet_NguoiCapNhapId",
                table: "LoaiTiet",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTiet_NguoiTaoId",
                table: "LoaiTiet",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdChuyenNganh",
                table: "LopNienChe",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdCoSoDaoTao",
                table: "LopNienChe",
                column: "IdCoSoDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdKhoaHoc",
                table: "LopNienChe",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdLoaiDaoTao",
                table: "LopNienChe",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdNganh",
                table: "LopNienChe",
                column: "IdNganh");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_NguoiCapNhapId",
                table: "LopNienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_NguoiTaoId",
                table: "LopNienChe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LyDoXinPhong_NguoiCapNhapId",
                table: "LyDoXinPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LyDoXinPhong_NguoiTaoId",
                table: "LyDoXinPhong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdKhoa",
                table: "MonHoc",
                column: "IdKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdKhoiKienThuc",
                table: "MonHoc",
                column: "IdKhoiKienThuc");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdLoaiMonHoc",
                table: "MonHoc",
                column: "IdLoaiMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdLoaiTiet",
                table: "MonHoc",
                column: "IdLoaiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdTinhChatMonHoc",
                table: "MonHoc",
                column: "IdTinhChatMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdToBoMon",
                table: "MonHoc",
                column: "IdToBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaMonHoc",
                table: "MonHoc",
                column: "MaMonHoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_NguoiCapNhapId",
                table: "MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_NguoiTaoId",
                table: "MonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdBacDaoTao",
                table: "MonHocBacDaoTao",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdHinhThucThi",
                table: "MonHocBacDaoTao",
                column: "IdHinhThucThi");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdLoaiHinhGiangDay",
                table: "MonHocBacDaoTao",
                column: "IdLoaiHinhGiangDay");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdLoaiTiet",
                table: "MonHocBacDaoTao",
                column: "IdLoaiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_MonHocId",
                table: "MonHocBacDaoTao",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_NguoiCapNhapId",
                table: "MonHocBacDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_NguoiTaoId",
                table: "MonHocBacDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MucDoViPham_NguoiCapNhapId",
                table: "MucDoViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MucDoViPham_NguoiTaoId",
                table: "MucDoViPham",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_NguoiCapNhapId",
                table: "NamHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_NguoiTaoId",
                table: "NamHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_HocKy_NguoiCapNhapId",
                table: "NamHoc_HocKy",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_HocKy_NguoiTaoId",
                table: "NamHoc_HocKy",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_KhoaId",
                table: "NganhHoc",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_KhoiNganhId",
                table: "NganhHoc",
                column: "KhoiNganhId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_NguoiCapNhapId",
                table: "NganhHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_NguoiTaoId",
                table: "NganhHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_IdNguoiCapNhap",
                table: "NguoiDung",
                column: "IdNguoiCapNhap");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_IdNguoiTao",
                table: "NguoiDung",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiHanhViViPham_NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiHanhViViPham_NguoiTaoId",
                table: "NhomLoaiHanhViViPham",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiKhenThuong_NguoiCapNhapId",
                table: "NhomLoaiKhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiKhenThuong_NguoiTaoId",
                table: "NhomLoaiKhenThuong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDung_NguoiCapNhapId",
                table: "NoiDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDung_NguoiTaoId",
                table: "NoiDung",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_IdLopNienChe",
                table: "PhanMonLopHoc",
                column: "IdLopNienChe");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_IdMonHocBacDaoTao",
                table: "PhanMonLopHoc",
                column: "IdMonHocBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_NguoiCapNhapId",
                table: "PhanMonLopHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_NguoiTaoId",
                table: "PhanMonLopHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_IdDayNha",
                table: "PhongHoc",
                column: "IdDayNha");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_IdLoaiPhong",
                table: "PhongHoc",
                column: "IdLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_IdTCMonHoc",
                table: "PhongHoc",
                column: "IdTCMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_NguoiCapNhapId",
                table: "PhongHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_NguoiTaoId",
                table: "PhongHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_NienChe_IdQuyCheHocVu",
                table: "QuyChe_NienChe",
                column: "IdQuyCheHocVu");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_NienChe_NguoiCapNhapId",
                table: "QuyChe_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_NienChe_NguoiTaoId",
                table: "QuyChe_NienChe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_DKTH_IdMucDoVP",
                table: "QuyChe_TinChi",
                column: "DKTH_IdMucDoVP");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_HBXL_IdMucDoVPKL",
                table: "QuyChe_TinChi",
                column: "HBXL_IdMucDoVPKL");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_HBXL_IdMucDoVPQC",
                table: "QuyChe_TinChi",
                column: "HBXL_IdMucDoVPQC");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_IdQuyCheHocVu",
                table: "QuyChe_TinChi",
                column: "IdQuyCheHocVu");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_NguoiCapNhapId",
                table: "QuyChe_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_NguoiTaoId",
                table: "QuyChe_TinChi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyCheHocVu_NguoiCapNhapId",
                table: "QuyCheHocVu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyCheHocVu_NguoiTaoId",
                table: "QuyCheHocVu",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdBacDaoTao",
                table: "QuyChuanDauRa",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdChungChi",
                table: "QuyChuanDauRa",
                column: "IdChungChi");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdChuyenNganh",
                table: "QuyChuanDauRa",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdCoSoDaoTao_IdKhoaHoc_IdBacDaoTao_IdLoaiDaoT~",
                table: "QuyChuanDauRa",
                columns: new[] { "IdCoSoDaoTao", "IdKhoaHoc", "IdBacDaoTao", "IdLoaiDaoTao", "IdChungChi" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdKhoaHoc",
                table: "QuyChuanDauRa",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdLoaiDaoTao",
                table: "QuyChuanDauRa",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_NguoiCapNhapId",
                table: "QuyChuanDauRa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_NguoiTaoId",
                table: "QuyChuanDauRa",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdMonHocBacDaoTao",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdMonHocBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdQuyUocCotDiem_NC",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdQuyUocCotDiem_NC");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdQuyUocCotDiem_TC",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdQuyUocCotDiem_TC");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdTrangThaiXetQuyUoc",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdTrangThaiXetQuyUoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_NguoiTaoId",
                table: "QuyUocCotDiem_MonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_IdKieuLamTron",
                table: "QuyUocCotDiem_NC",
                column: "IdKieuLamTron");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_IdKieuMon",
                table: "QuyUocCotDiem_NC",
                column: "IdKieuMon");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_IdQuyChe_NienChe",
                table: "QuyUocCotDiem_NC",
                column: "IdQuyChe_NienChe");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_NguoiCapNhapId",
                table: "QuyUocCotDiem_NC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_NguoiTaoId",
                table: "QuyUocCotDiem_NC",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_IdKieuLamTron",
                table: "QuyUocCotDiem_TC",
                column: "IdKieuLamTron");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_IdKieuMon",
                table: "QuyUocCotDiem_TC",
                column: "IdKieuMon");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_IdQuyChe_TinChi",
                table: "QuyUocCotDiem_TC",
                column: "IdQuyChe_TinChi");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_NguoiCapNhapId",
                table: "QuyUocCotDiem_TC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_NguoiTaoId",
                table: "QuyUocCotDiem_TC",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_BangDiemTN_NamId",
                table: "ThoiGianDaoTao",
                column: "BangDiemTN_NamId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao",
                column: "BangTotNghiep_NamId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IDKhoiNganh",
                table: "ThoiGianDaoTao",
                column: "IDKhoiNganh");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_NguoiCapNhapId",
                table: "ThoiGianDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_NguoiTaoId",
                table: "ThoiGianDaoTao",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChung_QuyCheTC_IdQuyCheTC",
                table: "ThongTinChung_QuyCheTC",
                column: "IdQuyCheTC");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChung_QuyCheTC_NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChung_QuyCheTC_NguoiTaoId",
                table: "ThongTinChung_QuyCheTC",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetDanhHieu_NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetDanhHieu_NguoiTaoId",
                table: "TieuChuanXetDanhHieu",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetHocBong_NguoiCapNhapId",
                table: "TieuChuanXetHocBong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetHocBong_NguoiTaoId",
                table: "TieuChuanXetHocBong",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhChatMonHoc_NguoiCapNhapId",
                table: "TinhChatMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhChatMonHoc_NguoiTaoId",
                table: "TinhChatMonHoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToBoMon_IdKhoa",
                table: "ToBoMon",
                column: "IdKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_ToBoMon_NguoiCapNhapId",
                table: "ToBoMon",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ToBoMon_NguoiTaoId",
                table: "ToBoMon",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiLopHP_NguoiCapNhapId",
                table: "TrangThaiLopHP",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiLopHP_NguoiTaoId",
                table: "TrangThaiLopHP",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiXetQuyUoc_NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiXetQuyUoc_NguoiTaoId",
                table: "TrangThaiXetQuyUoc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_XetLLHB_QuyCheTC_IdQuyCheHocVu",
                table: "XetLLHB_QuyCheTC",
                column: "IdQuyCheHocVu");

            migrationBuilder.CreateIndex(
                name: "IX_XetLLHB_QuyCheTC_NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_XetLLHB_QuyCheTC_NguoiTaoId",
                table: "XetLLHB_QuyCheTC",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApDungQuyCheHocVu");

            migrationBuilder.DropTable(
                name: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropTable(
                name: "ChuanDauRa");

            migrationBuilder.DropTable(
                name: "DanhMucHocBong");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropTable(
                name: "DanhMucPhongBan");

            migrationBuilder.DropTable(
                name: "DanhSachKhoaSuDung");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "HanhViViPham");

            migrationBuilder.DropTable(
                name: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropTable(
                name: "HTXLViPhamQCThi");

            migrationBuilder.DropTable(
                name: "KhenThuong");

            migrationBuilder.DropTable(
                name: "LyDoXinPhong");

            migrationBuilder.DropTable(
                name: "NamHoc");

            migrationBuilder.DropTable(
                name: "NamHoc_HocKy");

            migrationBuilder.DropTable(
                name: "PhanMonLopHoc");

            migrationBuilder.DropTable(
                name: "QuyChuanDauRa");

            migrationBuilder.DropTable(
                name: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropTable(
                name: "ThoiGianDaoTao");

            migrationBuilder.DropTable(
                name: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropTable(
                name: "TieuChuanXetDanhHieu");

            migrationBuilder.DropTable(
                name: "TieuChuanXetHocBong");

            migrationBuilder.DropTable(
                name: "TrangThaiLopHP");

            migrationBuilder.DropTable(
                name: "XetLLHB_QuyCheTC");

            migrationBuilder.DropTable(
                name: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropTable(
                name: "PhongHoc");

            migrationBuilder.DropTable(
                name: "HocVi");

            migrationBuilder.DropTable(
                name: "LoaiGiangVien");

            migrationBuilder.DropTable(
                name: "LoaiHanhViViPham");

            migrationBuilder.DropTable(
                name: "LoaiKhenThuong");

            migrationBuilder.DropTable(
                name: "LopNienChe");

            migrationBuilder.DropTable(
                name: "ChungChi");

            migrationBuilder.DropTable(
                name: "MonHocBacDaoTao");

            migrationBuilder.DropTable(
                name: "QuyUocCotDiem_NC");

            migrationBuilder.DropTable(
                name: "QuyUocCotDiem_TC");

            migrationBuilder.DropTable(
                name: "TrangThaiXetQuyUoc");

            migrationBuilder.DropTable(
                name: "Bang_BangDiem_TN");

            migrationBuilder.DropTable(
                name: "DayNha");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "NhomLoaiHanhViViPham");

            migrationBuilder.DropTable(
                name: "NhomLoaiKhenThuong");

            migrationBuilder.DropTable(
                name: "ChuyenNganh");

            migrationBuilder.DropTable(
                name: "KhoaHoc");

            migrationBuilder.DropTable(
                name: "LoaiDaoTao");

            migrationBuilder.DropTable(
                name: "LoaiChungChi");

            migrationBuilder.DropTable(
                name: "BacDaoTao");

            migrationBuilder.DropTable(
                name: "HinhThucThi");

            migrationBuilder.DropTable(
                name: "LoaiHinhGiangDay");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "QuyChe_NienChe");

            migrationBuilder.DropTable(
                name: "KieuLamTron");

            migrationBuilder.DropTable(
                name: "KieuMonHoc");

            migrationBuilder.DropTable(
                name: "QuyChe_TinChi");

            migrationBuilder.DropTable(
                name: "DiaDiemPhong");

            migrationBuilder.DropTable(
                name: "NganhHoc");

            migrationBuilder.DropTable(
                name: "NoiDung");

            migrationBuilder.DropTable(
                name: "HinhThucDaoTao");

            migrationBuilder.DropTable(
                name: "KhoiKienThuc");

            migrationBuilder.DropTable(
                name: "LoaiMonHoc");

            migrationBuilder.DropTable(
                name: "LoaiTiet");

            migrationBuilder.DropTable(
                name: "TinhChatMonHoc");

            migrationBuilder.DropTable(
                name: "ToBoMon");

            migrationBuilder.DropTable(
                name: "MucDoViPham");

            migrationBuilder.DropTable(
                name: "QuyCheHocVu");

            migrationBuilder.DropTable(
                name: "CoSoDaoTao");

            migrationBuilder.DropTable(
                name: "KhoiNganh");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "NguoiDung");
        }
    }
}
