using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMonHocBacDaoTaoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_MonHoc_MonHocId",
                table: "MonHocBacDaoTao");

            migrationBuilder.RenameColumn(
                name: "MonHocId",
                table: "MonHocBacDaoTao",
                newName: "IdMonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_MonHocBacDaoTao_MonHocId",
                table: "MonHocBacDaoTao",
                newName: "IX_MonHocBacDaoTao_IdMonHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_MonHoc_IdMonHoc",
                table: "MonHocBacDaoTao",
                column: "IdMonHoc",
                principalTable: "MonHoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_MonHoc_IdMonHoc",
                table: "MonHocBacDaoTao");

            migrationBuilder.RenameColumn(
                name: "IdMonHoc",
                table: "MonHocBacDaoTao",
                newName: "MonHocId");

            migrationBuilder.RenameIndex(
                name: "IX_MonHocBacDaoTao_IdMonHoc",
                table: "MonHocBacDaoTao",
                newName: "IX_MonHocBacDaoTao_MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_MonHoc_MonHocId",
                table: "MonHocBacDaoTao",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id");
        }
    }
}
