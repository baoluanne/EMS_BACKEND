using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class TSTBThietBi_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PhongKtxId",
                table: "TSTBThietBis",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBis_PhongKtxId",
                table: "TSTBThietBis",
                column: "PhongKtxId");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_KtxPhong_PhongKtxId",
                table: "TSTBThietBis",
                column: "PhongKtxId",
                principalTable: "KtxPhong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_KtxPhong_PhongKtxId",
                table: "TSTBThietBis");

            migrationBuilder.DropIndex(
                name: "IX_TSTBThietBis_PhongKtxId",
                table: "TSTBThietBis");

            migrationBuilder.DropColumn(
                name: "PhongKtxId",
                table: "TSTBThietBis");
        }
    }
}
