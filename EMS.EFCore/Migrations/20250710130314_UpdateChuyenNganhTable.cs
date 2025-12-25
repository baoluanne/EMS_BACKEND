using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChuyenNganhTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_Khoa_KhoaId",
                table: "NganhHoc");

            migrationBuilder.AlterColumn<Guid>(
                name: "KhoaId",
                table: "NganhHoc",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_Khoa_KhoaId",
                table: "NganhHoc",
                column: "KhoaId",
                principalTable: "Khoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_Khoa_KhoaId",
                table: "NganhHoc");

            migrationBuilder.AlterColumn<Guid>(
                name: "KhoaId",
                table: "NganhHoc",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_Khoa_KhoaId",
                table: "NganhHoc",
                column: "KhoaId",
                principalTable: "Khoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
