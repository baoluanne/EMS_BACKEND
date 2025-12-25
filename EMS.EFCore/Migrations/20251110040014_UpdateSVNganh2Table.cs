using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSVNganh2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienNganh2_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2");

            migrationBuilder.DropColumn(
                name: "IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                column: "IdNguoiRaQuyetDinh");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiRaQuyetDinh",
                table: "SinhVienNganh2",
                column: "IdNguoiRaQuyetDinh",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }
    }
}
