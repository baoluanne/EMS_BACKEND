using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVienNganh2Table2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                column: "IdNguoiRaQuyetDinh",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                column: "IdNguoiRaQuyetDinh",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
