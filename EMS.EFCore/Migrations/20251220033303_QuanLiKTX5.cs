using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class QuanLiKTX5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
                table: "ViPhamNoiQuyKTX");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDungViPham",
                table: "ViPhamNoiQuyKTX",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhThucXuLy",
                table: "ViPhamNoiQuyKTX",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiemTru",
                table: "ViPhamNoiQuyKTX",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
                table: "ViPhamNoiQuyKTX",
                column: "SinhVienId",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
                table: "ViPhamNoiQuyKTX");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDungViPham",
                table: "ViPhamNoiQuyKTX",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "HinhThucXuLy",
                table: "ViPhamNoiQuyKTX",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiemTru",
                table: "ViPhamNoiQuyKTX",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ViPhamNoiQuyKTX_SinhVien_SinhVienId",
                table: "ViPhamNoiQuyKTX",
                column: "SinhVienId",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
