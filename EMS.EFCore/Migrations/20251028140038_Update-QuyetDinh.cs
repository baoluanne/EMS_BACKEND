using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuyetDinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NguoiKy",
                table: "QuyetDinh",
                newName: "NguoiRaQD");

            migrationBuilder.RenameColumn(
                name: "NgayQuyetDinh",
                table: "QuyetDinh",
                newName: "NgayRaQuyetDinh");

            migrationBuilder.AddColumn<string>(
                name: "LoaiQuyetDinh",
                table: "QuyetDinh",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayKyQuyetDinh",
                table: "QuyetDinh",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKyQD",
                table: "QuyetDinh",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.DropColumn(
                name: "NgayKyQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.DropColumn(
                name: "NguoiKyQD",
                table: "QuyetDinh");

            migrationBuilder.RenameColumn(
                name: "NguoiRaQD",
                table: "QuyetDinh",
                newName: "NguoiKy");

            migrationBuilder.RenameColumn(
                name: "NgayRaQuyetDinh",
                table: "QuyetDinh",
                newName: "NgayQuyetDinh");
        }
    }
}
