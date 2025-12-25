using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddChuyenNganhColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdChuyenNganh",
                table: "ChuanDauRa",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdChuyenNganh",
                table: "ChuanDauRa",
                column: "IdChuyenNganh");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "ChuanDauRa",
                column: "IdChuyenNganh",
                principalTable: "ChuyenNganh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuanDauRa_ChuyenNganh_IdChuyenNganh",
                table: "ChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_ChuanDauRa_IdChuyenNganh",
                table: "ChuanDauRa");

            migrationBuilder.DropColumn(
                name: "IdChuyenNganh",
                table: "ChuanDauRa");
        }
    }
}
