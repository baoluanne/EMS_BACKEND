using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddGiangVienLHP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdGiangVien",
                table: "LopHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdGiangVien",
                table: "LopHocPhan",
                column: "IdGiangVien");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_GiangVien_IdGiangVien",
                table: "LopHocPhan",
                column: "IdGiangVien",
                principalTable: "GiangVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_GiangVien_IdGiangVien",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdGiangVien",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdGiangVien",
                table: "LopHocPhan");
        }
    }
}
