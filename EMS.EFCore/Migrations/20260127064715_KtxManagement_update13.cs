using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CuTruId",
                table: "KtxViPhamNoiQuy",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TongDiemViPham",
                table: "KtxCutru",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_CuTruId",
                table: "KtxViPhamNoiQuy",
                column: "CuTruId");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxViPhamNoiQuy_KtxCutru_CuTruId",
                table: "KtxViPhamNoiQuy",
                column: "CuTruId",
                principalTable: "KtxCutru",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxViPhamNoiQuy_KtxCutru_CuTruId",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropIndex(
                name: "IX_KtxViPhamNoiQuy_CuTruId",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropColumn(
                name: "CuTruId",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropColumn(
                name: "TongDiemViPham",
                table: "KtxCutru");
        }
    }
}
