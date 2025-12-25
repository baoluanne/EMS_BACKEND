using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class NghiepVuDangKyHocPhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                    @"ALTER TABLE ""SinhVienDangKiHocPhan""
                        ALTER COLUMN ""NguonDangKy"" TYPE integer
                        USING ""NguonDangKy""::integer;"
                );

            migrationBuilder.AddColumn<Guid>(
                name: "IdChuongTrinhKhungTinChi",
                table: "LopHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTuDongTao",
                table: "LopHocPhan",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayBatDauHuyDK",
                table: "HocKy",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayKetThucHuyDK",
                table: "HocKy",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BangDiemChiTiet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSinhVien = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: true),
                    DiemTongKet = table.Column<decimal>(type: "numeric", nullable: false),
                    LanHoc = table.Column<int>(type: "integer", nullable: false),
                    IsDiemCaoNhat = table.Column<bool>(type: "boolean", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangDiemChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangDiemChiTiet_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BangDiemChiTiet_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BangDiemChiTiet_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BangDiemChiTiet_SinhVien_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonTienQuyet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonTienQuyet = table.Column<Guid>(type: "uuid", nullable: false),
                    YeuCauDiemToiThieu = table.Column<decimal>(type: "numeric", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonTienQuyet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonTienQuyet_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonTienQuyet_MonHoc_IdMonTienQuyet",
                        column: x => x.IdMonTienQuyet,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonTienQuyet_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonTienQuyet_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_TrangThaiDangKyLHP",
                table: "SinhVienDangKiHocPhan",
                column: "TrangThaiDangKyLHP");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdChuongTrinhKhungTinChi",
                table: "LopHocPhan",
                column: "IdChuongTrinhKhungTinChi");

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdMonHoc",
                table: "BangDiemChiTiet",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdNguoiCapNhat",
                table: "BangDiemChiTiet",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdNguoiTao",
                table: "BangDiemChiTiet",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_BangDiemChiTiet_IdSinhVien_IdMonHoc_LanHoc",
                table: "BangDiemChiTiet",
                columns: new[] { "IdSinhVien", "IdMonHoc", "LanHoc" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonTienQuyet_IdMonHoc_IdMonTienQuyet",
                table: "MonTienQuyet",
                columns: new[] { "IdMonHoc", "IdMonTienQuyet" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonTienQuyet_IdMonTienQuyet",
                table: "MonTienQuyet",
                column: "IdMonTienQuyet");

            migrationBuilder.CreateIndex(
                name: "IX_MonTienQuyet_IdNguoiCapNhat",
                table: "MonTienQuyet",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_MonTienQuyet_IdNguoiTao",
                table: "MonTienQuyet",
                column: "IdNguoiTao");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_ChuongTrinhKhungTinChi_IdChuongTrinhKhungTinChi",
                table: "LopHocPhan",
                column: "IdChuongTrinhKhungTinChi",
                principalTable: "ChuongTrinhKhungTinChi",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_ChuongTrinhKhungTinChi_IdChuongTrinhKhungTinChi",
                table: "LopHocPhan");

            migrationBuilder.DropTable(
                name: "BangDiemChiTiet");

            migrationBuilder.DropTable(
                name: "MonTienQuyet");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienDangKiHocPhan_TrangThaiDangKyLHP",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdChuongTrinhKhungTinChi",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdChuongTrinhKhungTinChi",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IsTuDongTao",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "NgayBatDauHuyDK",
                table: "HocKy");

            migrationBuilder.DropColumn(
                name: "NgayKetThucHuyDK",
                table: "HocKy");

            migrationBuilder.AlterColumn<string>(
                name: "NguonDangKy",
                table: "SinhVienDangKiHocPhan",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
