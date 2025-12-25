using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHSSVTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiXuLyId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanHoSoSv_NguoiXuLyId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "NguoiXuLyId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "BatBuoc",
                table: "HoSoSV");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiXuLy",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiTiepNhan",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiXuLy",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiXuLy");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiXuLy",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiXuLy",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiXuLy",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiXuLy",
                table: "TiepNhanHoSoSv");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiXuLy",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiTiepNhan",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiXuLyId",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BatBuoc",
                table: "HoSoSV",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_NguoiXuLyId",
                table: "TiepNhanHoSoSv",
                column: "NguoiXuLyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiXuLyId",
                table: "TiepNhanHoSoSv",
                column: "NguoiXuLyId",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }
    }
}
