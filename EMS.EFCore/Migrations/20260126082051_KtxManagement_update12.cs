using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaBienBan",
                table: "KtxViPhamNoiQuy",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "LoaiViPham",
                table: "KtxViPhamNoiQuy",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Loại hành vi vi phạm dựa trên Enum");

            migrationBuilder.CreateIndex(
                name: "IX_KtxViPhamNoiQuy_MaBienBan",
                table: "KtxViPhamNoiQuy",
                column: "MaBienBan",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KtxViPhamNoiQuy_MaBienBan",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.DropColumn(
                name: "LoaiViPham",
                table: "KtxViPhamNoiQuy");

            migrationBuilder.AlterColumn<string>(
                name: "MaBienBan",
                table: "KtxViPhamNoiQuy",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
