using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Equip_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDaTra",
                table: "TSTBChiTietPhieuMuons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTraThucTe",
                table: "TSTBChiTietPhieuMuons",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDaTra",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropColumn(
                name: "NgayTraThucTe",
                table: "TSTBChiTietPhieuMuons");
        }
    }
}
