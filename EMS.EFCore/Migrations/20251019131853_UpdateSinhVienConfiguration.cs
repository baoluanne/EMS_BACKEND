using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVienConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_KhoaHoc_KhoaHocId",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_KhoaHocId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "CoSoDaoTaoId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "KhoaHocId",
                table: "SinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdCoSo",
                table: "SinhVien",
                column: "IdCoSo");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdKhoaHoc",
                table: "SinhVien",
                column: "IdKhoaHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_IdCoSo",
                table: "SinhVien",
                column: "IdCoSo",
                principalTable: "CoSoDaoTao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_KhoaHoc_IdKhoaHoc",
                table: "SinhVien",
                column: "IdKhoaHoc",
                principalTable: "KhoaHoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_IdCoSo",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_KhoaHoc_IdKhoaHoc",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdCoSo",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdKhoaHoc",
                table: "SinhVien");

            migrationBuilder.AddColumn<Guid>(
                name: "CoSoDaoTaoId",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KhoaHocId",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_CoSoDaoTaoId",
                table: "SinhVien",
                column: "CoSoDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_KhoaHocId",
                table: "SinhVien",
                column: "KhoaHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_CoSoDaoTao_CoSoDaoTaoId",
                table: "SinhVien",
                column: "CoSoDaoTaoId",
                principalTable: "CoSoDaoTao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_KhoaHoc_KhoaHocId",
                table: "SinhVien",
                column: "KhoaHocId",
                principalTable: "KhoaHoc",
                principalColumn: "Id");
        }
    }
}
