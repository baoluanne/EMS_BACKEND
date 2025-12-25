using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DanToc",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "QuocTich",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TenDoiTuong",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TenDoiTuongChinhSach",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "TonGiao",
                table: "SinhVien");

            migrationBuilder.AddColumn<int>(
                name: "DoiTuongChinhSach",
                table: "SinhVien",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdDanToc",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdDoiTuongUuTien",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuocTich",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdTonGiao",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KiemTraSinhVien",
                table: "SinhVien",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiCuTru",
                table: "SinhVien",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanhMucDanToc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDanToc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenDanToc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucDanToc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucDanToc_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucDanToc_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucDoiTuongUuTien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaDoiTuong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenDoiTuong = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucDoiTuongUuTien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucQuocTich",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaQuocGia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenQuocGia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucQuocTich", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucQuocTich_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucQuocTich_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTonGiao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaTonGiao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenTonGiao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DanhMucTonGiao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucTonGiao_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucTonGiao_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdDanToc",
                table: "SinhVien",
                column: "IdDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdDoiTuongUuTien",
                table: "SinhVien",
                column: "IdDoiTuongUuTien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdQuocTich",
                table: "SinhVien",
                column: "IdQuocTich");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdTonGiao",
                table: "SinhVien",
                column: "IdTonGiao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanToc_MaDanToc",
                table: "DanhMucDanToc",
                column: "MaDanToc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanToc_NguoiCapNhapId",
                table: "DanhMucDanToc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanToc_NguoiTaoId",
                table: "DanhMucDanToc",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDoiTuongUuTien_MaDoiTuong",
                table: "DanhMucDoiTuongUuTien",
                column: "MaDoiTuong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDoiTuongUuTien_NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDoiTuongUuTien_NguoiTaoId",
                table: "DanhMucDoiTuongUuTien",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucQuocTich_MaQuocGia",
                table: "DanhMucQuocTich",
                column: "MaQuocGia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucQuocTich_NguoiCapNhapId",
                table: "DanhMucQuocTich",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucQuocTich_NguoiTaoId",
                table: "DanhMucQuocTich",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTonGiao_MaTonGiao",
                table: "DanhMucTonGiao",
                column: "MaTonGiao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTonGiao_NguoiCapNhapId",
                table: "DanhMucTonGiao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTonGiao_NguoiTaoId",
                table: "DanhMucTonGiao",
                column: "NguoiTaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_DanhMucDanToc_IdDanToc",
                table: "SinhVien",
                column: "IdDanToc",
                principalTable: "DanhMucDanToc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_DanhMucDoiTuongUuTien_IdDoiTuongUuTien",
                table: "SinhVien",
                column: "IdDoiTuongUuTien",
                principalTable: "DanhMucDoiTuongUuTien",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_DanhMucQuocTich_IdQuocTich",
                table: "SinhVien",
                column: "IdQuocTich",
                principalTable: "DanhMucQuocTich",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_DanhMucTonGiao_IdTonGiao",
                table: "SinhVien",
                column: "IdTonGiao",
                principalTable: "DanhMucTonGiao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_DanhMucDanToc_IdDanToc",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_DanhMucDoiTuongUuTien_IdDoiTuongUuTien",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_DanhMucQuocTich_IdQuocTich",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_DanhMucTonGiao_IdTonGiao",
                table: "SinhVien");

            migrationBuilder.DropTable(
                name: "DanhMucDanToc");

            migrationBuilder.DropTable(
                name: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropTable(
                name: "DanhMucQuocTich");

            migrationBuilder.DropTable(
                name: "DanhMucTonGiao");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdDanToc",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdDoiTuongUuTien",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdQuocTich",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdTonGiao",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "DoiTuongChinhSach",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdDanToc",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdDoiTuongUuTien",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdQuocTich",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdTonGiao",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "KiemTraSinhVien",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "LoaiCuTru",
                table: "SinhVien");

            migrationBuilder.AddColumn<string>(
                name: "DanToc",
                table: "SinhVien",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuocTich",
                table: "SinhVien",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDoiTuong",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDoiTuongChinhSach",
                table: "SinhVien",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TonGiao",
                table: "SinhVien",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
