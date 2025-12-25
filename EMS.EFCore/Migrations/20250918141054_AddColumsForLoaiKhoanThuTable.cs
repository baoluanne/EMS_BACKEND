using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColumsForLoaiKhoanThuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaLoaiKhoanThu",
                table: "LoaiKhoanThu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiKhoanThu",
                table: "LoaiKhoanThu",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaLoaiKhoanThu",
                table: "LoaiKhoanThu");

            migrationBuilder.DropColumn(
                name: "TenLoaiKhoanThu",
                table: "LoaiKhoanThu");
        }
    }
}
