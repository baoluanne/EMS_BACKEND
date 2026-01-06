using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EquipManagementv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoiDongThanhLy",
                table: "TSTBPhieuThanhLy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoiDongThanhLy",
                table: "TSTBPhieuThanhLy",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
