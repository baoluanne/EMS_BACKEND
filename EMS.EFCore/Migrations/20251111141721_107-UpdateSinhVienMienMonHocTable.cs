using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class _107UpdateSinhVienMienMonHocTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_MonHoc_IdMonHoc",
                table: "SinhVienMienMonHoc");

            migrationBuilder.RenameColumn(
                name: "IdMonHoc",
                table: "SinhVienMienMonHoc",
                newName: "IdMonHocBacDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienMienMonHoc_IdMonHoc",
                table: "SinhVienMienMonHoc",
                newName: "IX_SinhVienMienMonHoc_IdMonHocBacDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_MonHocBacDaoTao_IdMonHocBacDaoTao",
                table: "SinhVienMienMonHoc",
                column: "IdMonHocBacDaoTao",
                principalTable: "MonHocBacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_MonHocBacDaoTao_IdMonHocBacDaoTao",
                table: "SinhVienMienMonHoc");

            migrationBuilder.RenameColumn(
                name: "IdMonHocBacDaoTao",
                table: "SinhVienMienMonHoc",
                newName: "IdMonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienMienMonHoc_IdMonHocBacDaoTao",
                table: "SinhVienMienMonHoc",
                newName: "IX_SinhVienMienMonHoc_IdMonHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_MonHoc_IdMonHoc",
                table: "SinhVienMienMonHoc",
                column: "IdMonHoc",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
