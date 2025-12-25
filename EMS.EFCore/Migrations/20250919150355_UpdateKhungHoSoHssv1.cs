using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKhungHoSoHssv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_KhoaHoc_IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_MaHoSo_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "MaHoSo",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "TenHoSo",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.RenameColumn(
                name: "BatBuoc",
                table: "DanhMucKhungHoSoHSSV",
                newName: "IsBatBuoc");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "TieuChiTuyenSinh",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTieuChi",
                table: "TieuChiTuyenSinh",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenTieuChi",
                table: "TieuChiTuyenSinh",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHoSoHSSV",
                table: "DanhMucKhungHoSoHSSV",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                columns: new[] { "IdHoSoHSSV", "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_DanhMucHoSoHSSV_IdHoSoHSSV",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdHoSoHSSV",
                principalTable: "DanhMucHoSoHSSV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_KhoaHoc_IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdKhoaHoc",
                principalTable: "KhoaHoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_DanhMucHoSoHSSV_IdHoSoHSSV",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_KhoaHoc_IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropColumn(
                name: "MaTieuChi",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropColumn(
                name: "TenTieuChi",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropColumn(
                name: "IdHoSoHSSV",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.RenameColumn(
                name: "IsBatBuoc",
                table: "DanhMucKhungHoSoHSSV",
                newName: "BatBuoc");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHoSo",
                table: "DanhMucKhungHoSoHSSV",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenHoSo",
                table: "DanhMucKhungHoSoHSSV",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_MaHoSo_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                columns: new[] { "MaHoSo", "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_KhoaHoc_IdKhoaHoc",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdKhoaHoc",
                principalTable: "KhoaHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
