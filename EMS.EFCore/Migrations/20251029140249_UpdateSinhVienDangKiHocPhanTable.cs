using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVienDangKiHocPhanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nhom",
                table: "LopHocPhan");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nhom",
                table: "SinhVienDangKiHocPhan",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiDangKy");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiDangKy",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "Nhom",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.AddColumn<int>(
                name: "Nhom",
                table: "LopHocPhan",
                type: "integer",
                nullable: true);
        }
    }
}
