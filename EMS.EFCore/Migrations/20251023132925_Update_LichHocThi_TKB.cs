using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_LichHocThi_TKB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SoTinChi",
                table: "MonHoc",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Nhom",
                table: "LopHocPhan",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThoiKhoaBieu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPhongHoc = table.Column<Guid>(type: "uuid", nullable: true),
                    IdGiangVien = table.Column<Guid>(type: "uuid", nullable: true),
                    Thu = table.Column<int>(type: "integer", nullable: false),
                    TietBatDau = table.Column<int>(type: "integer", nullable: false),
                    SoTiet = table.Column<int>(type: "integer", nullable: false),
                    TuanHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_ThoiKhoaBieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_GiangVien_IdGiangVien",
                        column: x => x.IdGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_LopHocPhan_IdLopHocPhan",
                        column: x => x.IdLopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_PhongHoc_IdPhongHoc",
                        column: x => x.IdPhongHoc,
                        principalTable: "PhongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdGiangVien",
                table: "ThoiKhoaBieu",
                column: "IdGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdLopHocPhan",
                table: "ThoiKhoaBieu",
                column: "IdLopHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdPhongHoc",
                table: "ThoiKhoaBieu",
                column: "IdPhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_NguoiCapNhapId",
                table: "ThoiKhoaBieu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_NguoiTaoId",
                table: "ThoiKhoaBieu",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThoiKhoaBieu");

            migrationBuilder.DropColumn(
                name: "SoTinChi",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "Nhom",
                table: "LopHocPhan");
        }
    }
}
