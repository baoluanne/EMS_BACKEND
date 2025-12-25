using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Create_ChinhSachMienGiam_Table_And_Link_To_MienGiamSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MienGiamSinhVien_CongNoSinhVien_CongNoId",
                table: "MienGiamSinhVien");

            migrationBuilder.DropColumn(
                name: "LoaiMienGiam",
                table: "MienGiamSinhVien");

            migrationBuilder.AddColumn<Guid>(
                name: "ChinhSachMienGiamId",
                table: "MienGiamSinhVien",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ChinhSachMienGiam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenChinhSach = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LoaiChinhSach = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "SoTien"),
                    GiaTri = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ApDungCho = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "TatCa"),
                    DoiTuongId = table.Column<Guid>(type: "uuid", nullable: true),
                    NamHocHocKyId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrangThai = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "HoatDong"),
                    GhiChu = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChinhSachMienGiam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChinhSachMienGiam_NamHoc_HocKy_NamHocHocKyId",
                        column: x => x.NamHocHocKyId,
                        principalTable: "NamHoc_HocKy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChinhSachMienGiam_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChinhSachMienGiam_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_ChinhSachMienGiamId",
                table: "MienGiamSinhVien",
                column: "ChinhSachMienGiamId");

            migrationBuilder.CreateIndex(
                name: "IX_MienGiamSinhVien_TrangThai",
                table: "MienGiamSinhVien",
                column: "TrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_ChinhSachMienGiam_IdNguoiCapNhat",
                table: "ChinhSachMienGiam",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChinhSachMienGiam_IdNguoiTao",
                table: "ChinhSachMienGiam",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChinhSachMienGiam_NamHocHocKyId",
                table: "ChinhSachMienGiam",
                column: "NamHocHocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChinhSachMienGiam_TenChinhSach",
                table: "ChinhSachMienGiam",
                column: "TenChinhSach");

            migrationBuilder.CreateIndex(
                name: "IX_ChinhSachMienGiam_TrangThai",
                table: "ChinhSachMienGiam",
                column: "TrangThai");

            migrationBuilder.AddForeignKey(
                name: "FK_MienGiamSinhVien_ChinhSachMienGiam_ChinhSachMienGiamId",
                table: "MienGiamSinhVien",
                column: "ChinhSachMienGiamId",
                principalTable: "ChinhSachMienGiam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MienGiamSinhVien_CongNoSinhVien_CongNoId",
                table: "MienGiamSinhVien",
                column: "CongNoId",
                principalTable: "CongNoSinhVien",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MienGiamSinhVien_ChinhSachMienGiam_ChinhSachMienGiamId",
                table: "MienGiamSinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_MienGiamSinhVien_CongNoSinhVien_CongNoId",
                table: "MienGiamSinhVien");

            migrationBuilder.DropTable(
                name: "ChinhSachMienGiam");

            migrationBuilder.DropIndex(
                name: "IX_MienGiamSinhVien_ChinhSachMienGiamId",
                table: "MienGiamSinhVien");

            migrationBuilder.DropIndex(
                name: "IX_MienGiamSinhVien_TrangThai",
                table: "MienGiamSinhVien");

            migrationBuilder.DropColumn(
                name: "ChinhSachMienGiamId",
                table: "MienGiamSinhVien");

            migrationBuilder.AddColumn<string>(
                name: "LoaiMienGiam",
                table: "MienGiamSinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MienGiamSinhVien_CongNoSinhVien_CongNoId",
                table: "MienGiamSinhVien",
                column: "CongNoId",
                principalTable: "CongNoSinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
