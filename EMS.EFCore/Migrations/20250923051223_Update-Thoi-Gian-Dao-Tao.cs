using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThoiGianDaoTao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangDiemTN_NamId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao");

            migrationBuilder.RenameColumn(
                name: "BangTotNghiep_NamId",
                table: "ThoiGianDaoTao",
                newName: "IdBangTotNghiep");

            migrationBuilder.RenameColumn(
                name: "BangDiemTN_NamId",
                table: "ThoiGianDaoTao",
                newName: "IdBangDiemTN");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_IdBangTotNghiep");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_BangDiemTN_NamId",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_IdBangDiemTN");

            migrationBuilder.AddColumn<string>(
                name: "GiayBaoTrungTuyen",
                table: "ThoiGianDaoTao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HanCheDKHP",
                table: "ThoiGianDaoTao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeSoDaoTao",
                table: "ThoiGianDaoTao",
                type: "numeric(5,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_IdBangDiemTN",
                table: "ThoiGianDaoTao",
                column: "IdBangDiemTN",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_IdBangTotNghiep",
                table: "ThoiGianDaoTao",
                column: "IdBangTotNghiep",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_IdBangDiemTN",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_IdBangTotNghiep",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "GiayBaoTrungTuyen",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "HanCheDKHP",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "HeSoDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.RenameColumn(
                name: "IdBangTotNghiep",
                table: "ThoiGianDaoTao",
                newName: "BangTotNghiep_NamId");

            migrationBuilder.RenameColumn(
                name: "IdBangDiemTN",
                table: "ThoiGianDaoTao",
                newName: "BangDiemTN_NamId");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_IdBangTotNghiep",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_BangTotNghiep_NamId");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_IdBangDiemTN",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_BangDiemTN_NamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangDiemTN_NamId",
                table: "ThoiGianDaoTao",
                column: "BangDiemTN_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_Bang_BangDiem_TN_BangTotNghiep_NamId",
                table: "ThoiGianDaoTao",
                column: "BangTotNghiep_NamId",
                principalTable: "Bang_BangDiem_TN",
                principalColumn: "Id");
        }
    }
}
