using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class KtxManagement_update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxTang_KtxToaNha_ToaNhaId",
                table: "KtxTang");

            migrationBuilder.AlterColumn<int>(
                name: "SoTang",
                table: "KtxToaNha",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongPhong",
                table: "KtxTang",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiTang",
                table: "KtxTang",
                type: "text",
                nullable: true,
                defaultValue: "0",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongGiuong",
                table: "KtxPhong",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiPhong",
                table: "KtxPhong",
                type: "text",
                nullable: true,
                defaultValue: "0",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "KtxPhong",
                type: "integer",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "KtxGiuong",
                type: "integer",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_KtxTang_KtxToaNha_ToaNhaId",
                table: "KtxTang",
                column: "ToaNhaId",
                principalTable: "KtxToaNha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KtxTang_KtxToaNha_ToaNhaId",
                table: "KtxTang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KtxPhong");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KtxGiuong");

            migrationBuilder.AlterColumn<int>(
                name: "SoTang",
                table: "KtxToaNha",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongPhong",
                table: "KtxTang",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiTang",
                table: "KtxTang",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "0");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongGiuong",
                table: "KtxPhong",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiPhong",
                table: "KtxPhong",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "0");

            migrationBuilder.AddForeignKey(
                name: "FK_KtxTang_KtxToaNha_ToaNhaId",
                table: "KtxTang",
                column: "ToaNhaId",
                principalTable: "KtxToaNha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
