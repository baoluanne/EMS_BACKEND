using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update9_NoiQuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanViPham",
                table: "KtxViPhamNoiQuy",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "MaBienBan",
                table: "KtxViPhamNoiQuy",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanViPham",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropColumn(
                name: "MaBienBan",
                table: "KtxViPhamNoiQuy");
        }
    }
}
