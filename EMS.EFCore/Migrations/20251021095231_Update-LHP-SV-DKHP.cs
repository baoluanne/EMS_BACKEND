using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLHPSVDKHP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_GiangVien_IdGiangVien",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LopHoc_IdLopHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_LopHocPhan_IdLopHocPhan",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_SinhVien_IdSinhVien",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "NgayDangKy",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "LopDuKien",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "SoTietLyThuyet",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "SoTietThucHanh",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "SoTinChi",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "TenLopHocPhan",
                table: "LopHocPhan");

            migrationBuilder.RenameColumn(
                name: "IdLopHoc",
                table: "LopHocPhan",
                newName: "IdKhoaHoc");

            migrationBuilder.RenameColumn(
                name: "IdGiangVien",
                table: "LopHocPhan",
                newName: "IdLoaiMonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_IdLopHoc",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_IdKhoaHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_IdGiangVien",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_IdLoaiMonHoc");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "LopHocPhan",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "IdBacDaoTao",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdCoSo",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhoaChuQuan",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiDaoTao",
                table: "LopHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LoaiLHP",
                table: "LopHocPhan",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiMonLTTH",
                table: "LopHocPhan",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LopBanDau",
                table: "LopHocPhan",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdBacDaoTao",
                table: "LopHocPhan",
                column: "IdBacDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdCoSo",
                table: "LopHocPhan",
                column: "IdCoSo");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdKhoaChuQuan",
                table: "LopHocPhan",
                column: "IdKhoaChuQuan");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdLoaiDaoTao",
                table: "LopHocPhan",
                column: "IdLoaiDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_BacDaoTao_IdBacDaoTao",
                table: "LopHocPhan",
                column: "IdBacDaoTao",
                principalTable: "BacDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_CoSoDaoTao_IdCoSo",
                table: "LopHocPhan",
                column: "IdCoSo",
                principalTable: "CoSoDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_KhoaHoc_IdKhoaHoc",
                table: "LopHocPhan",
                column: "IdKhoaHoc",
                principalTable: "KhoaHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_Khoa_IdKhoaChuQuan",
                table: "LopHocPhan",
                column: "IdKhoaChuQuan",
                principalTable: "Khoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LoaiDaoTao_IdLoaiDaoTao",
                table: "LopHocPhan",
                column: "IdLoaiDaoTao",
                principalTable: "LoaiDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LoaiMonHoc_IdLoaiMonHoc",
                table: "LopHocPhan",
                column: "IdLoaiMonHoc",
                principalTable: "LoaiMonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_LopHocPhan_IdLopHocPhan",
                table: "SinhVienDangKiHocPhan",
                column: "IdLopHocPhan",
                principalTable: "LopHocPhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_SinhVien_IdSinhVien",
                table: "SinhVienDangKiHocPhan",
                column: "IdSinhVien",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_BacDaoTao_IdBacDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_CoSoDaoTao_IdCoSo",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_KhoaHoc_IdKhoaHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_Khoa_IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LoaiDaoTao_IdLoaiDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LoaiMonHoc_IdLoaiMonHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_LopHocPhan_IdLopHocPhan",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_SinhVien_IdSinhVien",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdBacDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdCoSo",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdLoaiDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdBacDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdCoSo",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdKhoaChuQuan",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdLoaiDaoTao",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "LoaiLHP",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "LoaiMonLTTH",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "LopBanDau",
                table: "LopHocPhan");

            migrationBuilder.RenameColumn(
                name: "IdLoaiMonHoc",
                table: "LopHocPhan",
                newName: "IdGiangVien");

            migrationBuilder.RenameColumn(
                name: "IdKhoaHoc",
                table: "LopHocPhan",
                newName: "IdLopHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_IdLoaiMonHoc",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_IdGiangVien");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_IdKhoaHoc",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_IdLopHoc");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDangKy",
                table: "SinhVienDangKiHocPhan",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "LopHocPhan",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "LopDuKien",
                table: "LopHocPhan",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoTietLyThuyet",
                table: "LopHocPhan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoTietThucHanh",
                table: "LopHocPhan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoTinChi",
                table: "LopHocPhan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenLopHocPhan",
                table: "LopHocPhan",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiDangKy");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_GiangVien_IdGiangVien",
                table: "LopHocPhan",
                column: "IdGiangVien",
                principalTable: "GiangVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LopHoc_IdLopHoc",
                table: "LopHocPhan",
                column: "IdLopHoc",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_LopHocPhan_IdLopHocPhan",
                table: "SinhVienDangKiHocPhan",
                column: "IdLopHocPhan",
                principalTable: "LopHocPhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiDangKy",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiDangKy",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_SinhVien_IdSinhVien",
                table: "SinhVienDangKiHocPhan",
                column: "IdSinhVien",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
