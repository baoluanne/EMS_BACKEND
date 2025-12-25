using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddLoaiSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiSinhVien",
                table: "SinhVien");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiSinhVien",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdLoaiSinhVien",
                table: "SinhVien",
                column: "IdLoaiSinhVien");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_LoaiSinhVien_IdLoaiSinhVien",
                table: "SinhVien",
                column: "IdLoaiSinhVien",
                principalTable: "LoaiSinhVien",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_LoaiSinhVien_IdLoaiSinhVien",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdLoaiSinhVien",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdLoaiSinhVien",
                table: "SinhVien");

            migrationBuilder.AddColumn<string>(
                name: "LoaiSinhVien",
                table: "SinhVien",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
