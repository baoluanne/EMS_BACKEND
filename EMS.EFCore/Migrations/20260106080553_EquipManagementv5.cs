using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EquipManagementv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_NguoiKiemKeId",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKe_TSTBDotKiemKe_DotKiemKeId",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKe_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_TSTBPhieuMuonTra_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLy_TSTBPhieuThanhLy_PhieuThanhLyId",
                table: "TSTBChiTietThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLy_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiCapNhat",
                table: "TSTBDotKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiTao",
                table: "TSTBDotKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_NguoiBatDauId",
                table: "TSTBDotKiemKe");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiCapNhat",
                table: "TSTBLoaiThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiTao",
                table: "TSTBLoaiThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiCapNhat",
                table: "TSTBNhaCungCap");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiTao",
                table: "TSTBNhaCungCap");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiXuLyId",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_TSTBNhaCungCap_NhaCungCapId",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTri_TSTBThietBi_ThietBiId",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_GiangVien_GiangVienId",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiDuyetId",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiTraId",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTra_SinhVien_SinhVienId",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLy");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBi_NguoiDung_IdNguoiCapNhat",
                table: "TSTBThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBi_NguoiDung_IdNguoiTao",
                table: "TSTBThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBi_PhongHoc_PhongHocId",
                table: "TSTBThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBi_TSTBLoaiThietBi_LoaiThietBiId",
                table: "TSTBThietBi");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBi_TSTBNhaCungCap_NhaCungCapId",
                table: "TSTBThietBi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBThietBi",
                table: "TSTBThietBi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuThanhLy",
                table: "TSTBPhieuThanhLy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuMuonTra",
                table: "TSTBPhieuMuonTra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuBaoTri",
                table: "TSTBPhieuBaoTri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBNhaCungCap",
                table: "TSTBNhaCungCap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBLoaiThietBi",
                table: "TSTBLoaiThietBi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBDotKiemKe",
                table: "TSTBDotKiemKe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietThanhLy",
                table: "TSTBChiTietThanhLy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietPhieuMuon",
                table: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietKiemKe",
                table: "TSTBChiTietKiemKe");

            migrationBuilder.RenameTable(
                name: "TSTBThietBi",
                newName: "TSTBThietBis");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuThanhLy",
                newName: "TSTBPhieuThanhLys");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuMuonTra",
                newName: "TSTBPhieuMuonTras");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuBaoTri",
                newName: "TSTBPhieuBaoTris");

            migrationBuilder.RenameTable(
                name: "TSTBNhaCungCap",
                newName: "TSTBNhaCungCaps");

            migrationBuilder.RenameTable(
                name: "TSTBLoaiThietBi",
                newName: "TSTBLoaiThietBis");

            migrationBuilder.RenameTable(
                name: "TSTBDotKiemKe",
                newName: "TSTBDotKiemKes");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietThanhLy",
                newName: "TSTBChiTietThanhLys");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietPhieuMuon",
                newName: "TSTBChiTietPhieuMuons");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietKiemKe",
                newName: "TSTBChiTietKiemKes");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_PhongHocId",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_PhongHocId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_NhaCungCapId",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_NhaCungCapId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_MaThietBi",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_MaThietBi");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_LoaiThietBiId",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_LoaiThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_IdNguoiTao",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBi_IdNguoiCapNhat",
                table: "TSTBThietBis",
                newName: "IX_TSTBThietBis_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLy_SoQuyetDinh",
                table: "TSTBPhieuThanhLys",
                newName: "IX_TSTBPhieuThanhLys_SoQuyetDinh");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLy_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLys",
                newName: "IX_TSTBPhieuThanhLys_NguoiLapPhieuId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLy_IdNguoiTao",
                table: "TSTBPhieuThanhLys",
                newName: "IX_TSTBPhieuThanhLys_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLy_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLys",
                newName: "IX_TSTBPhieuThanhLys_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_SinhVienId",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_SinhVienId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_NguoiTraId",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_NguoiTraId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_NguoiDuyetId",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_NguoiDuyetId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_MaPhieu",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_MaPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_IdNguoiTao",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTra_GiangVienId",
                table: "TSTBPhieuMuonTras",
                newName: "IX_TSTBPhieuMuonTras_GiangVienId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_ThietBiId",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_NhaCungCapId",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_NhaCungCapId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_NguoiXuLyId",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_NguoiXuLyId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_NguoiLapPhieuId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_MaPhieu",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_MaPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_IdNguoiTao",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTri_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTris",
                newName: "IX_TSTBPhieuBaoTris_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBNhaCungCap_IdNguoiTao",
                table: "TSTBNhaCungCaps",
                newName: "IX_TSTBNhaCungCaps_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBNhaCungCap_IdNguoiCapNhat",
                table: "TSTBNhaCungCaps",
                newName: "IX_TSTBNhaCungCaps_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBi_MaLoai",
                table: "TSTBLoaiThietBis",
                newName: "IX_TSTBLoaiThietBis_MaLoai");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBi_IdNguoiTao",
                table: "TSTBLoaiThietBis",
                newName: "IX_TSTBLoaiThietBis_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBi_IdNguoiCapNhat",
                table: "TSTBLoaiThietBis",
                newName: "IX_TSTBLoaiThietBis_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKe_NguoiBatDauId",
                table: "TSTBDotKiemKes",
                newName: "IX_TSTBDotKiemKes_NguoiBatDauId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKe_IdNguoiTao",
                table: "TSTBDotKiemKes",
                newName: "IX_TSTBDotKiemKes_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKe_IdNguoiCapNhat",
                table: "TSTBDotKiemKes",
                newName: "IX_TSTBDotKiemKes_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLy_ThietBiId",
                table: "TSTBChiTietThanhLys",
                newName: "IX_TSTBChiTietThanhLys_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLy_PhieuThanhLyId",
                table: "TSTBChiTietThanhLys",
                newName: "IX_TSTBChiTietThanhLys_PhieuThanhLyId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLy_IdNguoiTao",
                table: "TSTBChiTietThanhLys",
                newName: "IX_TSTBChiTietThanhLys_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLy_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLys",
                newName: "IX_TSTBChiTietThanhLys_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuon_ThietBiId",
                table: "TSTBChiTietPhieuMuons",
                newName: "IX_TSTBChiTietPhieuMuons_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuon_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuons",
                newName: "IX_TSTBChiTietPhieuMuons_PhieuMuonTraId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuon_IdNguoiTao",
                table: "TSTBChiTietPhieuMuons",
                newName: "IX_TSTBChiTietPhieuMuons_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuon_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuons",
                newName: "IX_TSTBChiTietPhieuMuons_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKe_ThietBiId",
                table: "TSTBChiTietKiemKes",
                newName: "IX_TSTBChiTietKiemKes_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKe_NguoiKiemKeId",
                table: "TSTBChiTietKiemKes",
                newName: "IX_TSTBChiTietKiemKes_NguoiKiemKeId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKe_IdNguoiTao",
                table: "TSTBChiTietKiemKes",
                newName: "IX_TSTBChiTietKiemKes_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKe_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKes",
                newName: "IX_TSTBChiTietKiemKes_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKe_DotKiemKeId",
                table: "TSTBChiTietKiemKes",
                newName: "IX_TSTBChiTietKiemKes_DotKiemKeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBThietBis",
                table: "TSTBThietBis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuThanhLys",
                table: "TSTBPhieuThanhLys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuMuonTras",
                table: "TSTBPhieuMuonTras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuBaoTris",
                table: "TSTBPhieuBaoTris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBNhaCungCaps",
                table: "TSTBNhaCungCaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBLoaiThietBis",
                table: "TSTBLoaiThietBis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBDotKiemKes",
                table: "TSTBDotKiemKes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietThanhLys",
                table: "TSTBChiTietThanhLys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietPhieuMuons",
                table: "TSTBChiTietPhieuMuons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietKiemKes",
                table: "TSTBChiTietKiemKes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKes",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietKiemKes",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_NguoiKiemKeId",
                table: "TSTBChiTietKiemKes",
                column: "NguoiKiemKeId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKes_TSTBDotKiemKes_DotKiemKeId",
                table: "TSTBChiTietKiemKes",
                column: "DotKiemKeId",
                principalTable: "TSTBDotKiemKes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKes_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietKiemKes",
                column: "ThietBiId",
                principalTable: "TSTBThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuons",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietPhieuMuons",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_TSTBPhieuMuonTras_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuons",
                column: "PhieuMuonTraId",
                principalTable: "TSTBPhieuMuonTras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietPhieuMuons",
                column: "ThietBiId",
                principalTable: "TSTBThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLys_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLys",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLys_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietThanhLys",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLys_TSTBPhieuThanhLys_PhieuThanhLyId",
                table: "TSTBChiTietThanhLys",
                column: "PhieuThanhLyId",
                principalTable: "TSTBPhieuThanhLys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLys_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietThanhLys",
                column: "ThietBiId",
                principalTable: "TSTBThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_IdNguoiCapNhat",
                table: "TSTBDotKiemKes",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_IdNguoiTao",
                table: "TSTBDotKiemKes",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_NguoiBatDauId",
                table: "TSTBDotKiemKes",
                column: "NguoiBatDauId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBLoaiThietBis_NguoiDung_IdNguoiCapNhat",
                table: "TSTBLoaiThietBis",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBLoaiThietBis_NguoiDung_IdNguoiTao",
                table: "TSTBLoaiThietBis",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBNhaCungCaps_NguoiDung_IdNguoiCapNhat",
                table: "TSTBNhaCungCaps",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBNhaCungCaps_NguoiDung_IdNguoiTao",
                table: "TSTBNhaCungCaps",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTris",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuBaoTris",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTris",
                column: "NguoiLapPhieuId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_NguoiXuLyId",
                table: "TSTBPhieuBaoTris",
                column: "NguoiXuLyId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_TSTBNhaCungCaps_NhaCungCapId",
                table: "TSTBPhieuBaoTris",
                column: "NhaCungCapId",
                principalTable: "TSTBNhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTris_TSTBThietBis_ThietBiId",
                table: "TSTBPhieuBaoTris",
                column: "ThietBiId",
                principalTable: "TSTBThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_GiangVien_GiangVienId",
                table: "TSTBPhieuMuonTras",
                column: "GiangVienId",
                principalTable: "GiangVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTras",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuMuonTras",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_NguoiDuyetId",
                table: "TSTBPhieuMuonTras",
                column: "NguoiDuyetId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_NguoiTraId",
                table: "TSTBPhieuMuonTras",
                column: "NguoiTraId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTras_SinhVien_SinhVienId",
                table: "TSTBPhieuMuonTras",
                column: "SinhVienId",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLys",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuThanhLys",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLys",
                column: "NguoiLapPhieuId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_NguoiDung_IdNguoiCapNhat",
                table: "TSTBThietBis",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_NguoiDung_IdNguoiTao",
                table: "TSTBThietBis",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_PhongHoc_PhongHocId",
                table: "TSTBThietBis",
                column: "PhongHocId",
                principalTable: "PhongHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_TSTBLoaiThietBis_LoaiThietBiId",
                table: "TSTBThietBis",
                column: "LoaiThietBiId",
                principalTable: "TSTBLoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBis_TSTBNhaCungCaps_NhaCungCapId",
                table: "TSTBThietBis",
                column: "NhaCungCapId",
                principalTable: "TSTBNhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKes_NguoiDung_NguoiKiemKeId",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKes_TSTBDotKiemKes_DotKiemKeId",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietKiemKes_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_TSTBPhieuMuonTras_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietPhieuMuons_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLys_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLys_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLys_TSTBPhieuThanhLys_PhieuThanhLyId",
                table: "TSTBChiTietThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBChiTietThanhLys_TSTBThietBis_ThietBiId",
                table: "TSTBChiTietThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_IdNguoiCapNhat",
                table: "TSTBDotKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_IdNguoiTao",
                table: "TSTBDotKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBDotKiemKes_NguoiDung_NguoiBatDauId",
                table: "TSTBDotKiemKes");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBLoaiThietBis_NguoiDung_IdNguoiCapNhat",
                table: "TSTBLoaiThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBLoaiThietBis_NguoiDung_IdNguoiTao",
                table: "TSTBLoaiThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBNhaCungCaps_NguoiDung_IdNguoiCapNhat",
                table: "TSTBNhaCungCaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBNhaCungCaps_NguoiDung_IdNguoiTao",
                table: "TSTBNhaCungCaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_NguoiDung_NguoiXuLyId",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_TSTBNhaCungCaps_NhaCungCapId",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuBaoTris_TSTBThietBis_ThietBiId",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_GiangVien_GiangVienId",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_NguoiDuyetId",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_NguoiDung_NguoiTraId",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuMuonTras_SinhVien_SinhVienId",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBPhieuThanhLys_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLys");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_NguoiDung_IdNguoiCapNhat",
                table: "TSTBThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_NguoiDung_IdNguoiTao",
                table: "TSTBThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_PhongHoc_PhongHocId",
                table: "TSTBThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_TSTBLoaiThietBis_LoaiThietBiId",
                table: "TSTBThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_TSTBThietBis_TSTBNhaCungCaps_NhaCungCapId",
                table: "TSTBThietBis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBThietBis",
                table: "TSTBThietBis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuThanhLys",
                table: "TSTBPhieuThanhLys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuMuonTras",
                table: "TSTBPhieuMuonTras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBPhieuBaoTris",
                table: "TSTBPhieuBaoTris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBNhaCungCaps",
                table: "TSTBNhaCungCaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBLoaiThietBis",
                table: "TSTBLoaiThietBis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBDotKiemKes",
                table: "TSTBDotKiemKes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietThanhLys",
                table: "TSTBChiTietThanhLys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietPhieuMuons",
                table: "TSTBChiTietPhieuMuons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSTBChiTietKiemKes",
                table: "TSTBChiTietKiemKes");

            migrationBuilder.RenameTable(
                name: "TSTBThietBis",
                newName: "TSTBThietBi");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuThanhLys",
                newName: "TSTBPhieuThanhLy");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuMuonTras",
                newName: "TSTBPhieuMuonTra");

            migrationBuilder.RenameTable(
                name: "TSTBPhieuBaoTris",
                newName: "TSTBPhieuBaoTri");

            migrationBuilder.RenameTable(
                name: "TSTBNhaCungCaps",
                newName: "TSTBNhaCungCap");

            migrationBuilder.RenameTable(
                name: "TSTBLoaiThietBis",
                newName: "TSTBLoaiThietBi");

            migrationBuilder.RenameTable(
                name: "TSTBDotKiemKes",
                newName: "TSTBDotKiemKe");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietThanhLys",
                newName: "TSTBChiTietThanhLy");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietPhieuMuons",
                newName: "TSTBChiTietPhieuMuon");

            migrationBuilder.RenameTable(
                name: "TSTBChiTietKiemKes",
                newName: "TSTBChiTietKiemKe");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_PhongHocId",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_PhongHocId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_NhaCungCapId",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_NhaCungCapId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_MaThietBi",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_MaThietBi");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_LoaiThietBiId",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_LoaiThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_IdNguoiTao",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBThietBis_IdNguoiCapNhat",
                table: "TSTBThietBi",
                newName: "IX_TSTBThietBi_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLys_SoQuyetDinh",
                table: "TSTBPhieuThanhLy",
                newName: "IX_TSTBPhieuThanhLy_SoQuyetDinh");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLys_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLy",
                newName: "IX_TSTBPhieuThanhLy_NguoiLapPhieuId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLys_IdNguoiTao",
                table: "TSTBPhieuThanhLy",
                newName: "IX_TSTBPhieuThanhLy_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuThanhLys_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLy",
                newName: "IX_TSTBPhieuThanhLy_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_SinhVienId",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_SinhVienId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_NguoiTraId",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_NguoiTraId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_NguoiDuyetId",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_NguoiDuyetId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_MaPhieu",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_MaPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_IdNguoiTao",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuMuonTras_GiangVienId",
                table: "TSTBPhieuMuonTra",
                newName: "IX_TSTBPhieuMuonTra_GiangVienId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_ThietBiId",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_NhaCungCapId",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_NhaCungCapId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_NguoiXuLyId",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_NguoiXuLyId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_NguoiLapPhieuId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_MaPhieu",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_MaPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_IdNguoiTao",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBPhieuBaoTris_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTri",
                newName: "IX_TSTBPhieuBaoTri_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBNhaCungCaps_IdNguoiTao",
                table: "TSTBNhaCungCap",
                newName: "IX_TSTBNhaCungCap_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBNhaCungCaps_IdNguoiCapNhat",
                table: "TSTBNhaCungCap",
                newName: "IX_TSTBNhaCungCap_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBis_MaLoai",
                table: "TSTBLoaiThietBi",
                newName: "IX_TSTBLoaiThietBi_MaLoai");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBis_IdNguoiTao",
                table: "TSTBLoaiThietBi",
                newName: "IX_TSTBLoaiThietBi_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBLoaiThietBis_IdNguoiCapNhat",
                table: "TSTBLoaiThietBi",
                newName: "IX_TSTBLoaiThietBi_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKes_NguoiBatDauId",
                table: "TSTBDotKiemKe",
                newName: "IX_TSTBDotKiemKe_NguoiBatDauId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKes_IdNguoiTao",
                table: "TSTBDotKiemKe",
                newName: "IX_TSTBDotKiemKe_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBDotKiemKes_IdNguoiCapNhat",
                table: "TSTBDotKiemKe",
                newName: "IX_TSTBDotKiemKe_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLys_ThietBiId",
                table: "TSTBChiTietThanhLy",
                newName: "IX_TSTBChiTietThanhLy_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLys_PhieuThanhLyId",
                table: "TSTBChiTietThanhLy",
                newName: "IX_TSTBChiTietThanhLy_PhieuThanhLyId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLys_IdNguoiTao",
                table: "TSTBChiTietThanhLy",
                newName: "IX_TSTBChiTietThanhLy_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietThanhLys_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLy",
                newName: "IX_TSTBChiTietThanhLy_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuons_ThietBiId",
                table: "TSTBChiTietPhieuMuon",
                newName: "IX_TSTBChiTietPhieuMuon_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuons_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuon",
                newName: "IX_TSTBChiTietPhieuMuon_PhieuMuonTraId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuons_IdNguoiTao",
                table: "TSTBChiTietPhieuMuon",
                newName: "IX_TSTBChiTietPhieuMuon_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietPhieuMuons_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuon",
                newName: "IX_TSTBChiTietPhieuMuon_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKes_ThietBiId",
                table: "TSTBChiTietKiemKe",
                newName: "IX_TSTBChiTietKiemKe_ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKes_NguoiKiemKeId",
                table: "TSTBChiTietKiemKe",
                newName: "IX_TSTBChiTietKiemKe_NguoiKiemKeId");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKes_IdNguoiTao",
                table: "TSTBChiTietKiemKe",
                newName: "IX_TSTBChiTietKiemKe_IdNguoiTao");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKes_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKe",
                newName: "IX_TSTBChiTietKiemKe_IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TSTBChiTietKiemKes_DotKiemKeId",
                table: "TSTBChiTietKiemKe",
                newName: "IX_TSTBChiTietKiemKe_DotKiemKeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBThietBi",
                table: "TSTBThietBi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuThanhLy",
                table: "TSTBPhieuThanhLy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuMuonTra",
                table: "TSTBPhieuMuonTra",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBPhieuBaoTri",
                table: "TSTBPhieuBaoTri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBNhaCungCap",
                table: "TSTBNhaCungCap",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBLoaiThietBi",
                table: "TSTBLoaiThietBi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBDotKiemKe",
                table: "TSTBDotKiemKe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietThanhLy",
                table: "TSTBChiTietThanhLy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietPhieuMuon",
                table: "TSTBChiTietPhieuMuon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSTBChiTietKiemKe",
                table: "TSTBChiTietKiemKe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietKiemKe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKe_NguoiDung_NguoiKiemKeId",
                table: "TSTBChiTietKiemKe",
                column: "NguoiKiemKeId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKe_TSTBDotKiemKe_DotKiemKeId",
                table: "TSTBChiTietKiemKe",
                column: "DotKiemKeId",
                principalTable: "TSTBDotKiemKe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietKiemKe_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietKiemKe",
                column: "ThietBiId",
                principalTable: "TSTBThietBi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuon",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietPhieuMuon",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_TSTBPhieuMuonTra_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuon",
                column: "PhieuMuonTraId",
                principalTable: "TSTBPhieuMuonTra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietPhieuMuon_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietPhieuMuon",
                column: "ThietBiId",
                principalTable: "TSTBThietBi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLy",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiTao",
                table: "TSTBChiTietThanhLy",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLy_TSTBPhieuThanhLy_PhieuThanhLyId",
                table: "TSTBChiTietThanhLy",
                column: "PhieuThanhLyId",
                principalTable: "TSTBPhieuThanhLy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBChiTietThanhLy_TSTBThietBi_ThietBiId",
                table: "TSTBChiTietThanhLy",
                column: "ThietBiId",
                principalTable: "TSTBThietBi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiCapNhat",
                table: "TSTBDotKiemKe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiTao",
                table: "TSTBDotKiemKe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBDotKiemKe_NguoiDung_NguoiBatDauId",
                table: "TSTBDotKiemKe",
                column: "NguoiBatDauId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiCapNhat",
                table: "TSTBLoaiThietBi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiTao",
                table: "TSTBLoaiThietBi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiCapNhat",
                table: "TSTBNhaCungCap",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiTao",
                table: "TSTBNhaCungCap",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTri",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuBaoTri",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTri",
                column: "NguoiLapPhieuId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiXuLyId",
                table: "TSTBPhieuBaoTri",
                column: "NguoiXuLyId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_TSTBNhaCungCap_NhaCungCapId",
                table: "TSTBPhieuBaoTri",
                column: "NhaCungCapId",
                principalTable: "TSTBNhaCungCap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuBaoTri_TSTBThietBi_ThietBiId",
                table: "TSTBPhieuBaoTri",
                column: "ThietBiId",
                principalTable: "TSTBThietBi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_GiangVien_GiangVienId",
                table: "TSTBPhieuMuonTra",
                column: "GiangVienId",
                principalTable: "GiangVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTra",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuMuonTra",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiDuyetId",
                table: "TSTBPhieuMuonTra",
                column: "NguoiDuyetId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiTraId",
                table: "TSTBPhieuMuonTra",
                column: "NguoiTraId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuMuonTra_SinhVien_SinhVienId",
                table: "TSTBPhieuMuonTra",
                column: "SinhVienId",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLy",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiTao",
                table: "TSTBPhieuThanhLy",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBPhieuThanhLy_NguoiDung_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLy",
                column: "NguoiLapPhieuId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBi_NguoiDung_IdNguoiCapNhat",
                table: "TSTBThietBi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBi_NguoiDung_IdNguoiTao",
                table: "TSTBThietBi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBi_PhongHoc_PhongHocId",
                table: "TSTBThietBi",
                column: "PhongHocId",
                principalTable: "PhongHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBi_TSTBLoaiThietBi_LoaiThietBiId",
                table: "TSTBThietBi",
                column: "LoaiThietBiId",
                principalTable: "TSTBLoaiThietBi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TSTBThietBi_TSTBNhaCungCap_NhaCungCapId",
                table: "TSTBThietBi",
                column: "NhaCungCapId",
                principalTable: "TSTBNhaCungCap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
