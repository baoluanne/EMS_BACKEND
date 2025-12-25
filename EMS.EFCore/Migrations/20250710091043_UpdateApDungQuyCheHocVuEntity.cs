using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApDungQuyCheHocVuEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdBacDaoTao",
                table: "ApDungQuyCheHocVu",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdKhoaHoc",
                table: "ApDungQuyCheHocVu",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdLoaiDaoTao",
                table: "ApDungQuyCheHocVu",
                column: "IdLoaiDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_BacDaoTao_IdBacDaoTao",
                table: "ApDungQuyCheHocVu",
                column: "IdBacDaoTao",
                principalTable: "BacDaoTao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_KhoaHoc_IdKhoaHoc",
                table: "ApDungQuyCheHocVu",
                column: "IdKhoaHoc",
                principalTable: "KhoaHoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_LoaiDaoTao_IdLoaiDaoTao",
                table: "ApDungQuyCheHocVu",
                column: "IdLoaiDaoTao",
                principalTable: "LoaiDaoTao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_BacDaoTao_IdBacDaoTao",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_KhoaHoc_IdKhoaHoc",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_LoaiDaoTao_IdLoaiDaoTao",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropIndex(
                name: "IX_ApDungQuyCheHocVu_IdBacDaoTao",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropIndex(
                name: "IX_ApDungQuyCheHocVu_IdKhoaHoc",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropIndex(
                name: "IX_ApDungQuyCheHocVu_IdLoaiDaoTao",
                table: "ApDungQuyCheHocVu");
        }
    }
}
