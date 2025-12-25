using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVienDCLL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoKhauThuongTru",
                table: "SinhVien",
                newName: "HKTTSoNhaThonXom");

            migrationBuilder.AddColumn<string>(
                name: "DCLLSoNhaThonXom",
                table: "SinhVien",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdDCLLHuyen",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdDCLLPhuongXa",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdDCLLTinh",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdHKTTHuyen",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdHKTTPhuongXa",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdHKTTTinh",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTHPTHuyen",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTHPTPhuongXa",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTHPTTinh",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdDCLLHuyen",
                table: "SinhVien",
                column: "IdDCLLHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdDCLLPhuongXa",
                table: "SinhVien",
                column: "IdDCLLPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdDCLLTinh",
                table: "SinhVien",
                column: "IdDCLLTinh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdHKTTHuyen",
                table: "SinhVien",
                column: "IdHKTTHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdHKTTPhuongXa",
                table: "SinhVien",
                column: "IdHKTTPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdHKTTTinh",
                table: "SinhVien",
                column: "IdHKTTTinh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTHPTHuyen",
                table: "SinhVien",
                column: "IdTHPTHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTHPTPhuongXa",
                table: "SinhVien",
                column: "IdTHPTPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTHPTTinh",
                table: "SinhVien",
                column: "IdTHPTTinh");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_PhuongXa_IdDCLLPhuongXa",
                table: "SinhVien",
                column: "IdDCLLPhuongXa",
                principalTable: "PhuongXa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_PhuongXa_IdHKTTPhuongXa",
                table: "SinhVien",
                column: "IdHKTTPhuongXa",
                principalTable: "PhuongXa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_PhuongXa_IdTHPTPhuongXa",
                table: "SinhVien",
                column: "IdTHPTPhuongXa",
                principalTable: "PhuongXa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdDCLLHuyen",
                table: "SinhVien",
                column: "IdDCLLHuyen",
                principalTable: "QuanHuyen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdHKTTHuyen",
                table: "SinhVien",
                column: "IdHKTTHuyen",
                principalTable: "QuanHuyen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdTHPTHuyen",
                table: "SinhVien",
                column: "IdTHPTHuyen",
                principalTable: "QuanHuyen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_TinhThanh_IdDCLLTinh",
                table: "SinhVien",
                column: "IdDCLLTinh",
                principalTable: "TinhThanh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_TinhThanh_IdHKTTTinh",
                table: "SinhVien",
                column: "IdHKTTTinh",
                principalTable: "TinhThanh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_TinhThanh_IdTHPTTinh",
                table: "SinhVien",
                column: "IdTHPTTinh",
                principalTable: "TinhThanh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_PhuongXa_IdDCLLPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_PhuongXa_IdHKTTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_PhuongXa_IdTHPTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdDCLLHuyen",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdHKTTHuyen",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdTHPTHuyen",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_TinhThanh_IdDCLLTinh",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_TinhThanh_IdHKTTTinh",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_TinhThanh_IdTHPTTinh",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdDCLLHuyen",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdDCLLPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdDCLLTinh",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdHKTTHuyen",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdHKTTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdHKTTTinh",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTHPTHuyen",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTHPTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTHPTTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "DCLLSoNhaThonXom",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdDCLLHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdDCLLPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdDCLLTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdHKTTHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdHKTTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdHKTTTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTHPTHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTHPTPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTHPTTinh",
                table: "SinhVien");

            migrationBuilder.RenameColumn(
                name: "HKTTSoNhaThonXom",
                table: "SinhVien",
                newName: "HoKhauThuongTru");
        }
    }
}
