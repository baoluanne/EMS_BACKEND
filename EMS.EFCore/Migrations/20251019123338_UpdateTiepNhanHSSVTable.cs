using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTiepNhanHSSVTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoSo",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "KhoaHoc",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "CongNoHocPhi",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "DaNhan",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "InBienNhan",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "KhoanThuKhac",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "MaVach",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "SoBanIn",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "XemIn",
                table: "HoSoSV");

            migrationBuilder.AddColumn<decimal>(
                name: "CongNoHocPhi",
                table: "TiepNhanHoSoSv",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InBienNhan",
                table: "TiepNhanHoSoSv",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KhoanThuKhac",
                table: "TiepNhanHoSoSv",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LyDoTuChoi",
                table: "TiepNhanHoSoSv",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaVach",
                table: "TiepNhanHoSoSv",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTiepNhan",
                table: "TiepNhanHoSoSv",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXuLy",
                table: "TiepNhanHoSoSv",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoBanIn",
                table: "TiepNhanHoSoSv",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "TiepNhanHoSoSv",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "XemIn",
                table: "TiepNhanHoSoSv",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoSoDaoTaoId",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCoSo",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhoaHoc",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KhoaHocId",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BatBuoc",
                table: "HoSoSV",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiHoSo",
                table: "HoSoSV",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_CoSoDaoTaoId",
                table: "SinhVien",
                column: "CoSoDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_KhoaHocId",
                table: "SinhVien",
                column: "KhoaHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_CoSoDaoTaoId",
                table: "SinhVien",
                column: "CoSoDaoTaoId",
                principalTable: "CoSoDaoTao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_KhoaHoc_KhoaHocId",
                table: "SinhVien",
                column: "KhoaHocId",
                principalTable: "KhoaHoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_KhoaHoc_KhoaHocId",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_KhoaHocId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "CongNoHocPhi",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "InBienNhan",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "KhoanThuKhac",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "LyDoTuChoi",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "MaVach",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "NgayTiepNhan",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "NgayXuLy",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "SoBanIn",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "XemIn",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdCoSo",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdKhoaHoc",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "KhoaHocId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "BatBuoc",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "LoaiHoSo",
                table: "HoSoSV");

            migrationBuilder.AddColumn<string>(
                name: "CoSo",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhoaHoc",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CongNoHocPhi",
                table: "HoSoSV",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaNhan",
                table: "HoSoSV",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InBienNhan",
                table: "HoSoSV",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KhoanThuKhac",
                table: "HoSoSV",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaVach",
                table: "HoSoSV",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoBanIn",
                table: "HoSoSV",
                type: "integer",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "XemIn",
                table: "HoSoSV",
                type: "boolean",
                nullable: true,
                defaultValue: false);
        }
    }
}
