using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddChuongTrinhKhungTinChi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuongTrinhKhungTinChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaChuongTrinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenChuongTrinh = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsBlock = table.Column<bool>(type: "boolean", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    GhiChuTiengAnh = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IdCoSoDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLoaiDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNganhHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBacDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChuyenNganh = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ChuongTrinhKhungTinChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_BacDaoTao_IdBacDaoTao",
                        column: x => x.IdBacDaoTao,
                        principalTable: "BacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_ChuyenNganh_IdChuyenNganh",
                        column: x => x.IdChuyenNganh,
                        principalTable: "ChuyenNganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_CoSoDaoTao_IdCoSoDaoTao",
                        column: x => x.IdCoSoDaoTao,
                        principalTable: "CoSoDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_LoaiDaoTao_IdLoaiDaoTao",
                        column: x => x.IdLoaiDaoTao,
                        principalTable: "LoaiDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_NganhHoc_IdNganhHoc",
                        column: x => x.IdNganhHoc,
                        principalTable: "NganhHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhungHocKy_TinChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsBatBuoc = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IdChuongTrinhKhung = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHocHeDaoTao = table.Column<Guid>(type: "uuid", nullable: false),
                    HocKy = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_ChiTietKhungHocKy_TinChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietKhungHocKy_TinChi_ChuongTrinhKhungTinChi_IdChuongTri~",
                        column: x => x.IdChuongTrinhKhung,
                        principalTable: "ChuongTrinhKhungTinChi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhungHocKy_TinChi_MonHocBacDaoTao_IdMonHocHeDaoTao",
                        column: x => x.IdMonHocHeDaoTao,
                        principalTable: "MonHocBacDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdChuongTrinhKhung",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdChuongTrinhKhung");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdMonHocHeDaoTao",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdMonHocHeDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_NguoiTaoId",
                table: "ChiTietKhungHocKy_TinChi",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdBacDaoTao",
                table: "ChuongTrinhKhungTinChi",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdChuyenNganh",
                table: "ChuongTrinhKhungTinChi",
                column: "IdChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdCoSoDaoTao",
                table: "ChuongTrinhKhungTinChi",
                column: "IdCoSoDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdKhoaHoc",
                table: "ChuongTrinhKhungTinChi",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdLoaiDaoTao",
                table: "ChuongTrinhKhungTinChi",
                column: "IdLoaiDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdNganhHoc",
                table: "ChuongTrinhKhungTinChi",
                column: "IdNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_NguoiTaoId",
                table: "ChuongTrinhKhungTinChi",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropTable(
                name: "ChuongTrinhKhungTinChi");
        }
    }
}
