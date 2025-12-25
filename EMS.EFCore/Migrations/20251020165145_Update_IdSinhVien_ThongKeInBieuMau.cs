using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_IdSinhVien_ThongKeInBieuMau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_SinhVien_SinhVienId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_ThongKeInBieuMau_SinhVienId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropColumn(
                name: "SinhVienId",
                table: "ThongKeInBieuMau");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_IdSinhVien",
                table: "ThongKeInBieuMau",
                column: "IdSinhVien");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_SinhVien_IdSinhVien",
                table: "ThongKeInBieuMau",
                column: "IdSinhVien",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_SinhVien_IdSinhVien",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_ThongKeInBieuMau_IdSinhVien",
                table: "ThongKeInBieuMau");

            migrationBuilder.AddColumn<Guid>(
                name: "SinhVienId",
                table: "ThongKeInBieuMau",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_SinhVienId",
                table: "ThongKeInBieuMau",
                column: "SinhVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_SinhVien_SinhVienId",
                table: "ThongKeInBieuMau",
                column: "SinhVienId",
                principalTable: "SinhVien",
                principalColumn: "Id");
        }
    }
}
