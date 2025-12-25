using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Remove_QuyetDinhId_NhatKyCapNhatTrangThaiSv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_QuyetDinh_QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropColumn(
                name: "QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdQuyetDinh",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdQuyetDinh");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_QuyetDinh_IdQuyetDinh",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdQuyetDinh",
                principalTable: "QuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_QuyetDinh_IdQuyetDinh",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdQuyetDinh",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.AddColumn<Guid>(
                name: "QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "QuyetDinhId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_QuyetDinh_QuyetDinhId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "QuyetDinhId",
                principalTable: "QuyetDinh",
                principalColumn: "Id");
        }
    }
}
