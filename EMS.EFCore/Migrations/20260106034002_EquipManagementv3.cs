using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EquipManagementv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVuNguoiLienHe",
                table: "TSTBNhaCungCap");

            migrationBuilder.DropColumn(
                name: "NguoiLienHe",
                table: "TSTBNhaCungCap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChucVuNguoiLienHe",
                table: "TSTBNhaCungCap",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NguoiLienHe",
                table: "TSTBNhaCungCap",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
