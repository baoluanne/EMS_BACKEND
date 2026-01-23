using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GiuongYeuCauId",
                table: "KtxDonChuyenPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KtxDonChuyenPhong_GiuongYeuCauId",
                table: "KtxDonChuyenPhong",
                column: "GiuongYeuCauId");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxDonChuyenPhong_KtxGiuong_GiuongYeuCauId",
                table: "KtxDonChuyenPhong",
                column: "GiuongYeuCauId",
                principalTable: "KtxGiuong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxDonChuyenPhong_KtxGiuong_GiuongYeuCauId",
                table: "KtxDonChuyenPhong");

            migrationBuilder.DropIndex(
                name: "IX_KtxDonChuyenPhong_GiuongYeuCauId",
                table: "KtxDonChuyenPhong");

            migrationBuilder.DropColumn(
                name: "GiuongYeuCauId",
                table: "KtxDonChuyenPhong");
        }
    }
}
