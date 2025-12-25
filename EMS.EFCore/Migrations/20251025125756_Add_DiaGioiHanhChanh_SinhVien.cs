using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Add_DiaGioiHanhChanh_SinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiSinhHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "NoiSinhPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "NoiSinhTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TenHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TenPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TenTinh",
                table: "SinhVien");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNoiSinhHuyen",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNoiSinhPhuongXa",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNoiSinhTinh",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTenHuyen",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTenPhuongXa",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTenTinh",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNoiSinhHuyen",
                table: "SinhVien",
                column: "IdNoiSinhHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNoiSinhPhuongXa",
                table: "SinhVien",
                column: "IdNoiSinhPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNoiSinhTinh",
                table: "SinhVien",
                column: "IdNoiSinhTinh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTenHuyen",
                table: "SinhVien",
                column: "IdTenHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTenPhuongXa",
                table: "SinhVien",
                column: "IdTenPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTenTinh",
                table: "SinhVien",
                column: "IdTenTinh");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_PhuongXa_IdNoiSinhPhuongXa",
                table: "SinhVien",
                column: "IdNoiSinhPhuongXa",
                principalTable: "PhuongXa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_PhuongXa_IdTenPhuongXa",
                table: "SinhVien",
                column: "IdTenPhuongXa",
                principalTable: "PhuongXa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdNoiSinhHuyen",
                table: "SinhVien",
                column: "IdNoiSinhHuyen",
                principalTable: "QuanHuyen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdTenHuyen",
                table: "SinhVien",
                column: "IdTenHuyen",
                principalTable: "QuanHuyen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_TinhThanh_IdNoiSinhTinh",
                table: "SinhVien",
                column: "IdNoiSinhTinh",
                principalTable: "TinhThanh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_TinhThanh_IdTenTinh",
                table: "SinhVien",
                column: "IdTenTinh",
                principalTable: "TinhThanh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_PhuongXa_IdNoiSinhPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_PhuongXa_IdTenPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdNoiSinhHuyen",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_QuanHuyen_IdTenHuyen",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_TinhThanh_IdNoiSinhTinh",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_TinhThanh_IdTenTinh",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdNoiSinhHuyen",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdNoiSinhPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdNoiSinhTinh",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTenHuyen",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTenPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTenTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdNoiSinhHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdNoiSinhPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdNoiSinhTinh",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTenHuyen",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTenPhuongXa",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTenTinh",
                table: "SinhVien");

            migrationBuilder.AddColumn<string>(
                name: "NoiSinhHuyen",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiSinhPhuongXa",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiSinhTinh",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenHuyen",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenPhuongXa",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTinh",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
