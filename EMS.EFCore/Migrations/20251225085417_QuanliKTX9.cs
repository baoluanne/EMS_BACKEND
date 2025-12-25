using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class QuanliKTX9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDonKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    TienDien = table.Column<decimal>(type: "numeric", nullable: false),
                    TienNuoc = table.Column<decimal>(type: "numeric", nullable: false),
                    TienPhong = table.Column<decimal>(type: "numeric", nullable: false),
                    PhuPhi = table.Column<decimal>(type: "numeric", nullable: false),
                    TongTien = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "text", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiSoDienNuocId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "TaiSanKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTaiSan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenTaiSan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TinhTrang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Tot"),
                    GiaTri = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "YeuCauSuaChua",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NoiDung = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "MoiGui"),
                    KetQuaXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ChiPhiPhatSinh = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    NgayGui = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayHoanThanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaiSanKtxId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCauSuaChua", x => x.Id);
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
                        name: "FK_YeuCauSuaChua_TaiSanKtx_TaiSanKtxId",
                        column: x => x.TaiSanKtxId,
                        principalTable: "TaiSanKtx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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
                name: "IX_HoaDonKtx_PhongKtxId_Thang_Nam",
                table: "HoaDonKtx",
                columns: new[] { "PhongKtxId", "Thang", "Nam" },
                unique: true);

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
                name: "IX_YeuCauSuaChua_TaiSanKtxId",
                table: "YeuCauSuaChua",
                column: "TaiSanKtxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonKtx");

            migrationBuilder.DropTable(
                name: "YeuCauSuaChua");

            migrationBuilder.DropTable(
                name: "TaiSanKtx");
        }
    }
}
