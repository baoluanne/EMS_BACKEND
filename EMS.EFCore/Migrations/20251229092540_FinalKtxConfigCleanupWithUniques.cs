using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class FinalKtxConfigCleanupWithUniques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_HoaDonKtx_PhongKtxId_Thang_Nam",
                table: "HoaDonKtx",
                newName: "IX_HoaDonKtx_Phong_Thang_Nam_Unique");

            migrationBuilder.RenameIndex(
                name: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam",
                table: "ChiSoDienNuoc",
                newName: "IX_ChiSoDienNuoc_Phong_Thang_Nam_Unique");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "HoaDonKtx",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "SinhVienId1",
                table: "CuTruKtx",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToaNhaKtx_TenToaNha_Unique",
                table: "ToaNhaKtx",
                column: "TenToaNha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhongKtx_MaPhong_Unique",
                table: "PhongKtx",
                column: "MaPhong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiuongKtx_MaGiuong_Unique",
                table: "GiuongKtx",
                column: "MaGiuong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonKtx_MaDon_Unique",
                table: "DonKtx",
                column: "MaDon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuTruKtx_SinhVienId1",
                table: "CuTruKtx",
                column: "SinhVienId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CuTruKtx_SinhVien_SinhVienId1",
                table: "CuTruKtx",
                column: "SinhVienId1",
                principalTable: "SinhVien",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuTruKtx_SinhVien_SinhVienId1",
                table: "CuTruKtx");

            migrationBuilder.DropIndex(
                name: "IX_ToaNhaKtx_TenToaNha_Unique",
                table: "ToaNhaKtx");

            migrationBuilder.DropIndex(
                name: "IX_PhongKtx_MaPhong_Unique",
                table: "PhongKtx");

            migrationBuilder.DropIndex(
                name: "IX_GiuongKtx_MaGiuong_Unique",
                table: "GiuongKtx");

            migrationBuilder.DropIndex(
                name: "IX_DonKtx_MaDon_Unique",
                table: "DonKtx");

            migrationBuilder.DropIndex(
                name: "IX_CuTruKtx_SinhVienId1",
                table: "CuTruKtx");

            migrationBuilder.DropColumn(
                name: "SinhVienId1",
                table: "CuTruKtx");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonKtx_Phong_Thang_Nam_Unique",
                table: "HoaDonKtx",
                newName: "IX_HoaDonKtx_PhongKtxId_Thang_Nam");

            migrationBuilder.RenameIndex(
                name: "IX_ChiSoDienNuoc_Phong_Thang_Nam_Unique",
                table: "ChiSoDienNuoc",
                newName: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "HoaDonKtx",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
