using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class FinalKtxConfigCleanupWithUniques1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ToaNhaKtx_TenToaNha_Unique",
                table: "ToaNhaKtx",
                newName: "IX_ToaNhaKtx_TenToaNha");

            migrationBuilder.RenameIndex(
                name: "IX_PhongKtx_MaPhong_Unique",
                table: "PhongKtx",
                newName: "IX_PhongKtx_MaPhong");

            migrationBuilder.RenameIndex(
                name: "IX_GiuongKtx_MaGiuong_Unique",
                table: "GiuongKtx",
                newName: "IX_GiuongKtx_MaGiuong");

            migrationBuilder.RenameIndex(
                name: "IX_DonKtx_MaDon_Unique",
                table: "DonKtx",
                newName: "IX_DonKtx_MaDon");

            migrationBuilder.RenameIndex(
                name: "IX_ChiSoDienNuoc_Phong_Thang_Nam_Unique",
                table: "ChiSoDienNuoc",
                newName: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ToaNhaKtx_TenToaNha",
                table: "ToaNhaKtx",
                newName: "IX_ToaNhaKtx_TenToaNha_Unique");

            migrationBuilder.RenameIndex(
                name: "IX_PhongKtx_MaPhong",
                table: "PhongKtx",
                newName: "IX_PhongKtx_MaPhong_Unique");

            migrationBuilder.RenameIndex(
                name: "IX_GiuongKtx_MaGiuong",
                table: "GiuongKtx",
                newName: "IX_GiuongKtx_MaGiuong_Unique");

            migrationBuilder.RenameIndex(
                name: "IX_DonKtx_MaDon",
                table: "DonKtx",
                newName: "IX_DonKtx_MaDon_Unique");

            migrationBuilder.RenameIndex(
                name: "IX_ChiSoDienNuoc_PhongKtxId_Thang_Nam",
                table: "ChiSoDienNuoc",
                newName: "IX_ChiSoDienNuoc_Phong_Thang_Nam_Unique");
        }
    }
}
