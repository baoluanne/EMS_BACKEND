using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update8_Add_HISTORY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KtxCuTruLichSu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CuTruId = table.Column<Guid>(type: "uuid", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonKtxId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiDon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhongCuId = table.Column<Guid>(type: "uuid", nullable: true),
                    GiuongCuId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongMoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiuongMoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayRoiDuKien = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayRoiThucTe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrangThai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NgayGhiLichSu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KtxCuTruLichSu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxCutru_CuTruId",
                        column: x => x.CuTruId,
                        principalTable: "KtxCutru",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxDon_DonKtxId",
                        column: x => x.DonKtxId,
                        principalTable: "KtxDon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxGiuong_GiuongCuId",
                        column: x => x.GiuongCuId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxGiuong_GiuongMoiId",
                        column: x => x.GiuongMoiId,
                        principalTable: "KtxGiuong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxPhong_PhongCuId",
                        column: x => x.PhongCuId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_KtxPhong_PhongMoiId",
                        column: x => x.PhongMoiId,
                        principalTable: "KtxPhong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KtxCuTruLichSu_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_CuTruId",
                table: "KtxCuTruLichSu",
                column: "CuTruId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_DonKtxId",
                table: "KtxCuTruLichSu",
                column: "DonKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_GiuongCuId",
                table: "KtxCuTruLichSu",
                column: "GiuongCuId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_GiuongMoiId",
                table: "KtxCuTruLichSu",
                column: "GiuongMoiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_IdHocKy",
                table: "KtxCuTruLichSu",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_IdNguoiCapNhat",
                table: "KtxCuTruLichSu",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_IdNguoiTao",
                table: "KtxCuTruLichSu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_PhongCuId",
                table: "KtxCuTruLichSu",
                column: "PhongCuId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_PhongMoiId",
                table: "KtxCuTruLichSu",
                column: "PhongMoiId");

            migrationBuilder.CreateIndex(
                name: "IX_KtxCuTruLichSu_SinhVienId",
                table: "KtxCuTruLichSu",
                column: "SinhVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KtxCuTruLichSu");
        }
    }
}
