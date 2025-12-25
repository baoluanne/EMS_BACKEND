using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesDiaGioiHanhChinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TinhThanh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTinhThanh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenTinhThanh = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_TinhThanh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinhThanh_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhThanh_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaQuanHuyen = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenQuanHuyen = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdTinhThanh = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_QuanHuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuanHuyen_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanh_IdTinhThanh",
                        column: x => x.IdTinhThanh,
                        principalTable: "TinhThanh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhuongXa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhuongXa = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenPhuongXa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdQuanHuyen = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_PhuongXa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuongXa_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhuongXa_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhuongXa_QuanHuyen_IdQuanHuyen",
                        column: x => x.IdQuanHuyen,
                        principalTable: "QuanHuyen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_IdQuanHuyen",
                table: "PhuongXa",
                column: "IdQuanHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_MaPhuongXa",
                table: "PhuongXa",
                column: "MaPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_NguoiCapNhapId",
                table: "PhuongXa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_NguoiTaoId",
                table: "PhuongXa",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_IdTinhThanh",
                table: "QuanHuyen",
                column: "IdTinhThanh");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_MaQuanHuyen",
                table: "QuanHuyen",
                column: "MaQuanHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_NguoiCapNhapId",
                table: "QuanHuyen",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_NguoiTaoId",
                table: "QuanHuyen",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanh_MaTinhThanh",
                table: "TinhThanh",
                column: "MaTinhThanh");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanh_NguoiCapNhapId",
                table: "TinhThanh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanh_NguoiTaoId",
                table: "TinhThanh",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhuongXa");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "TinhThanh");
        }
    }
}
