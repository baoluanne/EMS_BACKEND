using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update7_CuTru_DonKtx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgayHetHan",
                table: "KtxCutru",
                newName: "NgayRoiKtx");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHocKy",
                table: "KtxCutru",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_IdHocKy",
                table: "KtxCutru",
                column: "IdHocKy");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxCutru_HocKy_IdHocKy",
                table: "KtxCutru",
                column: "IdHocKy",
                principalTable: "HocKy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxCutru_HocKy_IdHocKy",
                table: "KtxCutru");

            migrationBuilder.DropIndex(
                name: "IX_KtxCutru_IdHocKy",
                table: "KtxCutru");

            migrationBuilder.DropColumn(
                name: "IdHocKy",
                table: "KtxCutru");

            migrationBuilder.RenameColumn(
                name: "NgayRoiKtx",
                table: "KtxCutru",
                newName: "NgayHetHan");
        }
    }
}
