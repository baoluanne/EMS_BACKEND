using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoaiSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaLoaiSinhVien",
                table: "LoaiSinhVien",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiSinhVien",
                table: "LoaiSinhVien",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaLoaiSinhVien",
                table: "LoaiSinhVien");

            migrationBuilder.DropColumn(
                name: "TenLoaiSinhVien",
                table: "LoaiSinhVien");
        }
    }
}
