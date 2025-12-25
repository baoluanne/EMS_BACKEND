using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddKeHoachDaoTao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocKy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNamHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    TenDot = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    SoTuan = table.Column<int>(type: "integer", precision: 5, scale: 2, nullable: true),
                    HeSo = table.Column<double>(type: "double precision", precision: 5, scale: 2, nullable: true),
                    TuThang = table.Column<int>(type: "integer", nullable: true),
                    DenThang = table.Column<int>(type: "integer", nullable: true),
                    NamHanhChinh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TuNgay = table.Column<int>(type: "integer", nullable: true),
                    DenNgay = table.Column<int>(type: "integer", nullable: true),
                    TenDayDu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TenTiengAnh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDKHP = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDKNTTT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocKy_NamHoc_IdNamHoc",
                        column: x => x.IdNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocKy_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HocKy_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KeHoachDaoTao_NienChe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChiTietKhungHocKy_NienChe = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IsHocKyChinh = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachDaoTao_NienChe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_NienChe_ChiTietChuongTrinhKhung_NienChe_IdChi~",
                        column: x => x.IdChiTietKhungHocKy_NienChe,
                        principalTable: "ChiTietChuongTrinhKhung_NienChe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_NienChe_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KeHoachDaoTao_TinChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChiTietKhungHocKy_TinChi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHocKy = table.Column<Guid>(type: "uuid", nullable: false),
                    IsHocKyChinh = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachDaoTao_TinChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_TinChi_ChiTietKhungHocKy_TinChi_IdChiTietKhun~",
                        column: x => x.IdChiTietKhungHocKy_TinChi,
                        principalTable: "ChiTietKhungHocKy_TinChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_TinChi_HocKy_IdHocKy",
                        column: x => x.IdHocKy,
                        principalTable: "HocKy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_IdNamHoc",
                table: "HocKy",
                column: "IdNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_NguoiCapNhapId",
                table: "HocKy",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_NguoiTaoId",
                table: "HocKy",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_IdChiTietKhungHocKy_NienChe",
                table: "KeHoachDaoTao_NienChe",
                column: "IdChiTietKhungHocKy_NienChe");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_IdHocKy",
                table: "KeHoachDaoTao_NienChe",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_NguoiTaoId",
                table: "KeHoachDaoTao_NienChe",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_IdChiTietKhungHocKy_TinChi",
                table: "KeHoachDaoTao_TinChi",
                column: "IdChiTietKhungHocKy_TinChi");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_IdHocKy",
                table: "KeHoachDaoTao_TinChi",
                column: "IdHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_NguoiTaoId",
                table: "KeHoachDaoTao_TinChi",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropTable(
                name: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropTable(
                name: "HocKy");
        }
    }
}
