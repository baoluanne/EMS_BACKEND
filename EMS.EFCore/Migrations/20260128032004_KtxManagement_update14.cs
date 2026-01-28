using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdHocKy",
                table: "KtxViPhamNoiQuy",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_IdHocKy",
                table: "KtxViPhamNoiQuy",
                column: "IdHocKy");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxViPhamNoiQuy_HocKy_IdHocKy",
                table: "KtxViPhamNoiQuy",
                column: "IdHocKy",
                principalTable: "HocKy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxViPhamNoiQuy_HocKy_IdHocKy",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropIndex(
                name: "IX_KtxViPhamNoiQuy_IdHocKy",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropColumn(
                name: "IdHocKy",
                table: "KtxViPhamNoiQuy");
        }
    }
}
