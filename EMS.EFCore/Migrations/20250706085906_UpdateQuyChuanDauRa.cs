using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuyChuanDauRa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "QuyChuanDauRa");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdChuyenNganh",
                table: "QuyChuanDauRa",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiChungChi",
                table: "QuyChuanDauRa",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdLoaiChungChi",
                table: "QuyChuanDauRa",
                column: "IdLoaiChungChi");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "QuyChuanDauRa",
                column: "IdChuyenNganh",
                principalTable: "ChuyenNganh",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_LoaiChungChi_IdLoaiChungChi",
                table: "QuyChuanDauRa",
                column: "IdLoaiChungChi",
                principalTable: "LoaiChungChi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "QuyChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_LoaiChungChi_IdLoaiChungChi",
                table: "QuyChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_QuyChuanDauRa_IdLoaiChungChi",
                table: "QuyChuanDauRa");

            migrationBuilder.DropColumn(
                name: "IdLoaiChungChi",
                table: "QuyChuanDauRa");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdChuyenNganh",
                table: "QuyChuanDauRa",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "QuyChuanDauRa",
                column: "IdChuyenNganh",
                principalTable: "ChuyenNganh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
