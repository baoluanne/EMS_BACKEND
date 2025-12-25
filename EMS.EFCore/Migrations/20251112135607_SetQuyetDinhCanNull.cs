using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SetQuyetDinhCanNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_QuyetDinh_IdQuyetDinh",
                table: "SinhVienMienMonHoc");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdQuyetDinh",
                table: "SinhVienMienMonHoc",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_QuyetDinh_IdQuyetDinh",
                table: "SinhVienMienMonHoc",
                column: "IdQuyetDinh",
                principalTable: "QuyetDinh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_QuyetDinh_IdQuyetDinh",
                table: "SinhVienMienMonHoc");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdQuyetDinh",
                table: "SinhVienMienMonHoc",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_QuyetDinh_IdQuyetDinh",
                table: "SinhVienMienMonHoc",
                column: "IdQuyetDinh",
                principalTable: "QuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
