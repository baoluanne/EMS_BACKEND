using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_FK_LoaiQuyetDinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiQuyetDinh",
                table: "QuyetDinh",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiQuyetDinh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoaiQD = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoaiQD = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: true),
                    STT = table.Column<int>(type: "integer", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiQuyetDinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiQuyetDinh_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiQuyetDinh_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_IdLoaiQuyetDinh",
                table: "QuyetDinh",
                column: "IdLoaiQuyetDinh");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiQuyetDinh_IdNguoiCapNhat",
                table: "LoaiQuyetDinh",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiQuyetDinh_IdNguoiTao",
                table: "LoaiQuyetDinh",
                column: "IdNguoiTao");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinh_LoaiQuyetDinh_IdLoaiQuyetDinh",
                table: "QuyetDinh",
                column: "IdLoaiQuyetDinh",
                principalTable: "LoaiQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinh_LoaiQuyetDinh_IdLoaiQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.DropTable(
                name: "LoaiQuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinh_IdLoaiQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.DropColumn(
                name: "IdLoaiQuyetDinh",
                table: "QuyetDinh");

            migrationBuilder.AddColumn<string>(
                name: "LoaiQuyetDinh",
                table: "QuyetDinh",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
