using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeedbackdanhmucOct8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BacDaoTao_HinhThucDaoTao_IdHinhThucDaoTao",
                table: "BacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_KhoiNganh_IdKhoiNganh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiDaoTao_NoiDung_IdNoiDung",
                table: "LoaiDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_LoaiDaoTao_IdNoiDung",
                table: "LoaiDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_BacDaoTao_IdHinhThucDaoTao",
                table: "BacDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNoiDung",
                table: "LoaiDaoTao");

            migrationBuilder.DropColumn(
                name: "IdHinhThucDaoTao",
                table: "BacDaoTao");

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "LoaiDaoTao",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhoiNganh",
                table: "DanhMucNganhDaoTao",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "HinhThucDaoTao",
                table: "BacDaoTao",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_KhoiNganh_IdKhoiNganh",
                table: "DanhMucNganhDaoTao",
                column: "IdKhoiNganh",
                principalTable: "KhoiNganh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_KhoiNganh_IdKhoiNganh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "LoaiDaoTao");

            migrationBuilder.DropColumn(
                name: "HinhThucDaoTao",
                table: "BacDaoTao");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNoiDung",
                table: "LoaiDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhoiNganh",
                table: "DanhMucNganhDaoTao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdHinhThucDaoTao",
                table: "BacDaoTao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_IdNoiDung",
                table: "LoaiDaoTao",
                column: "IdNoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_IdHinhThucDaoTao",
                table: "BacDaoTao",
                column: "IdHinhThucDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_BacDaoTao_HinhThucDaoTao_IdHinhThucDaoTao",
                table: "BacDaoTao",
                column: "IdHinhThucDaoTao",
                principalTable: "HinhThucDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_KhoiNganh_IdKhoiNganh",
                table: "DanhMucNganhDaoTao",
                column: "IdKhoiNganh",
                principalTable: "KhoiNganh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiDaoTao_NoiDung_IdNoiDung",
                table: "LoaiDaoTao",
                column: "IdNoiDung",
                principalTable: "NoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
