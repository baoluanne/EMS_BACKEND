using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoaiHinhDaoTao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NoiDung_IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.RenameColumn(
                name: "HienThiGhiChu",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "IsVisible");

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "DanhMucLoaiHinhDaoTao",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.RenameColumn(
                name: "IsVisible",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "HienThiGhiChu");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NoiDung_IdNoiDung",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNoiDung",
                principalTable: "NoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
