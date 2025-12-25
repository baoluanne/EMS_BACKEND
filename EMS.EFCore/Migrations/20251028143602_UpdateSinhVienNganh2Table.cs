using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVienNganh2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_NamHoc_IdNamHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_LopHoc_IdLopHoc1",
                table: "SinhVienNganh2");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienNganh2_IdLopHoc1",
                table: "SinhVienNganh2");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdNamHoc",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdLopHoc1",
                table: "SinhVienNganh2");

            migrationBuilder.DropColumn(
                name: "IdNamHoc",
                table: "LopHocPhan");

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "SinhVienNganh2",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "SinhVienNganh2");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLopHoc1",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdNamHoc",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdLopHoc1",
                table: "SinhVienNganh2",
                column: "IdLopHoc1");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdNamHoc",
                table: "LopHocPhan",
                column: "IdNamHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_NamHoc_IdNamHoc",
                table: "LopHocPhan",
                column: "IdNamHoc",
                principalTable: "NamHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_LopHoc_IdLopHoc1",
                table: "SinhVienNganh2",
                column: "IdLopHoc1",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
