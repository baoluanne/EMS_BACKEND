using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChuyenLopTuDoFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdLopHocPhan",
                table: "BangDiemChiTiet",
                column: "IdLopHocPhan");

            migrationBuilder.AddForeignKey(
                name: "FK_BangDiemChiTiet_LopHocPhan_IdLopHocPhan",
                table: "BangDiemChiTiet",
                column: "IdLopHocPhan",
                principalTable: "LopHocPhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BangDiemChiTiet_LopHocPhan_IdLopHocPhan",
                table: "BangDiemChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_BangDiemChiTiet_IdLopHocPhan",
                table: "BangDiemChiTiet");
        }
    }
}
