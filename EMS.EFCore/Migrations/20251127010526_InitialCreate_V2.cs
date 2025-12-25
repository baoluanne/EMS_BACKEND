using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongNoSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamHocHocKyId = table.Column<Guid>(type: "uuid", nullable: false),
                    HanNop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DaThu = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    TongMienGiam = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongNoSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongNoSinhVien_NamHoc_HocKy_NamHocHocKyId",
                        column: x => x.NamHocHocKyId,
                        principalTable: "NamHoc_HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongNoSinhVien_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CongNoSinhVien_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CongNoSinhVien_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuChiSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoPhieu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    LyDoChi = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NgayChi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HinhThucChi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SoTaiKhoanNhan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NganHangNhan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SinhVienId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChiSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuChiSinhVien_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuChiSinhVien_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuChiSinhVien_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChiSinhVien_SinhVien_SinhVienId1",
                        column: x => x.SinhVienId1,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CongNoChiTiet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CongNoId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiKhoanThuId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongNoChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongNoChiTiet_CongNoSinhVien_CongNoId",
                        column: x => x.CongNoId,
                        principalTable: "CongNoSinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongNoChiTiet_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CongNoChiTiet_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MienGiamSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamHocHocKyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CongNoId = table.Column<Guid>(type: "uuid", nullable: true),
                    LoaiMienGiam = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    LyDo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "ChoDuyet"),
                    NgayDuyet = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MienGiamSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MienGiamSinhVien_CongNoSinhVien_CongNoId",
                        column: x => x.CongNoId,
                        principalTable: "CongNoSinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MienGiamSinhVien_NamHoc_HocKy_NamHocHocKyId",
                        column: x => x.NamHocHocKyId,
                        principalTable: "NamHoc_HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MienGiamSinhVien_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MienGiamSinhVien_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MienGiamSinhVien_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThuSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoPhieu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    CongNoId = table.Column<Guid>(type: "uuid", nullable: true),
                    SoTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NgayThu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NguoiThu = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    DaHuy = table.Column<bool>(type: "boolean", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThuSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuThuSinhVien_CongNoSinhVien_CongNoId",
                        column: x => x.CongNoId,
                        principalTable: "CongNoSinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PhieuThuSinhVien_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuThuSinhVien_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuThuSinhVien_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonDienTuSinhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhieuThuId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHoaDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LinkPDF = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LinkXML = table.Column<string>(type: "text", nullable: true),
                    NhaCungCap = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "ChoPhatHanh"),
                    NgayPhatHanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonDienTuSinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonDienTuSinhVien_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonDienTuSinhVien_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonDienTuSinhVien_PhieuThuSinhVien_PhieuThuId",
                        column: x => x.PhieuThuId,
                        principalTable: "PhieuThuSinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongNoChiTiet_CongNoId",
                table: "CongNoChiTiet",
                column: "CongNoId");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoChiTiet_IdNguoiCapNhat",
                table: "CongNoChiTiet",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoChiTiet_IdNguoiTao",
                table: "CongNoChiTiet",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoSinhVien_IdNguoiCapNhat",
                table: "CongNoSinhVien",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoSinhVien_IdNguoiTao",
                table: "CongNoSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoSinhVien_NamHocHocKyId",
                table: "CongNoSinhVien",
                column: "NamHocHocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_CongNoSinhVien_SinhVienId_NamHocHocKyId",
                table: "CongNoSinhVien",
                columns: new[] { "SinhVienId", "NamHocHocKyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDienTuSinhVien_IdNguoiCapNhat",
                table: "HoaDonDienTuSinhVien",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDienTuSinhVien_IdNguoiTao",
                table: "HoaDonDienTuSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDienTuSinhVien_MaHoaDon",
                table: "HoaDonDienTuSinhVien",
                column: "MaHoaDon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDienTuSinhVien_PhieuThuId",
                table: "HoaDonDienTuSinhVien",
                column: "PhieuThuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_CongNoId",
                table: "MienGiamSinhVien",
                column: "CongNoId");

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_IdNguoiCapNhat",
                table: "MienGiamSinhVien",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_IdNguoiTao",
                table: "MienGiamSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_NamHocHocKyId",
                table: "MienGiamSinhVien",
                column: "NamHocHocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_SinhVienId",
                table: "MienGiamSinhVien",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiSinhVien_IdNguoiCapNhat",
                table: "PhieuChiSinhVien",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiSinhVien_IdNguoiTao",
                table: "PhieuChiSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiSinhVien_SinhVienId",
                table: "PhieuChiSinhVien",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiSinhVien_SinhVienId1",
                table: "PhieuChiSinhVien",
                column: "SinhVienId1");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiSinhVien_SoPhieu",
                table: "PhieuChiSinhVien",
                column: "SoPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuSinhVien_CongNoId",
                table: "PhieuThuSinhVien",
                column: "CongNoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuSinhVien_IdNguoiCapNhat",
                table: "PhieuThuSinhVien",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuSinhVien_IdNguoiTao",
                table: "PhieuThuSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuSinhVien_SinhVienId",
                table: "PhieuThuSinhVien",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuSinhVien_SoPhieu",
                table: "PhieuThuSinhVien",
                column: "SoPhieu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongNoChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDonDienTuSinhVien");

            migrationBuilder.DropTable(
                name: "MienGiamSinhVien");

            migrationBuilder.DropTable(
                name: "PhieuChiSinhVien");

            migrationBuilder.DropTable(
                name: "PhieuThuSinhVien");

            migrationBuilder.DropTable(
                name: "CongNoSinhVien");
        }
    }
}
