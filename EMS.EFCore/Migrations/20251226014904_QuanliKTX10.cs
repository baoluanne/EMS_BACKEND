using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class QuanliKTX10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KetQuaXuLy",
                table: "YeuCauSuaChua",
                newName: "GhiChuXuLy");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "YeuCauSuaChua",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGui",
                table: "YeuCauSuaChua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() AT TIME ZONE 'UTC'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "HoaDonKtxId",
                table: "YeuCauSuaChua",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXuLy",
                table: "YeuCauSuaChua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SinhVienId1",
                table: "YeuCauSuaChua",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_HoaDonKtxId",
                table: "YeuCauSuaChua",
                column: "HoaDonKtxId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSuaChua_SinhVienId1",
                table: "YeuCauSuaChua",
                column: "SinhVienId1");

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauSuaChua_HoaDonKtx_HoaDonKtxId",
                table: "YeuCauSuaChua",
                column: "HoaDonKtxId",
                principalTable: "HoaDonKtx",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauSuaChua_SinhVien_SinhVienId1",
                table: "YeuCauSuaChua",
                column: "SinhVienId1",
                principalTable: "SinhVien",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauSuaChua_HoaDonKtx_HoaDonKtxId",
                table: "YeuCauSuaChua");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauSuaChua_SinhVien_SinhVienId1",
                table: "YeuCauSuaChua");

            migrationBuilder.DropIndex(
                name: "IX_YeuCauSuaChua_HoaDonKtxId",
                table: "YeuCauSuaChua");

            migrationBuilder.DropIndex(
                name: "IX_YeuCauSuaChua_SinhVienId1",
                table: "YeuCauSuaChua");

            migrationBuilder.DropColumn(
                name: "HoaDonKtxId",
                table: "YeuCauSuaChua");

            migrationBuilder.DropColumn(
                name: "NgayXuLy",
                table: "YeuCauSuaChua");

            migrationBuilder.DropColumn(
                name: "SinhVienId1",
                table: "YeuCauSuaChua");

            migrationBuilder.RenameColumn(
                name: "GhiChuXuLy",
                table: "YeuCauSuaChua",
                newName: "KetQuaXuLy");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "YeuCauSuaChua",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGui",
                table: "YeuCauSuaChua",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() AT TIME ZONE 'UTC'");
        }
    }
}
