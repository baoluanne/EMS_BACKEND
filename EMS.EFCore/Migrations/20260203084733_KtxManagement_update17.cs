using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KtxGiuong_PhongKtxId",
                table: "KtxGiuong");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_PhongKtxId_MaGiuong",
                table: "KtxGiuong",
                columns: new[] { "PhongKtxId", "MaGiuong" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KtxGiuong_PhongKtxId_MaGiuong",
                table: "KtxGiuong");

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_PhongKtxId",
                table: "KtxGiuong",
                column: "PhongKtxId");
        }
    }
}
