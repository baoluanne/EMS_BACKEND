using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update6_CuTru_DonKtx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KtxGiuong_MaGiuong",
                table: "KtxGiuong");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "KtxGiuong",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Trong",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MaGiuong",
                table: "KtxGiuong",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongKtxId",
                table: "KtxCutru",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_KtxCutru_PhongKtxId",
                table: "KtxCutru",
                column: "PhongKtxId");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxCutru_KtxPhong_PhongKtxId",
                table: "KtxCutru",
                column: "PhongKtxId",
                principalTable: "KtxPhong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxCutru_KtxPhong_PhongKtxId",
                table: "KtxCutru");

            migrationBuilder.DropIndex(
                name: "IX_KtxCutru_PhongKtxId",
                table: "KtxCutru");

            migrationBuilder.DropColumn(
                name: "PhongKtxId",
                table: "KtxCutru");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "KtxGiuong",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Trong");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiuong",
                table: "KtxGiuong",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_KtxGiuong_MaGiuong",
                table: "KtxGiuong",
                column: "MaGiuong",
                unique: true);
        }
    }
}
