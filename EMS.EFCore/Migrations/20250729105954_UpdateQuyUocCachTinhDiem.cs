using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuyUocCachTinhDiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_MonHocBacDaoTao_IdMonHocHeD~",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_MonHocBacDaoTao_IdMonHocHeDaoTao",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.RenameColumn(
                name: "IdMonHocHeDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IdMonHocBacDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdMonHocHeDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IX_ChiTietKhungHocKy_TinChi_IdMonHocBacDaoTao");

            migrationBuilder.RenameColumn(
                name: "IdMonHocHeDaoTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IdMonHocBacDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdMonHocHeDaoTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IX_ChiTietChuongTrinhKhung_NienChe_IdMonHocBacDaoTao");

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao",
                column: "IdQuyUocCotDiem_NC");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao",
                column: "IdQuyUocCotDiem_TC");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_MonHocBacDaoTao_IdMonHocBac~",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdMonHocBacDaoTao",
                principalTable: "MonHocBacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_MonHocBacDaoTao_IdMonHocBacDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdMonHocBacDaoTao",
                principalTable: "MonHocBacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_QuyUocCotDiem_NC_IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao",
                column: "IdQuyUocCotDiem_NC",
                principalTable: "QuyUocCotDiem_NC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_QuyUocCotDiem_TC_IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao",
                column: "IdQuyUocCotDiem_TC",
                principalTable: "QuyUocCotDiem_TC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_MonHocBacDaoTao_IdMonHocBac~",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_MonHocBacDaoTao_IdMonHocBacDaoTao",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_QuyUocCotDiem_NC_IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_QuyUocCotDiem_TC_IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_MonHocBacDaoTao_IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_MonHocBacDaoTao_IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropColumn(
                name: "IdQuyUocCotDiem_NC",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropColumn(
                name: "IdQuyUocCotDiem_TC",
                table: "MonHocBacDaoTao");

            migrationBuilder.RenameColumn(
                name: "IdMonHocBacDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IdMonHocHeDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdMonHocBacDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IX_ChiTietKhungHocKy_TinChi_IdMonHocHeDaoTao");

            migrationBuilder.RenameColumn(
                name: "IdMonHocBacDaoTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IdMonHocHeDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdMonHocBacDaoTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IX_ChiTietChuongTrinhKhung_NienChe_IdMonHocHeDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_MonHocBacDaoTao_IdMonHocHeD~",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdMonHocHeDaoTao",
                principalTable: "MonHocBacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_MonHocBacDaoTao_IdMonHocHeDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdMonHocHeDaoTao",
                principalTable: "MonHocBacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
