using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ChuyenLopTuDoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrangThaiXuLy",
                table: "ChuyenLop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChuyenDoiHocPhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenLop = table.Column<Guid>(type: "uuid", nullable: false),
                    ChuyenLopId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdMonHocCu = table.Column<Guid>(type: "uuid", nullable: false),
                    MonHocCuId = table.Column<Guid>(type: "uuid", nullable: true),
                    DiemCu = table.Column<decimal>(type: "numeric", nullable: false),
                    TinChiCu = table.Column<int>(type: "integer", nullable: false),
                    IdBangDiemCu = table.Column<Guid>(type: "uuid", nullable: true),
                    BangDiemCuId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdMonHocMoi = table.Column<Guid>(type: "uuid", nullable: false),
                    MonHocMoiId = table.Column<Guid>(type: "uuid", nullable: true),
                    TinChiMoi = table.Column<int>(type: "integer", nullable: false),
                    IdBangDiemMoi = table.Column<Guid>(type: "uuid", nullable: true),
                    PhanLoai = table.Column<int>(type: "integer", nullable: false),
                    DiemChuyenDoiDuocApDung = table.Column<decimal>(type: "numeric", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IsDaThucThi = table.Column<bool>(type: "boolean", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenDoiHocPhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_BangDiemChiTiet_BangDiemCuId",
                        column: x => x.BangDiemCuId,
                        principalTable: "BangDiemChiTiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_ChuyenLop_ChuyenLopId",
                        column: x => x.ChuyenLopId,
                        principalTable: "ChuyenLop",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_MonHoc_MonHocCuId",
                        column: x => x.MonHocCuId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_MonHoc_MonHocMoiId",
                        column: x => x.MonHocMoiId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuyenDoiHocPhan_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet",
                column: "IdChuyenDoiHocPhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdSinhVien_IdMonHoc_IsDiemCaoNhat",
                table: "BangDiemChiTiet",
                columns: new[] { "IdSinhVien", "IdMonHoc", "IsDiemCaoNhat" });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_BangDiemCuId",
                table: "ChuyenDoiHocPhan",
                column: "BangDiemCuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_ChuyenLopId",
                table: "ChuyenDoiHocPhan",
                column: "ChuyenLopId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_IdNguoiCapNhat",
                table: "ChuyenDoiHocPhan",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_IdNguoiTao",
                table: "ChuyenDoiHocPhan",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_MonHocCuId",
                table: "ChuyenDoiHocPhan",
                column: "MonHocCuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenDoiHocPhan_MonHocMoiId",
                table: "ChuyenDoiHocPhan",
                column: "MonHocMoiId");

            migrationBuilder.AddForeignKey(
                name: "FK_BangDiemChiTiet_ChuyenDoiHocPhan_IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet",
                column: "IdChuyenDoiHocPhan",
                principalTable: "ChuyenDoiHocPhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BangDiemChiTiet_ChuyenDoiHocPhan_IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet");

            migrationBuilder.DropTable(
                name: "ChuyenDoiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_BangDiemChiTiet_IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_BangDiemChiTiet_IdSinhVien_IdMonHoc_IsDiemCaoNhat",
                table: "BangDiemChiTiet");

            migrationBuilder.DropColumn(
                name: "TrangThaiXuLy",
                table: "ChuyenLop");

            migrationBuilder.DropColumn(
                name: "IdChuyenDoiHocPhan",
                table: "BangDiemChiTiet");
        }
    }
}
