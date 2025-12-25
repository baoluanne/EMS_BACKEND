using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class QuanLiKTX4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuTruKtx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "DangO"),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: true),
                    DonKtxId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuTruKtx");
        }
    }
}
