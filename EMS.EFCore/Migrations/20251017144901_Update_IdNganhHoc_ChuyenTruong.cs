using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_IdNganhHoc_ChuyenTruong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NganhHoc_IdNganhHoc",
                table: "ChuyenTruong");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNganhHoc",
                table: "ChuyenTruong",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NganhHoc_IdNganhHoc",
                table: "ChuyenTruong",
                column: "IdNganhHoc",
                principalTable: "NganhHoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NganhHoc_IdNganhHoc",
                table: "ChuyenTruong");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNganhHoc",
                table: "ChuyenTruong",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NganhHoc_IdNganhHoc",
                table: "ChuyenTruong",
                column: "IdNganhHoc",
                principalTable: "NganhHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
