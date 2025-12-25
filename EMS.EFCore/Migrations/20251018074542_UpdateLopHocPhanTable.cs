using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLopHocPhanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_Khoa_IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHinhThucThi",
                table: "LopHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LopDuKien",
                table: "LopHocPhan",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdHinhThucThi",
                table: "LopHocPhan",
                column: "IdHinhThucThi");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_HinhThucThi_IdHinhThucThi",
                table: "LopHocPhan",
                column: "IdHinhThucThi",
                principalTable: "HinhThucThi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_HinhThucThi_IdHinhThucThi",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdHinhThucThi",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdHinhThucThi",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "LopDuKien",
                table: "LopHocPhan");

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhoaChuQuan",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdKhoaChuQuan",
                table: "LopHocPhan",
                column: "IdKhoaChuQuan");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_Khoa_IdKhoaChuQuan",
                table: "LopHocPhan",
                column: "IdKhoaChuQuan",
                principalTable: "Khoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
