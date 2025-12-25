using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoaiChucVu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "LoaiChucVu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiChucVu",
                table: "LoaiChucVu",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "LoaiChucVu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiChucVu",
                table: "LoaiChucVu",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu",
                columns: new[] { "MaLoaiChucVu", "TenLoaiChucVu" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "MaLoaiChucVu",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "STT",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "TenLoaiChucVu",
                table: "LoaiChucVu");
        }
    }
}
