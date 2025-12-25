using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AutoCleanUp_Redundant_FKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS ""vw_ChuongTrinhKhung_Merged"";
            ");
            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiCapNhapId",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiTaoId",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_BacDaoTao_NguoiDung_NguoiCapNhapId",
                table: "BacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_BacDaoTao_NguoiDung_NguoiTaoId",
                table: "BacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiCapNhapId",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiTaoId",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropForeignKey(
                name: "FK_CaHoc_NguoiDung_NguoiCapNhapId",
                table: "CaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaHoc_NguoiDung_NguoiTaoId",
                table: "CaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiTaoId",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiTaoId",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_NguoiCapNhapId",
                table: "ChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_NguoiTaoId",
                table: "ChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_ChungChi_NguoiDung_NguoiCapNhapId",
                table: "ChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChungChi_NguoiDung_NguoiTaoId",
                table: "ChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiTaoId",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiTaoId",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenLop_NguoiDung_NguoiCapNhapId",
                table: "ChuyenLop");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenLop_NguoiDung_NguoiTaoId",
                table: "ChuyenLop");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_NguoiCapNhapId",
                table: "ChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_NguoiTaoId",
                table: "ChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_NguoiCapNhapId",
                table: "ChuyenTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_NguoiTaoId",
                table: "ChuyenTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_NguoiCapNhapId",
                table: "CoSoDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_NguoiTaoId",
                table: "CoSoDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_NguoiCapNhapId",
                table: "DangKyMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_NguoiTaoId",
                table: "DangKyMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_NguoiCapNhapId",
                table: "DanhMucBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_NguoiTaoId",
                table: "DanhMucBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_NguoiCapNhapId",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_NguoiTaoId",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_NguoiCapNhapId",
                table: "DanhMucDanToc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_NguoiTaoId",
                table: "DanhMucDanToc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiTaoId",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_NguoiCapNhapId",
                table: "DanhMucHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_NguoiTaoId",
                table: "DanhMucHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiCapNhapId",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiTaoId",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiTaoId",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiTaoId",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_NguoiCapNhapId",
                table: "DanhMucNoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_NguoiTaoId",
                table: "DanhMucNoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_NguoiCapNhapId",
                table: "DanhMucPhongBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_NguoiTaoId",
                table: "DanhMucPhongBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_NguoiCapNhapId",
                table: "DanhMucQuocTich");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_NguoiTaoId",
                table: "DanhMucQuocTich");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucTonGiao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_NguoiTaoId",
                table: "DanhMucTonGiao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiCapNhapId",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiTaoId",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiTaoId",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropForeignKey(
                name: "FK_DayNha_NguoiDung_NguoiCapNhapId",
                table: "DayNha");

            migrationBuilder.DropForeignKey(
                name: "FK_DayNha_NguoiDung_NguoiTaoId",
                table: "DayNha");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_NguoiCapNhapId",
                table: "DiaDiemPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_NguoiTaoId",
                table: "DiaDiemPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_NguoiDung_NguoiCapNhapId",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_NguoiDung_NguoiTaoId",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_HanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "HanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_HanhViViPham_NguoiDung_NguoiTaoId",
                table: "HanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_NguoiCapNhapId",
                table: "HinhThucDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_NguoiTaoId",
                table: "HinhThucDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucThi_NguoiDung_NguoiCapNhapId",
                table: "HinhThucThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucThi_NguoiDung_NguoiTaoId",
                table: "HinhThucThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiTaoId",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocKy_NguoiDung_NguoiCapNhapId",
                table: "HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_HocKy_NguoiDung_NguoiTaoId",
                table: "HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVi_NguoiDung_NguoiCapNhapId",
                table: "HocVi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVi_NguoiDung_NguoiTaoId",
                table: "HocVi");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSoSV_NguoiDung_NguoiCapNhapId",
                table: "HoSoSV");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSoSV_NguoiDung_NguoiTaoId",
                table: "HoSoSV");

            migrationBuilder.DropForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiCapNhapId",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiTaoId",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiTaoId",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiTaoId",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_KhenThuong_NguoiDung_NguoiCapNhapId",
                table: "KhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_KhenThuong_NguoiDung_NguoiTaoId",
                table: "KhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_NguoiDung_NguoiCapNhapId",
                table: "Khoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_NguoiDung_NguoiTaoId",
                table: "Khoa");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_NguoiDung_NguoiCapNhapId",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_NguoiDung_NguoiTaoId",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_NguoiCapNhapId",
                table: "KhoiKienThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_NguoiTaoId",
                table: "KhoiKienThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiNganh_NguoiDung_NguoiCapNhapId",
                table: "KhoiNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiNganh_NguoiDung_NguoiTaoId",
                table: "KhoiNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuLamTron_NguoiDung_NguoiCapNhapId",
                table: "KieuLamTron");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuLamTron_NguoiDung_NguoiTaoId",
                table: "KieuLamTron");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_NguoiCapNhapId",
                table: "KieuMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_NguoiTaoId",
                table: "KieuMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LichHocThi_NguoiDung_NguoiCapNhapId",
                table: "LichHocThi");

            migrationBuilder.DropForeignKey(
                name: "FK_LichHocThi_NguoiDung_NguoiTaoId",
                table: "LichHocThi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_NguoiCapNhapId",
                table: "LoaiChucVu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_NguoiTaoId",
                table: "LoaiChucVu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_NguoiCapNhapId",
                table: "LoaiChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_NguoiTaoId",
                table: "LoaiChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_NguoiCapNhapId",
                table: "LoaiDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_NguoiTaoId",
                table: "LoaiDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_NguoiCapNhapId",
                table: "LoaiGiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_NguoiTaoId",
                table: "LoaiGiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_NguoiTaoId",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiCapNhapId",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiTaoId",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                table: "LoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_NguoiTaoId",
                table: "LoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_NguoiCapNhapId",
                table: "LoaiKhoanThu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_NguoiTaoId",
                table: "LoaiKhoanThu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_NguoiCapNhapId",
                table: "LoaiMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_NguoiTaoId",
                table: "LoaiMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiPhong_NguoiDung_NguoiCapNhapId",
                table: "LoaiPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiPhong_NguoiDung_NguoiTaoId",
                table: "LoaiPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_NguoiCapNhapId",
                table: "LoaiSinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_NguoiTaoId",
                table: "LoaiSinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiTiet_NguoiDung_NguoiCapNhapId",
                table: "LoaiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiTiet_NguoiDung_NguoiTaoId",
                table: "LoaiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_NguoiDung_NguoiCapNhapId",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_NguoiDung_NguoiTaoId",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_NguoiDung_NguoiCapNhapId",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_NguoiDung_NguoiTaoId",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiTaoId",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LopNienChe_NguoiDung_NguoiCapNhapId",
                table: "LopNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LopNienChe_NguoiDung_NguoiTaoId",
                table: "LopNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_NguoiCapNhapId",
                table: "LyDoXinPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_NguoiTaoId",
                table: "LyDoXinPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_NguoiDung_NguoiTaoId",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_NguoiCapNhapId",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_NguoiTaoId",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_MucDoViPham_NguoiDung_NguoiCapNhapId",
                table: "MucDoViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_MucDoViPham_NguoiDung_NguoiTaoId",
                table: "MucDoViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_NguoiDung_NguoiCapNhapId",
                table: "NamHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_NguoiDung_NguoiTaoId",
                table: "NamHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_NguoiCapNhapId",
                table: "NamHoc_HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_NguoiTaoId",
                table: "NamHoc_HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_NguoiDung_NguoiCapNhapId",
                table: "NganhHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_NguoiDung_NguoiTaoId",
                table: "NganhHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_NguoiDung_IdNguoiCapNhap",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiTaoId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiTaoId",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiTaoId",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiDung_NguoiDung_NguoiCapNhapId",
                table: "NoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiDung_NguoiDung_NguoiTaoId",
                table: "NoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_NguoiCapNhapId",
                table: "PhanChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_NguoiTaoId",
                table: "PhanChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_NguoiCapNhapId",
                table: "PhanMonLopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_NguoiTaoId",
                table: "PhanMonLopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongHoc_NguoiDung_NguoiCapNhapId",
                table: "PhongHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongHoc_NguoiDung_NguoiTaoId",
                table: "PhongHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongXa_NguoiDung_NguoiCapNhapId",
                table: "PhuongXa");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongXa_NguoiDung_NguoiTaoId",
                table: "PhuongXa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyen_NguoiDung_NguoiCapNhapId",
                table: "QuanHuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyen_NguoiDung_NguoiTaoId",
                table: "QuanHuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_NguoiCapNhapId",
                table: "QuyChe_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_NguoiTaoId",
                table: "QuyChe_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_NguoiCapNhapId",
                table: "QuyChe_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_NguoiTaoId",
                table: "QuyChe_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_NguoiCapNhapId",
                table: "QuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_NguoiTaoId",
                table: "QuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_NguoiCapNhapId",
                table: "QuyChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_NguoiTaoId",
                table: "QuyChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinh_NguoiDung_NguoiCapNhapId",
                table: "QuyetDinh");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinh_NguoiDung_NguoiTaoId",
                table: "QuyetDinh");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_NguoiDung_NguoiCapNhapId",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_NguoiDung_NguoiTaoId",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiTaoId",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiCapNhapId",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiTaoId",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_NguoiCapNhapId",
                table: "SinhVienNganh2");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_NguoiTaoId",
                table: "SinhVienNganh2");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_NguoiCapNhapId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_NguoiTaoId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_NguoiCapNhapId",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_NguoiTaoId",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_NguoiCapNhapId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_NguoiTaoId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiTaoId",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiCapNhapId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiTaoId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiCapNhapId",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiTaoId",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiTaoId",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiCapNhapId",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiTaoId",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_NguoiCapNhapId",
                table: "TinhChatMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_NguoiTaoId",
                table: "TinhChatMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanh_NguoiDung_NguoiCapNhapId",
                table: "TinhThanh");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanh_NguoiDung_NguoiTaoId",
                table: "TinhThanh");

            migrationBuilder.DropForeignKey(
                name: "FK_ToBoMon_NguoiDung_NguoiCapNhapId",
                table: "ToBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_ToBoMon_NguoiDung_NguoiTaoId",
                table: "ToBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_NguoiCapNhapId",
                table: "TrangThaiLopHP");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_NguoiTaoId",
                table: "TrangThaiLopHP");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiTaoId",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiTaoId",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_XetLLHB_QuyCheTC_NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiXetQuyUoc_NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiLopHP_NguoiCapNhapId",
                table: "TrangThaiLopHP");

            migrationBuilder.DropIndex(
                name: "IX_ToBoMon_NguoiCapNhapId",
                table: "ToBoMon");

            migrationBuilder.DropIndex(
                name: "IX_TinhThanh_NguoiCapNhapId",
                table: "TinhThanh");

            migrationBuilder.DropIndex(
                name: "IX_TinhChatMonHoc_NguoiCapNhapId",
                table: "TinhChatMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_TieuChuanXetHocBong_NguoiCapNhapId",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropIndex(
                name: "IX_TieuChuanXetDanhHieu_NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropIndex(
                name: "IX_TieuChiTuyenSinh_NguoiCapNhapId",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanHoSoSv_NguoiCapNhapId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinChung_QuyCheTC_NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_ThongKeInBieuMau_NguoiCapNhapId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_ThoiKhoaBieu_NguoiCapNhapId",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_NguoiCapNhapId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienNganh2_NguoiCapNhapId",
                table: "SinhVienNganh2");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienMienMonHoc_NguoiCapNhapId",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienDangKiHocPhan_NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_NguoiCapNhapId",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_TC_NguoiCapNhapId",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_NC_NguoiCapNhapId",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_MonHoc_NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinh_NguoiCapNhapId",
                table: "QuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_QuyChuanDauRa_NguoiCapNhapId",
                table: "QuyChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_QuyCheHocVu_NguoiCapNhapId",
                table: "QuyCheHocVu");

            migrationBuilder.DropIndex(
                name: "IX_QuyChe_TinChi_NguoiCapNhapId",
                table: "QuyChe_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_QuyChe_NienChe_NguoiCapNhapId",
                table: "QuyChe_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_QuanHuyen_NguoiCapNhapId",
                table: "QuanHuyen");

            migrationBuilder.DropIndex(
                name: "IX_PhuongXa_NguoiCapNhapId",
                table: "PhuongXa");

            migrationBuilder.DropIndex(
                name: "IX_PhongHoc_NguoiCapNhapId",
                table: "PhongHoc");

            migrationBuilder.DropIndex(
                name: "IX_PhanMonLopHoc_NguoiCapNhapId",
                table: "PhanMonLopHoc");

            migrationBuilder.DropIndex(
                name: "IX_PhanChuyenNganh_NguoiCapNhapId",
                table: "PhanChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_NoiDung_NguoiCapNhapId",
                table: "NoiDung");

            migrationBuilder.DropIndex(
                name: "IX_NhomLoaiKhenThuong_NguoiCapNhapId",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_NhomLoaiHanhViViPham_NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropIndex(
                name: "IX_NganhHoc_NguoiCapNhapId",
                table: "NganhHoc");

            migrationBuilder.DropIndex(
                name: "IX_NamHoc_HocKy_NguoiCapNhapId",
                table: "NamHoc_HocKy");

            migrationBuilder.DropIndex(
                name: "IX_NamHoc_NguoiCapNhapId",
                table: "NamHoc");

            migrationBuilder.DropIndex(
                name: "IX_MucDoViPham_NguoiCapNhapId",
                table: "MucDoViPham");

            migrationBuilder.DropIndex(
                name: "IX_MonHocBacDaoTao_NguoiCapNhapId",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_NguoiCapNhapId",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LyDoXinPhong_NguoiCapNhapId",
                table: "LyDoXinPhong");

            migrationBuilder.DropIndex(
                name: "IX_LopNienChe_NguoiCapNhapId",
                table: "LopNienChe");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_LopDuKien_NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_NguoiCapNhapId",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHoc_NguoiCapNhapId",
                table: "LopHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiTiet_NguoiCapNhapId",
                table: "LoaiTiet");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSinhVien_NguoiCapNhapId",
                table: "LoaiSinhVien");

            migrationBuilder.DropIndex(
                name: "IX_LoaiPhong_NguoiCapNhapId",
                table: "LoaiPhong");

            migrationBuilder.DropIndex(
                name: "IX_LoaiMonHoc_NguoiCapNhapId",
                table: "LoaiMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiKhoanThu_NguoiCapNhapId",
                table: "LoaiKhoanThu");

            migrationBuilder.DropIndex(
                name: "IX_LoaiKhenThuong_NguoiCapNhapId",
                table: "LoaiKhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_LoaiHinhGiangDay_NguoiCapNhapId",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropIndex(
                name: "IX_LoaiHanhViViPham_NguoiCapNhapId",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_LoaiGiangVien_NguoiCapNhapId",
                table: "LoaiGiangVien");

            migrationBuilder.DropIndex(
                name: "IX_LoaiDaoTao_NguoiCapNhapId",
                table: "LoaiDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChungChi_NguoiCapNhapId",
                table: "LoaiChungChi");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChucVu_NguoiCapNhapId",
                table: "LoaiChucVu");

            migrationBuilder.DropIndex(
                name: "IX_LichHocThi_NguoiCapNhapId",
                table: "LichHocThi");

            migrationBuilder.DropIndex(
                name: "IX_KieuMonHoc_NguoiCapNhapId",
                table: "KieuMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_KieuLamTron_NguoiCapNhapId",
                table: "KieuLamTron");

            migrationBuilder.DropIndex(
                name: "IX_KhoiNganh_NguoiCapNhapId",
                table: "KhoiNganh");

            migrationBuilder.DropIndex(
                name: "IX_KhoiKienThuc_NguoiCapNhapId",
                table: "KhoiKienThuc");

            migrationBuilder.DropIndex(
                name: "IX_KhoaHoc_NguoiCapNhapId",
                table: "KhoaHoc");

            migrationBuilder.DropIndex(
                name: "IX_Khoa_NguoiCapNhapId",
                table: "Khoa");

            migrationBuilder.DropIndex(
                name: "IX_KhenThuong_NguoiCapNhapId",
                table: "KhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachDaoTao_TinChi_NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachDaoTao_NienChe_NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_HTXLViPhamQCThi_NguoiCapNhapId",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HoSoSV_NguoiCapNhapId",
                table: "HoSoSV");

            migrationBuilder.DropIndex(
                name: "IX_HocVi_NguoiCapNhapId",
                table: "HocVi");

            migrationBuilder.DropIndex(
                name: "IX_HocKy_NguoiCapNhapId",
                table: "HocKy");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucXuLyVPQCThi_NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_NguoiCapNhapId",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucDaoTao_NguoiCapNhapId",
                table: "HinhThucDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_HanhViViPham_NguoiCapNhapId",
                table: "HanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_GiangVien_NguoiCapNhapId",
                table: "GiangVien");

            migrationBuilder.DropIndex(
                name: "IX_DiaDiemPhong_NguoiCapNhapId",
                table: "DiaDiemPhong");

            migrationBuilder.DropIndex(
                name: "IX_DayNha_NguoiCapNhapId",
                table: "DayNha");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachSinhVienDuocInThe_NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachKhoaSuDung_NguoiCapNhapId",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTonGiao_NguoiCapNhapId",
                table: "DanhMucTonGiao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucQuocTich_NguoiCapNhapId",
                table: "DanhMucQuocTich");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhongBan_NguoiCapNhapId",
                table: "DanhMucPhongBan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNoiDung_NguoiCapNhapId",
                table: "DanhMucNoiDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_NguoiCapNhapId",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuTuDo_NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanChi_NguoiCapNhapId",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHocBong_NguoiCapNhapId",
                table: "DanhMucHocBong");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDoiTuongUuTien_NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDanToc_NguoiCapNhapId",
                table: "DanhMucDanToc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucCanSuLop_NguoiCapNhapId",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucBieuMau_NguoiCapNhapId",
                table: "DanhMucBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_DangKyMonHoc_NguoiCapNhapId",
                table: "DangKyMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_CoSoDaoTao_NguoiCapNhapId",
                table: "CoSoDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenTruong_NguoiCapNhapId",
                table: "ChuyenTruong");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenNganh_NguoiCapNhapId",
                table: "ChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenLop_NguoiCapNhapId",
                table: "ChuyenLop");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinhKhungTinChi_NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinhKhungNienChe_NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropIndex(
                name: "IX_ChungChi_NguoiCapNhapId",
                table: "ChungChi");

            migrationBuilder.DropIndex(
                name: "IX_ChuanDauRa_NguoiCapNhapId",
                table: "ChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_CaHoc_NguoiCapNhapId",
                table: "CaHoc");

            migrationBuilder.DropIndex(
                name: "IX_Bang_BangDiem_TN_NguoiCapNhapId",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropIndex(
                name: "IX_BacDaoTao_NguoiCapNhapId",
                table: "BacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_ApDungQuyCheHocVu_NguoiCapNhapId",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TrangThaiLopHP");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TrangThaiLopHP");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ToBoMon");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ToBoMon");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TinhThanh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TinhThanh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TinhChatMonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TinhChatMonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "SinhVienNganh2");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "SinhVienNganh2");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyetDinh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyetDinh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyChuanDauRa");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyChuanDauRa");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyCheHocVu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyCheHocVu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyChe_TinChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyChe_TinChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuyChe_NienChe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuyChe_NienChe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "QuanHuyen");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "QuanHuyen");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "PhuongXa");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "PhuongXa");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "PhongHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "PhongHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "PhanMonLopHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "PhanMonLopHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "PhanChuyenNganh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "PhanChuyenNganh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NoiDung");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NoiDung");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NganhHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NganhHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NamHoc_HocKy");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NamHoc_HocKy");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "NamHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "NamHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "MucDoViPham");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "MucDoViPham");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LyDoXinPhong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LyDoXinPhong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LopNienChe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LopNienChe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LopHocPhan");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LopHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LopHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiTiet");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiTiet");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiSinhVien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiSinhVien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiMonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiMonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiKhoanThu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiKhoanThu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiKhenThuong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiKhenThuong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiGiangVien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiGiangVien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiChungChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiChungChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LoaiChucVu");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "LichHocThi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "LichHocThi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KieuMonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KieuMonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KieuLamTron");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KieuLamTron");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KhoiNganh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KhoiNganh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KhoiKienThuc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KhoiKienThuc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KhoaHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KhoaHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "Khoa");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "Khoa");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KhenThuong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KhenThuong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HoSoSV");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HocVi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HocVi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HocKy");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HocKy");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HinhThucThi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HinhThucThi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HinhThucDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HinhThucDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "HanhViViPham");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "HanhViViPham");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "GiangVien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "GiangVien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DiaDiemPhong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DiaDiemPhong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DayNha");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DayNha");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucTonGiao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucTonGiao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucQuocTich");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucQuocTich");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucPhongBan");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucPhongBan");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucNoiDung");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucNoiDung");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucHocBong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucHocBong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucDanToc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucDanToc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DanhMucBieuMau");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DanhMucBieuMau");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "DangKyMonHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "DangKyMonHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "CoSoDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "CoSoDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuyenTruong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuyenTruong");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuyenNganh");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuyenLop");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuyenLop");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChungChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChungChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChuanDauRa");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChuanDauRa");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "CaHoc");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "CaHoc");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "BacDaoTao");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "BacDaoTao");

            migrationBuilder.DropColumn(
                name: "IdNguoiCapNhap",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhapId",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "XetLLHB_QuyCheTC",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_XetLLHB_QuyCheTC_NguoiTaoId",
                table: "XetLLHB_QuyCheTC",
                newName: "IX_XetLLHB_QuyCheTC_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TrangThaiXetQuyUoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TrangThaiXetQuyUoc_NguoiTaoId",
                table: "TrangThaiXetQuyUoc",
                newName: "IX_TrangThaiXetQuyUoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TrangThaiLopHP",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TrangThaiLopHP_NguoiTaoId",
                table: "TrangThaiLopHP",
                newName: "IX_TrangThaiLopHP_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ToBoMon",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ToBoMon_NguoiTaoId",
                table: "ToBoMon",
                newName: "IX_ToBoMon_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TinhThanh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TinhThanh_NguoiTaoId",
                table: "TinhThanh",
                newName: "IX_TinhThanh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TinhChatMonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TinhChatMonHoc_NguoiTaoId",
                table: "TinhChatMonHoc",
                newName: "IX_TinhChatMonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TieuChuanXetHocBong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChuanXetHocBong_NguoiTaoId",
                table: "TieuChuanXetHocBong",
                newName: "IX_TieuChuanXetHocBong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TieuChuanXetDanhHieu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChuanXetDanhHieu_NguoiTaoId",
                table: "TieuChuanXetDanhHieu",
                newName: "IX_TieuChuanXetDanhHieu_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TieuChiTuyenSinh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChiTuyenSinh_NguoiTaoId",
                table: "TieuChiTuyenSinh",
                newName: "IX_TieuChiTuyenSinh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "TiepNhanHoSoSv",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_TiepNhanHoSoSv_NguoiTaoId",
                table: "TiepNhanHoSoSv",
                newName: "IX_TiepNhanHoSoSv_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ThongTinChung_QuyCheTC",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinChung_QuyCheTC_NguoiTaoId",
                table: "ThongTinChung_QuyCheTC",
                newName: "IX_ThongTinChung_QuyCheTC_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ThongKeInBieuMau",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ThongKeInBieuMau_NguoiTaoId",
                table: "ThongKeInBieuMau",
                newName: "IX_ThongKeInBieuMau_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ThoiKhoaBieu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiKhoaBieu_NguoiTaoId",
                table: "ThoiKhoaBieu",
                newName: "IX_ThoiKhoaBieu_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ThoiGianDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_NguoiTaoId",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "SinhVienNganh2",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienNganh2_NguoiTaoId",
                table: "SinhVienNganh2",
                newName: "IX_SinhVienNganh2_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "SinhVienMienMonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienMienMonHoc_NguoiTaoId",
                table: "SinhVienMienMonHoc",
                newName: "IX_SinhVienMienMonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "SinhVienDangKiHocPhan",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienDangKiHocPhan_NguoiTaoId",
                table: "SinhVienDangKiHocPhan",
                newName: "IX_SinhVienDangKiHocPhan_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "SinhVien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_NguoiTaoId",
                table: "SinhVien",
                newName: "IX_SinhVien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyUocCotDiem_TC",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_TC_NguoiTaoId",
                table: "QuyUocCotDiem_TC",
                newName: "IX_QuyUocCotDiem_TC_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyUocCotDiem_NC",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_NC_NguoiTaoId",
                table: "QuyUocCotDiem_NC",
                newName: "IX_QuyUocCotDiem_NC_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyUocCotDiem_MonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_MonHoc_NguoiTaoId",
                table: "QuyUocCotDiem_MonHoc",
                newName: "IX_QuyUocCotDiem_MonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyetDinh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyetDinh_NguoiTaoId",
                table: "QuyetDinh",
                newName: "IX_QuyetDinh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyChuanDauRa",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChuanDauRa_NguoiTaoId",
                table: "QuyChuanDauRa",
                newName: "IX_QuyChuanDauRa_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyCheHocVu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyCheHocVu_NguoiTaoId",
                table: "QuyCheHocVu",
                newName: "IX_QuyCheHocVu_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyChe_TinChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChe_TinChi_NguoiTaoId",
                table: "QuyChe_TinChi",
                newName: "IX_QuyChe_TinChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuyChe_NienChe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChe_NienChe_NguoiTaoId",
                table: "QuyChe_NienChe",
                newName: "IX_QuyChe_NienChe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "QuanHuyen",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_QuanHuyen_NguoiTaoId",
                table: "QuanHuyen",
                newName: "IX_QuanHuyen_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "PhuongXa",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_PhuongXa_NguoiTaoId",
                table: "PhuongXa",
                newName: "IX_PhuongXa_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "PhongHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_PhongHoc_NguoiTaoId",
                table: "PhongHoc",
                newName: "IX_PhongHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "PhanMonLopHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_PhanMonLopHoc_NguoiTaoId",
                table: "PhanMonLopHoc",
                newName: "IX_PhanMonLopHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "PhanChuyenNganh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_PhanChuyenNganh_NguoiTaoId",
                table: "PhanChuyenNganh",
                newName: "IX_PhanChuyenNganh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NoiDung",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NoiDung_NguoiTaoId",
                table: "NoiDung",
                newName: "IX_NoiDung_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NhomLoaiKhenThuong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NhomLoaiKhenThuong_NguoiTaoId",
                table: "NhomLoaiKhenThuong",
                newName: "IX_NhomLoaiKhenThuong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NhomLoaiHanhViViPham",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NhomLoaiHanhViViPham_NguoiTaoId",
                table: "NhomLoaiHanhViViPham",
                newName: "IX_NhomLoaiHanhViViPham_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NhatKyCapNhatTrangThaiSv",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_NguoiTaoId",
                table: "NhatKyCapNhatTrangThaiSv",
                newName: "IX_NhatKyCapNhatTrangThaiSv_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhap",
                table: "NguoiDung",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDung_IdNguoiCapNhap",
                table: "NguoiDung",
                newName: "IX_NguoiDung_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NganhHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NganhHoc_NguoiTaoId",
                table: "NganhHoc",
                newName: "IX_NganhHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NamHoc_HocKy",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NamHoc_HocKy_NguoiTaoId",
                table: "NamHoc_HocKy",
                newName: "IX_NamHoc_HocKy_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "NamHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_NamHoc_NguoiTaoId",
                table: "NamHoc",
                newName: "IX_NamHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "MucDoViPham",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_MucDoViPham_NguoiTaoId",
                table: "MucDoViPham",
                newName: "IX_MucDoViPham_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "MonHocBacDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_MonHocBacDaoTao_NguoiTaoId",
                table: "MonHocBacDaoTao",
                newName: "IX_MonHocBacDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "MonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_MonHoc_NguoiTaoId",
                table: "MonHoc",
                newName: "IX_MonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LyDoXinPhong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LyDoXinPhong_NguoiTaoId",
                table: "LyDoXinPhong",
                newName: "IX_LyDoXinPhong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LopNienChe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LopNienChe_NguoiTaoId",
                table: "LopNienChe",
                newName: "IX_LopNienChe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LopHocPhan_LopDuKien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_LopDuKien_NguoiTaoId",
                table: "LopHocPhan_LopDuKien",
                newName: "IX_LopHocPhan_LopDuKien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LopHocPhan",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_NguoiTaoId",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LopHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LopHoc_NguoiTaoId",
                table: "LopHoc",
                newName: "IX_LopHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiTiet",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiTiet_NguoiTaoId",
                table: "LoaiTiet",
                newName: "IX_LoaiTiet_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiSinhVien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiSinhVien_NguoiTaoId",
                table: "LoaiSinhVien",
                newName: "IX_LoaiSinhVien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiPhong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiPhong_NguoiTaoId",
                table: "LoaiPhong",
                newName: "IX_LoaiPhong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiMonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiMonHoc_NguoiTaoId",
                table: "LoaiMonHoc",
                newName: "IX_LoaiMonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiKhoanThu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiKhoanThu_NguoiTaoId",
                table: "LoaiKhoanThu",
                newName: "IX_LoaiKhoanThu_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiKhenThuong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiKhenThuong_NguoiTaoId",
                table: "LoaiKhenThuong",
                newName: "IX_LoaiKhenThuong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiHinhGiangDay",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiHinhGiangDay_NguoiTaoId",
                table: "LoaiHinhGiangDay",
                newName: "IX_LoaiHinhGiangDay_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiHanhViViPham",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiHanhViViPham_NguoiTaoId",
                table: "LoaiHanhViViPham",
                newName: "IX_LoaiHanhViViPham_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiGiangVien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiGiangVien_NguoiTaoId",
                table: "LoaiGiangVien",
                newName: "IX_LoaiGiangVien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiDaoTao_NguoiTaoId",
                table: "LoaiDaoTao",
                newName: "IX_LoaiDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiChungChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiChungChi_NguoiTaoId",
                table: "LoaiChungChi",
                newName: "IX_LoaiChungChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LoaiChucVu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiChucVu_NguoiTaoId",
                table: "LoaiChucVu",
                newName: "IX_LoaiChucVu_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "LichHocThi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_LichHocThi_NguoiTaoId",
                table: "LichHocThi",
                newName: "IX_LichHocThi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KieuMonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KieuMonHoc_NguoiTaoId",
                table: "KieuMonHoc",
                newName: "IX_KieuMonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KieuLamTron",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KieuLamTron_NguoiTaoId",
                table: "KieuLamTron",
                newName: "IX_KieuLamTron_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KhoiNganh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KhoiNganh_NguoiTaoId",
                table: "KhoiNganh",
                newName: "IX_KhoiNganh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KhoiKienThuc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KhoiKienThuc_NguoiTaoId",
                table: "KhoiKienThuc",
                newName: "IX_KhoiKienThuc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KhoaHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KhoaHoc_NguoiTaoId",
                table: "KhoaHoc",
                newName: "IX_KhoaHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "Khoa",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_Khoa_NguoiTaoId",
                table: "Khoa",
                newName: "IX_Khoa_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KhenThuong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KhenThuong_NguoiTaoId",
                table: "KhenThuong",
                newName: "IX_KhenThuong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KeHoachDaoTao_TinChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KeHoachDaoTao_TinChi_NguoiTaoId",
                table: "KeHoachDaoTao_TinChi",
                newName: "IX_KeHoachDaoTao_TinChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "KeHoachDaoTao_NienChe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_KeHoachDaoTao_NienChe_NguoiTaoId",
                table: "KeHoachDaoTao_NienChe",
                newName: "IX_KeHoachDaoTao_NienChe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HTXLViPhamQCThi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HTXLViPhamQCThi_NguoiTaoId",
                table: "HTXLViPhamQCThi",
                newName: "IX_HTXLViPhamQCThi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HoSoSV",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HoSoSV_NguoiTaoId",
                table: "HoSoSV",
                newName: "IX_HoSoSV_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HocVi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HocVi_NguoiTaoId",
                table: "HocVi",
                newName: "IX_HocVi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HocKy",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HocKy_NguoiTaoId",
                table: "HocKy",
                newName: "IX_HocKy_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HinhThucXuLyVPQCThi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucXuLyVPQCThi_NguoiTaoId",
                table: "HinhThucXuLyVPQCThi",
                newName: "IX_HinhThucXuLyVPQCThi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HinhThucThi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucThi_NguoiTaoId",
                table: "HinhThucThi",
                newName: "IX_HinhThucThi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HinhThucDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucDaoTao_NguoiTaoId",
                table: "HinhThucDaoTao",
                newName: "IX_HinhThucDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "HanhViViPham",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_HanhViViPham_NguoiTaoId",
                table: "HanhViViPham",
                newName: "IX_HanhViViPham_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "GiangVien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_GiangVien_NguoiTaoId",
                table: "GiangVien",
                newName: "IX_GiangVien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DiaDiemPhong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DiaDiemPhong_NguoiTaoId",
                table: "DiaDiemPhong",
                newName: "IX_DiaDiemPhong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DayNha",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DayNha_NguoiTaoId",
                table: "DayNha",
                newName: "IX_DayNha_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhSachSinhVienDuocInThe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachSinhVienDuocInThe_NguoiTaoId",
                table: "DanhSachSinhVienDuocInThe",
                newName: "IX_DanhSachSinhVienDuocInThe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhSachKhoaSuDung",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachKhoaSuDung_NguoiTaoId",
                table: "DanhSachKhoaSuDung",
                newName: "IX_DanhSachKhoaSuDung_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucTonGiao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucTonGiao_NguoiTaoId",
                table: "DanhMucTonGiao",
                newName: "IX_DanhMucTonGiao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucQuocTich",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucQuocTich_NguoiTaoId",
                table: "DanhMucQuocTich",
                newName: "IX_DanhMucQuocTich_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucPhongBan",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhongBan_NguoiTaoId",
                table: "DanhMucPhongBan",
                newName: "IX_DanhMucPhongBan_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucNoiDung",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucNoiDung_NguoiTaoId",
                table: "DanhMucNoiDung",
                newName: "IX_DanhMucNoiDung_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucNganhDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucNganhDaoTao_NguoiTaoId",
                table: "DanhMucNganhDaoTao",
                newName: "IX_DanhMucNganhDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiTaoId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                newName: "IX_DanhMucLoaiThuPhi_MonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiTaoId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                newName: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_NguoiTaoId",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "IX_DanhMucLoaiHinhDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucKhungHoSoHSSV",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhungHoSoHSSV_NguoiTaoId",
                table: "DanhMucKhungHoSoHSSV",
                newName: "IX_DanhMucKhungHoSoHSSV_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucKhoanThuTuDo",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuTuDo_NguoiTaoId",
                table: "DanhMucKhoanThuTuDo",
                newName: "IX_DanhMucKhoanThuTuDo_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiTaoId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                newName: "IX_DanhMucKhoanThuNgoaiHocPhi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucKhoanThuHocPhi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuHocPhi_NguoiTaoId",
                table: "DanhMucKhoanThuHocPhi",
                newName: "IX_DanhMucKhoanThuHocPhi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucKhoanChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanChi_NguoiTaoId",
                table: "DanhMucKhoanChi",
                newName: "IX_DanhMucKhoanChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucHoSoHSSV",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucHoSoHSSV_NguoiTaoId",
                table: "DanhMucHoSoHSSV",
                newName: "IX_DanhMucHoSoHSSV_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucHocBong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucHocBong_NguoiTaoId",
                table: "DanhMucHocBong",
                newName: "IX_DanhMucHocBong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucDoiTuongUuTien",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucDoiTuongUuTien_NguoiTaoId",
                table: "DanhMucDoiTuongUuTien",
                newName: "IX_DanhMucDoiTuongUuTien_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucDanToc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucDanToc_NguoiTaoId",
                table: "DanhMucDanToc",
                newName: "IX_DanhMucDanToc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucCanSuLop",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucCanSuLop_NguoiTaoId",
                table: "DanhMucCanSuLop",
                newName: "IX_DanhMucCanSuLop_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DanhMucBieuMau",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucBieuMau_NguoiTaoId",
                table: "DanhMucBieuMau",
                newName: "IX_DanhMucBieuMau_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "DangKyMonHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_DangKyMonHoc_NguoiTaoId",
                table: "DangKyMonHoc",
                newName: "IX_DangKyMonHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "CoSoDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_CoSoDaoTao_NguoiTaoId",
                table: "CoSoDaoTao",
                newName: "IX_CoSoDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuyenTruong",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenTruong_NguoiTaoId",
                table: "ChuyenTruong",
                newName: "IX_ChuyenTruong_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuyenNganh",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenNganh_NguoiTaoId",
                table: "ChuyenNganh",
                newName: "IX_ChuyenNganh_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuyenLop",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenLop_NguoiTaoId",
                table: "ChuyenLop",
                newName: "IX_ChuyenLop_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuongTrinhKhungTinChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhKhungTinChi_NguoiTaoId",
                table: "ChuongTrinhKhungTinChi",
                newName: "IX_ChuongTrinhKhungTinChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuongTrinhKhungNienChe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhKhungNienChe_NguoiTaoId",
                table: "ChuongTrinhKhungNienChe",
                newName: "IX_ChuongTrinhKhungNienChe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChungChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChungChi_NguoiTaoId",
                table: "ChungChi",
                newName: "IX_ChungChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChuanDauRa",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChuanDauRa_NguoiTaoId",
                table: "ChuanDauRa",
                newName: "IX_ChuanDauRa_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_NguoiTaoId",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IX_ChiTietKhungHocKy_TinChi_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiTaoId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IX_ChiTietChuongTrinhKhung_NienChe_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "CaHoc",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_CaHoc_NguoiTaoId",
                table: "CaHoc",
                newName: "IX_CaHoc_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "Bang_BangDiem_TN",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_Bang_BangDiem_TN_NguoiTaoId",
                table: "Bang_BangDiem_TN",
                newName: "IX_Bang_BangDiem_TN_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "BacDaoTao",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_BacDaoTao_NguoiTaoId",
                table: "BacDaoTao",
                newName: "IX_BacDaoTao_IdNguoiCapNhat");

            migrationBuilder.RenameColumn(
                name: "NguoiTaoId",
                table: "ApDungQuyCheHocVu",
                newName: "IdNguoiCapNhat");

            migrationBuilder.RenameIndex(
                name: "IX_ApDungQuyCheHocVu_NguoiTaoId",
                table: "ApDungQuyCheHocVu",
                newName: "IX_ApDungQuyCheHocVu_IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_XetLLHB_QuyCheTC_IdNguoiTao",
                table: "XetLLHB_QuyCheTC",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiXetQuyUoc_IdNguoiTao",
                table: "TrangThaiXetQuyUoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiLopHP_IdNguoiTao",
                table: "TrangThaiLopHP",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ToBoMon_IdNguoiTao",
                table: "ToBoMon",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanh_IdNguoiTao",
                table: "TinhThanh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TinhChatMonHoc_IdNguoiTao",
                table: "TinhChatMonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetHocBong_IdNguoiTao",
                table: "TieuChuanXetHocBong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetDanhHieu_IdNguoiTao",
                table: "TieuChuanXetDanhHieu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiTuyenSinh_IdNguoiTao",
                table: "TieuChiTuyenSinh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiTao",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChung_QuyCheTC_IdNguoiTao",
                table: "ThongTinChung_QuyCheTC",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_IdNguoiTao",
                table: "ThongKeInBieuMau",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdNguoiTao",
                table: "ThoiKhoaBieu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdNguoiTao",
                table: "ThoiGianDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_IdNguoiTao",
                table: "SinhVienNganh2",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_IdNguoiTao",
                table: "SinhVienMienMonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiTao",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdNguoiTao",
                table: "SinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_IdNguoiTao",
                table: "QuyUocCotDiem_TC",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_IdNguoiTao",
                table: "QuyUocCotDiem_NC",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdNguoiTao",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_IdNguoiTao",
                table: "QuyetDinh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdNguoiTao",
                table: "QuyChuanDauRa",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyCheHocVu_IdNguoiTao",
                table: "QuyCheHocVu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_IdNguoiTao",
                table: "QuyChe_TinChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_NienChe_IdNguoiTao",
                table: "QuyChe_NienChe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_IdNguoiTao",
                table: "QuanHuyen",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_IdNguoiTao",
                table: "PhuongXa",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_IdNguoiTao",
                table: "PhongHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_IdNguoiTao",
                table: "PhanMonLopHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_IdNguoiTao",
                table: "PhanChuyenNganh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDung_IdNguoiTao",
                table: "NoiDung",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiKhenThuong_IdNguoiTao",
                table: "NhomLoaiKhenThuong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiHanhViViPham_IdNguoiTao",
                table: "NhomLoaiHanhViViPham",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdNguoiTao",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_IdNguoiTao",
                table: "NganhHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_HocKy_IdNguoiTao",
                table: "NamHoc_HocKy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_IdNguoiTao",
                table: "NamHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_MucDoViPham_IdNguoiTao",
                table: "MucDoViPham",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_IdNguoiTao",
                table: "MonHocBacDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdNguoiTao",
                table: "MonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LyDoXinPhong_IdNguoiTao",
                table: "LyDoXinPhong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_IdNguoiTao",
                table: "LopNienChe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_IdNguoiTao",
                table: "LopHocPhan_LopDuKien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_IdNguoiTao",
                table: "LopHocPhan",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_IdNguoiTao",
                table: "LopHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTiet_IdNguoiTao",
                table: "LoaiTiet",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSinhVien_IdNguoiTao",
                table: "LoaiSinhVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiPhong_IdNguoiTao",
                table: "LoaiPhong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiMonHoc_IdNguoiTao",
                table: "LoaiMonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhoanThu_IdNguoiTao",
                table: "LoaiKhoanThu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhenThuong_IdNguoiTao",
                table: "LoaiKhenThuong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHinhGiangDay_IdNguoiTao",
                table: "LoaiHinhGiangDay",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHanhViViPham_IdNguoiTao",
                table: "LoaiHanhViViPham",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiGiangVien_IdNguoiTao",
                table: "LoaiGiangVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_IdNguoiTao",
                table: "LoaiDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChungChi_IdNguoiTao",
                table: "LoaiChungChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_IdNguoiTao",
                table: "LoaiChucVu",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_IdNguoiTao",
                table: "LichHocThi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KieuMonHoc_IdNguoiTao",
                table: "KieuMonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KieuLamTron_IdNguoiTao",
                table: "KieuLamTron",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiNganh_IdNguoiTao",
                table: "KhoiNganh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiKienThuc_IdNguoiTao",
                table: "KhoiKienThuc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_IdNguoiTao",
                table: "KhoaHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_IdNguoiTao",
                table: "Khoa",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_IdNguoiTao",
                table: "KhenThuong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_IdNguoiTao",
                table: "KeHoachDaoTao_TinChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_IdNguoiTao",
                table: "KeHoachDaoTao_NienChe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HTXLViPhamQCThi_IdNguoiTao",
                table: "HTXLViPhamQCThi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoSV_IdNguoiTao",
                table: "HoSoSV",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HocVi_IdNguoiTao",
                table: "HocVi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_IdNguoiTao",
                table: "HocKy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_IdNguoiTao",
                table: "HinhThucXuLyVPQCThi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_IdNguoiTao",
                table: "HinhThucThi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucDaoTao_IdNguoiTao",
                table: "HinhThucDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_HanhViViPham_IdNguoiTao",
                table: "HanhViViPham",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_IdNguoiTao",
                table: "GiangVien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemPhong_IdNguoiTao",
                table: "DiaDiemPhong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DayNha_IdNguoiTao",
                table: "DayNha",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachSinhVienDuocInThe_IdNguoiTao",
                table: "DanhSachSinhVienDuocInThe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_IdNguoiTao",
                table: "DanhSachKhoaSuDung",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTonGiao_IdNguoiTao",
                table: "DanhMucTonGiao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucQuocTich_IdNguoiTao",
                table: "DanhMucQuocTich",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhongBan_IdNguoiTao",
                table: "DanhMucPhongBan",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_IdNguoiTao",
                table: "DanhMucNoiDung",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_IdNguoiTao",
                table: "DanhMucNganhDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_IdNguoiTao",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_IdNguoiTao",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNguoiTao",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdNguoiTao",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_IdNguoiTao",
                table: "DanhMucKhoanThuTuDo",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_IdNguoiTao",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_IdNguoiTao",
                table: "DanhMucKhoanThuHocPhi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_IdNguoiTao",
                table: "DanhMucKhoanChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_IdNguoiTao",
                table: "DanhMucHoSoHSSV",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHocBong_IdNguoiTao",
                table: "DanhMucHocBong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDoiTuongUuTien_IdNguoiTao",
                table: "DanhMucDoiTuongUuTien",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanToc_IdNguoiTao",
                table: "DanhMucDanToc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_IdNguoiTao",
                table: "DanhMucCanSuLop",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucBieuMau_IdNguoiTao",
                table: "DanhMucBieuMau",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_IdNguoiTao",
                table: "DangKyMonHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CoSoDaoTao_IdNguoiTao",
                table: "CoSoDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_IdNguoiTao",
                table: "ChuyenTruong",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_IdNguoiTao",
                table: "ChuyenNganh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_IdNguoiTao",
                table: "ChuyenLop",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdNguoiTao",
                table: "ChuongTrinhKhungTinChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdNguoiTao",
                table: "ChuongTrinhKhungNienChe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChi_IdNguoiTao",
                table: "ChungChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_IdNguoiTao",
                table: "ChuanDauRa",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdNguoiTao",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdNguoiTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CaHoc_IdNguoiTao",
                table: "CaHoc",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_IdNguoiTao",
                table: "Bang_BangDiem_TN",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_IdNguoiTao",
                table: "BacDaoTao",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_IdNguoiTao",
                table: "ApDungQuyCheHocVu",
                column: "IdNguoiTao");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_IdNguoiCapNhat",
                table: "ApDungQuyCheHocVu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_IdNguoiTao",
                table: "ApDungQuyCheHocVu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BacDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "BacDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BacDaoTao_NguoiDung_IdNguoiTao",
                table: "BacDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_IdNguoiCapNhat",
                table: "Bang_BangDiem_TN",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_IdNguoiTao",
                table: "Bang_BangDiem_TN",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaHoc_NguoiDung_IdNguoiCapNhat",
                table: "CaHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaHoc_NguoiDung_IdNguoiTao",
                table: "CaHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_IdNguoiTao",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_IdNguoiTao",
                table: "ChiTietKhungHocKy_TinChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_IdNguoiCapNhat",
                table: "ChuanDauRa",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_IdNguoiTao",
                table: "ChuanDauRa",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChi_NguoiDung_IdNguoiCapNhat",
                table: "ChungChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChi_NguoiDung_IdNguoiTao",
                table: "ChungChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_IdNguoiCapNhat",
                table: "ChuongTrinhKhungNienChe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_IdNguoiTao",
                table: "ChuongTrinhKhungNienChe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_IdNguoiCapNhat",
                table: "ChuongTrinhKhungTinChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_IdNguoiTao",
                table: "ChuongTrinhKhungTinChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenLop_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenLop",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenLop_NguoiDung_IdNguoiTao",
                table: "ChuyenLop",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenNganh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_IdNguoiTao",
                table: "ChuyenNganh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenTruong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_IdNguoiTao",
                table: "ChuyenTruong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "CoSoDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_IdNguoiTao",
                table: "CoSoDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "DangKyMonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_IdNguoiTao",
                table: "DangKyMonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucBieuMau",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_IdNguoiTao",
                table: "DanhMucBieuMau",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucCanSuLop",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_IdNguoiTao",
                table: "DanhMucCanSuLop",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucDanToc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_IdNguoiTao",
                table: "DanhMucDanToc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucDoiTuongUuTien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_IdNguoiTao",
                table: "DanhMucDoiTuongUuTien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucHocBong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_IdNguoiTao",
                table: "DanhMucHocBong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucHoSoHSSV",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_IdNguoiTao",
                table: "DanhMucHoSoHSSV",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuHocPhi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuHocPhi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuTuDo",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuTuDo",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_IdNguoiTao",
                table: "DanhMucKhungHoSoHSSV",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiHinhDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucNganhDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_IdNguoiTao",
                table: "DanhMucNganhDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucNoiDung",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_IdNguoiTao",
                table: "DanhMucNoiDung",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucPhongBan",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_IdNguoiTao",
                table: "DanhMucPhongBan",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucQuocTich",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_IdNguoiTao",
                table: "DanhMucQuocTich",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucTonGiao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_IdNguoiTao",
                table: "DanhMucTonGiao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_IdNguoiCapNhat",
                table: "DanhSachKhoaSuDung",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_IdNguoiTao",
                table: "DanhSachKhoaSuDung",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_IdNguoiCapNhat",
                table: "DanhSachSinhVienDuocInThe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_IdNguoiTao",
                table: "DanhSachSinhVienDuocInThe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayNha_NguoiDung_IdNguoiCapNhat",
                table: "DayNha",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayNha_NguoiDung_IdNguoiTao",
                table: "DayNha",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_IdNguoiCapNhat",
                table: "DiaDiemPhong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_IdNguoiTao",
                table: "DiaDiemPhong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_NguoiDung_IdNguoiCapNhat",
                table: "GiangVien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_NguoiDung_IdNguoiTao",
                table: "GiangVien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "HanhViViPham",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HanhViViPham_NguoiDung_IdNguoiTao",
                table: "HanhViViPham",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_IdNguoiTao",
                table: "HinhThucDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucThi_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucThi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucThi_NguoiDung_IdNguoiTao",
                table: "HinhThucThi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucXuLyVPQCThi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_IdNguoiTao",
                table: "HinhThucXuLyVPQCThi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocKy_NguoiDung_IdNguoiCapNhat",
                table: "HocKy",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocKy_NguoiDung_IdNguoiTao",
                table: "HocKy",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVi_NguoiDung_IdNguoiCapNhat",
                table: "HocVi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVi_NguoiDung_IdNguoiTao",
                table: "HocVi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoSV_NguoiDung_IdNguoiCapNhat",
                table: "HoSoSV",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoSV_NguoiDung_IdNguoiTao",
                table: "HoSoSV",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_IdNguoiCapNhat",
                table: "HTXLViPhamQCThi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_IdNguoiTao",
                table: "HTXLViPhamQCThi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "KeHoachDaoTao_NienChe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_IdNguoiTao",
                table: "KeHoachDaoTao_NienChe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "KeHoachDaoTao_TinChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_IdNguoiTao",
                table: "KeHoachDaoTao_TinChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "KhenThuong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhenThuong_NguoiDung_IdNguoiTao",
                table: "KhenThuong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_NguoiDung_IdNguoiCapNhat",
                table: "Khoa",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_NguoiDung_IdNguoiTao",
                table: "Khoa",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_NguoiDung_IdNguoiCapNhat",
                table: "KhoaHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_NguoiDung_IdNguoiTao",
                table: "KhoaHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_IdNguoiCapNhat",
                table: "KhoiKienThuc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_IdNguoiTao",
                table: "KhoiKienThuc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiNganh_NguoiDung_IdNguoiCapNhat",
                table: "KhoiNganh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiNganh_NguoiDung_IdNguoiTao",
                table: "KhoiNganh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuLamTron_NguoiDung_IdNguoiCapNhat",
                table: "KieuLamTron",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuLamTron_NguoiDung_IdNguoiTao",
                table: "KieuLamTron",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "KieuMonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_IdNguoiTao",
                table: "KieuMonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichHocThi_NguoiDung_IdNguoiCapNhat",
                table: "LichHocThi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichHocThi_NguoiDung_IdNguoiTao",
                table: "LichHocThi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_IdNguoiCapNhat",
                table: "LoaiChucVu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_IdNguoiTao",
                table: "LoaiChucVu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_IdNguoiCapNhat",
                table: "LoaiChungChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_IdNguoiTao",
                table: "LoaiChungChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "LoaiDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_IdNguoiTao",
                table: "LoaiDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_IdNguoiCapNhat",
                table: "LoaiGiangVien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_IdNguoiTao",
                table: "LoaiGiangVien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "LoaiHanhViViPham",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_IdNguoiTao",
                table: "LoaiHanhViViPham",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_IdNguoiCapNhat",
                table: "LoaiHinhGiangDay",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_IdNguoiTao",
                table: "LoaiHinhGiangDay",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "LoaiKhenThuong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_IdNguoiTao",
                table: "LoaiKhenThuong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_IdNguoiCapNhat",
                table: "LoaiKhoanThu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_IdNguoiTao",
                table: "LoaiKhoanThu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "LoaiMonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_IdNguoiTao",
                table: "LoaiMonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiPhong_NguoiDung_IdNguoiCapNhat",
                table: "LoaiPhong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiPhong_NguoiDung_IdNguoiTao",
                table: "LoaiPhong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_IdNguoiCapNhat",
                table: "LoaiSinhVien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_IdNguoiTao",
                table: "LoaiSinhVien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiTiet_NguoiDung_IdNguoiCapNhat",
                table: "LoaiTiet",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiTiet_NguoiDung_IdNguoiTao",
                table: "LoaiTiet",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_NguoiDung_IdNguoiCapNhat",
                table: "LopHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_NguoiDung_IdNguoiTao",
                table: "LopHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_NguoiDung_IdNguoiCapNhat",
                table: "LopHocPhan",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_NguoiDung_IdNguoiTao",
                table: "LopHocPhan",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_IdNguoiCapNhat",
                table: "LopHocPhan_LopDuKien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_IdNguoiTao",
                table: "LopHocPhan_LopDuKien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopNienChe_NguoiDung_IdNguoiCapNhat",
                table: "LopNienChe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopNienChe_NguoiDung_IdNguoiTao",
                table: "LopNienChe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_IdNguoiCapNhat",
                table: "LyDoXinPhong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_IdNguoiTao",
                table: "LyDoXinPhong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "MonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_NguoiDung_IdNguoiTao",
                table: "MonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "MonHocBacDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_IdNguoiTao",
                table: "MonHocBacDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MucDoViPham_NguoiDung_IdNguoiCapNhat",
                table: "MucDoViPham",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MucDoViPham_NguoiDung_IdNguoiTao",
                table: "MucDoViPham",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_NguoiDung_IdNguoiCapNhat",
                table: "NamHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_NguoiDung_IdNguoiTao",
                table: "NamHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_IdNguoiCapNhat",
                table: "NamHoc_HocKy",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_IdNguoiTao",
                table: "NamHoc_HocKy",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_NguoiDung_IdNguoiCapNhat",
                table: "NganhHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_NguoiDung_IdNguoiTao",
                table: "NganhHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_NguoiDung_IdNguoiCapNhat",
                table: "NguoiDung",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_IdNguoiCapNhat",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_IdNguoiTao",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "NhomLoaiHanhViViPham",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_IdNguoiTao",
                table: "NhomLoaiHanhViViPham",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "NhomLoaiKhenThuong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_IdNguoiTao",
                table: "NhomLoaiKhenThuong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoiDung_NguoiDung_IdNguoiCapNhat",
                table: "NoiDung",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoiDung_NguoiDung_IdNguoiTao",
                table: "NoiDung",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_IdNguoiCapNhat",
                table: "PhanChuyenNganh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_IdNguoiTao",
                table: "PhanChuyenNganh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_IdNguoiCapNhat",
                table: "PhanMonLopHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_IdNguoiTao",
                table: "PhanMonLopHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhongHoc_NguoiDung_IdNguoiCapNhat",
                table: "PhongHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhongHoc_NguoiDung_IdNguoiTao",
                table: "PhongHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongXa_NguoiDung_IdNguoiCapNhat",
                table: "PhuongXa",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongXa_NguoiDung_IdNguoiTao",
                table: "PhuongXa",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanHuyen_NguoiDung_IdNguoiCapNhat",
                table: "QuanHuyen",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanHuyen_NguoiDung_IdNguoiTao",
                table: "QuanHuyen",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "QuyChe_NienChe",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_IdNguoiTao",
                table: "QuyChe_NienChe",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "QuyChe_TinChi",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_IdNguoiTao",
                table: "QuyChe_TinChi",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_IdNguoiCapNhat",
                table: "QuyCheHocVu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_IdNguoiTao",
                table: "QuyCheHocVu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_IdNguoiCapNhat",
                table: "QuyChuanDauRa",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_IdNguoiTao",
                table: "QuyChuanDauRa",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinh_NguoiDung_IdNguoiCapNhat",
                table: "QuyetDinh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinh_NguoiDung_IdNguoiTao",
                table: "QuyetDinh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_MonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_NC",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_NC",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_TC",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_TC",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_NguoiDung_IdNguoiCapNhat",
                table: "SinhVien",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_NguoiDung_IdNguoiTao",
                table: "SinhVien",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiTao",
                table: "SinhVienDangKiHocPhan",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienMienMonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_IdNguoiTao",
                table: "SinhVienMienMonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienNganh2",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiTao",
                table: "SinhVienNganh2",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "ThoiGianDaoTao",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_IdNguoiTao",
                table: "ThoiGianDaoTao",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_IdNguoiCapNhat",
                table: "ThoiKhoaBieu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_IdNguoiTao",
                table: "ThoiKhoaBieu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_IdNguoiCapNhat",
                table: "ThongKeInBieuMau",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_IdNguoiTao",
                table: "ThongKeInBieuMau",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_IdNguoiCapNhat",
                table: "ThongTinChung_QuyCheTC",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_IdNguoiTao",
                table: "ThongTinChung_QuyCheTC",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiCapNhat",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiTao",
                table: "TiepNhanHoSoSv",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_IdNguoiCapNhat",
                table: "TieuChiTuyenSinh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_IdNguoiTao",
                table: "TieuChiTuyenSinh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_IdNguoiCapNhat",
                table: "TieuChuanXetDanhHieu",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_IdNguoiTao",
                table: "TieuChuanXetDanhHieu",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_IdNguoiCapNhat",
                table: "TieuChuanXetHocBong",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_IdNguoiTao",
                table: "TieuChuanXetHocBong",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "TinhChatMonHoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_IdNguoiTao",
                table: "TinhChatMonHoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhThanh_NguoiDung_IdNguoiCapNhat",
                table: "TinhThanh",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhThanh_NguoiDung_IdNguoiTao",
                table: "TinhThanh",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToBoMon_NguoiDung_IdNguoiCapNhat",
                table: "ToBoMon",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToBoMon_NguoiDung_IdNguoiTao",
                table: "ToBoMon",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_IdNguoiCapNhat",
                table: "TrangThaiLopHP",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_IdNguoiTao",
                table: "TrangThaiLopHP",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_IdNguoiCapNhat",
                table: "TrangThaiXetQuyUoc",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_IdNguoiTao",
                table: "TrangThaiXetQuyUoc",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_IdNguoiCapNhat",
                table: "XetLLHB_QuyCheTC",
                column: "IdNguoiCapNhat",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_IdNguoiTao",
                table: "XetLLHB_QuyCheTC",
                column: "IdNguoiTao",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS ""vw_ChuongTrinhKhung_Merged"";

                CREATE VIEW ""vw_ChuongTrinhKhung_Merged"" AS
                SELECT
                    t.""Id"",
                    t.""MaChuongTrinh"",
                    t.""TenChuongTrinh"",
                    t.""IsBlock"",
                    t.""GhiChu"",
                    t.""GhiChuTiengAnh"",
                    t.""IdCoSoDaoTao"",
                    t.""IdKhoaHoc"",
                    t.""IdLoaiDaoTao"",
                    t.""IdNganhHoc"",
                    t.""IdBacDaoTao"",
                    t.""IdChuyenNganh"",
                    false AS ""IsNienChe"",
                    t.""IdNguoiCapNhap"",
                    t.""IdNguoiTao"",
                    t.""NguoiCapNhapId"",
                    t.""NguoiTaoId"",
                    t.""IsDeleted"",
                    t.""NgayCapNhat"",
                    t.""NgayTao""
                FROM public.""ChuongTrinhKhungTinChi"" t

                UNION ALL

                SELECT
                    n.""Id"",
                    n.""MaChuongTrinh"",
                    n.""TenChuongTrinh"",
                    n.""IsBlock"",
                    n.""GhiChu"",
                    n.""GhiChuTiengAnh"",
                    n.""IdCoSoDaoTao"",
                    n.""IdKhoaHoc"",
                    n.""IdLoaiDaoTao"",
                    n.""IdNganhHoc"",
                    n.""IdBacDaoTao"",
                    n.""IdChuyenNganh"",
                    true AS ""IsNienChe"",
                    n.""IdNguoiCapNhap"",
                    n.""IdNguoiTao"",
                    n.""NguoiCapNhapId"",
                    n.""NguoiTaoId"",
                    n.""IsDeleted"",
                    n.""NgayCapNhat"",
                    n.""NgayTao""
                FROM public.""ChuongTrinhKhungNienChe"" n;
            ");
            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_IdNguoiCapNhat",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_IdNguoiTao",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_BacDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "BacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_BacDaoTao_NguoiDung_IdNguoiTao",
                table: "BacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_IdNguoiCapNhat",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_IdNguoiTao",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropForeignKey(
                name: "FK_CaHoc_NguoiDung_IdNguoiCapNhat",
                table: "CaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaHoc_NguoiDung_IdNguoiTao",
                table: "CaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_IdNguoiTao",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_IdNguoiTao",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_IdNguoiCapNhat",
                table: "ChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_IdNguoiTao",
                table: "ChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_ChungChi_NguoiDung_IdNguoiCapNhat",
                table: "ChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChungChi_NguoiDung_IdNguoiTao",
                table: "ChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_IdNguoiCapNhat",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_IdNguoiTao",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_IdNguoiCapNhat",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_IdNguoiTao",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenLop_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenLop");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenLop_NguoiDung_IdNguoiTao",
                table: "ChuyenLop");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_IdNguoiTao",
                table: "ChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_IdNguoiCapNhat",
                table: "ChuyenTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_IdNguoiTao",
                table: "ChuyenTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "CoSoDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_IdNguoiTao",
                table: "CoSoDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "DangKyMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_IdNguoiTao",
                table: "DangKyMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_IdNguoiTao",
                table: "DanhMucBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_IdNguoiTao",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucDanToc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_IdNguoiTao",
                table: "DanhMucDanToc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_IdNguoiTao",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_IdNguoiTao",
                table: "DanhMucHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_IdNguoiTao",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_IdNguoiTao",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_IdNguoiTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_IdNguoiTao",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_IdNguoiTao",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucNoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_IdNguoiTao",
                table: "DanhMucNoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucPhongBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_IdNguoiTao",
                table: "DanhMucPhongBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucQuocTich");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_IdNguoiTao",
                table: "DanhMucQuocTich");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_IdNguoiCapNhat",
                table: "DanhMucTonGiao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_IdNguoiTao",
                table: "DanhMucTonGiao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_IdNguoiCapNhat",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_IdNguoiTao",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_IdNguoiCapNhat",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_IdNguoiTao",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropForeignKey(
                name: "FK_DayNha_NguoiDung_IdNguoiCapNhat",
                table: "DayNha");

            migrationBuilder.DropForeignKey(
                name: "FK_DayNha_NguoiDung_IdNguoiTao",
                table: "DayNha");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_IdNguoiCapNhat",
                table: "DiaDiemPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_IdNguoiTao",
                table: "DiaDiemPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_NguoiDung_IdNguoiCapNhat",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_NguoiDung_IdNguoiTao",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_HanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "HanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_HanhViViPham_NguoiDung_IdNguoiTao",
                table: "HanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_IdNguoiTao",
                table: "HinhThucDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucThi_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucThi_NguoiDung_IdNguoiTao",
                table: "HinhThucThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_IdNguoiCapNhat",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_IdNguoiTao",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocKy_NguoiDung_IdNguoiCapNhat",
                table: "HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_HocKy_NguoiDung_IdNguoiTao",
                table: "HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVi_NguoiDung_IdNguoiCapNhat",
                table: "HocVi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVi_NguoiDung_IdNguoiTao",
                table: "HocVi");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSoSV_NguoiDung_IdNguoiCapNhat",
                table: "HoSoSV");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSoSV_NguoiDung_IdNguoiTao",
                table: "HoSoSV");

            migrationBuilder.DropForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_IdNguoiCapNhat",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_IdNguoiTao",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_IdNguoiTao",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_IdNguoiTao",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_KhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "KhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_KhenThuong_NguoiDung_IdNguoiTao",
                table: "KhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_NguoiDung_IdNguoiCapNhat",
                table: "Khoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_NguoiDung_IdNguoiTao",
                table: "Khoa");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_NguoiDung_IdNguoiCapNhat",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_NguoiDung_IdNguoiTao",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_IdNguoiCapNhat",
                table: "KhoiKienThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_IdNguoiTao",
                table: "KhoiKienThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiNganh_NguoiDung_IdNguoiCapNhat",
                table: "KhoiNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoiNganh_NguoiDung_IdNguoiTao",
                table: "KhoiNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuLamTron_NguoiDung_IdNguoiCapNhat",
                table: "KieuLamTron");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuLamTron_NguoiDung_IdNguoiTao",
                table: "KieuLamTron");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "KieuMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_IdNguoiTao",
                table: "KieuMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LichHocThi_NguoiDung_IdNguoiCapNhat",
                table: "LichHocThi");

            migrationBuilder.DropForeignKey(
                name: "FK_LichHocThi_NguoiDung_IdNguoiTao",
                table: "LichHocThi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_IdNguoiCapNhat",
                table: "LoaiChucVu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_IdNguoiTao",
                table: "LoaiChucVu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_IdNguoiCapNhat",
                table: "LoaiChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_IdNguoiTao",
                table: "LoaiChungChi");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "LoaiDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_IdNguoiTao",
                table: "LoaiDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_IdNguoiCapNhat",
                table: "LoaiGiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_IdNguoiTao",
                table: "LoaiGiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_IdNguoiTao",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_IdNguoiCapNhat",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_IdNguoiTao",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "LoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_IdNguoiTao",
                table: "LoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_IdNguoiCapNhat",
                table: "LoaiKhoanThu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_IdNguoiTao",
                table: "LoaiKhoanThu");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "LoaiMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_IdNguoiTao",
                table: "LoaiMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiPhong_NguoiDung_IdNguoiCapNhat",
                table: "LoaiPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiPhong_NguoiDung_IdNguoiTao",
                table: "LoaiPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_IdNguoiCapNhat",
                table: "LoaiSinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_IdNguoiTao",
                table: "LoaiSinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiTiet_NguoiDung_IdNguoiCapNhat",
                table: "LoaiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiTiet_NguoiDung_IdNguoiTao",
                table: "LoaiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_NguoiDung_IdNguoiCapNhat",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_NguoiDung_IdNguoiTao",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_NguoiDung_IdNguoiCapNhat",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_NguoiDung_IdNguoiTao",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_IdNguoiCapNhat",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_IdNguoiTao",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LopNienChe_NguoiDung_IdNguoiCapNhat",
                table: "LopNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LopNienChe_NguoiDung_IdNguoiTao",
                table: "LopNienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_IdNguoiCapNhat",
                table: "LyDoXinPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_IdNguoiTao",
                table: "LyDoXinPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_NguoiDung_IdNguoiTao",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_IdNguoiTao",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_MucDoViPham_NguoiDung_IdNguoiCapNhat",
                table: "MucDoViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_MucDoViPham_NguoiDung_IdNguoiTao",
                table: "MucDoViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_NguoiDung_IdNguoiCapNhat",
                table: "NamHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_NguoiDung_IdNguoiTao",
                table: "NamHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_IdNguoiCapNhat",
                table: "NamHoc_HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_IdNguoiTao",
                table: "NamHoc_HocKy");

            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_NguoiDung_IdNguoiCapNhat",
                table: "NganhHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NganhHoc_NguoiDung_IdNguoiTao",
                table: "NganhHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_NguoiDung_IdNguoiCapNhat",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_IdNguoiCapNhat",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_IdNguoiTao",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_IdNguoiCapNhat",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_IdNguoiTao",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_IdNguoiCapNhat",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_IdNguoiTao",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiDung_NguoiDung_IdNguoiCapNhat",
                table: "NoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiDung_NguoiDung_IdNguoiTao",
                table: "NoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_IdNguoiCapNhat",
                table: "PhanChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_IdNguoiTao",
                table: "PhanChuyenNganh");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_IdNguoiCapNhat",
                table: "PhanMonLopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_IdNguoiTao",
                table: "PhanMonLopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongHoc_NguoiDung_IdNguoiCapNhat",
                table: "PhongHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongHoc_NguoiDung_IdNguoiTao",
                table: "PhongHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongXa_NguoiDung_IdNguoiCapNhat",
                table: "PhuongXa");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongXa_NguoiDung_IdNguoiTao",
                table: "PhuongXa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyen_NguoiDung_IdNguoiCapNhat",
                table: "QuanHuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyen_NguoiDung_IdNguoiTao",
                table: "QuanHuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_IdNguoiCapNhat",
                table: "QuyChe_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_IdNguoiTao",
                table: "QuyChe_NienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_IdNguoiCapNhat",
                table: "QuyChe_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_IdNguoiTao",
                table: "QuyChe_TinChi");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_IdNguoiCapNhat",
                table: "QuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_IdNguoiTao",
                table: "QuyCheHocVu");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_IdNguoiCapNhat",
                table: "QuyChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_IdNguoiTao",
                table: "QuyChuanDauRa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinh_NguoiDung_IdNguoiCapNhat",
                table: "QuyetDinh");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinh_NguoiDung_IdNguoiTao",
                table: "QuyetDinh");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_IdNguoiCapNhat",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_IdNguoiTao",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_NguoiDung_IdNguoiCapNhat",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_NguoiDung_IdNguoiTao",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_IdNguoiTao",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_IdNguoiTao",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiCapNhat",
                table: "SinhVienNganh2");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_IdNguoiTao",
                table: "SinhVienNganh2");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_IdNguoiCapNhat",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_IdNguoiTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_IdNguoiCapNhat",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_IdNguoiTao",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_IdNguoiCapNhat",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_IdNguoiTao",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_IdNguoiCapNhat",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_IdNguoiTao",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiCapNhat",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_IdNguoiTao",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_IdNguoiCapNhat",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_IdNguoiTao",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_IdNguoiCapNhat",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_IdNguoiTao",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_IdNguoiCapNhat",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_IdNguoiTao",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_IdNguoiCapNhat",
                table: "TinhChatMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_IdNguoiTao",
                table: "TinhChatMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanh_NguoiDung_IdNguoiCapNhat",
                table: "TinhThanh");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanh_NguoiDung_IdNguoiTao",
                table: "TinhThanh");

            migrationBuilder.DropForeignKey(
                name: "FK_ToBoMon_NguoiDung_IdNguoiCapNhat",
                table: "ToBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_ToBoMon_NguoiDung_IdNguoiTao",
                table: "ToBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_IdNguoiCapNhat",
                table: "TrangThaiLopHP");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_IdNguoiTao",
                table: "TrangThaiLopHP");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_IdNguoiCapNhat",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_IdNguoiTao",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_IdNguoiCapNhat",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_IdNguoiTao",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_XetLLHB_QuyCheTC_IdNguoiTao",
                table: "XetLLHB_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiXetQuyUoc_IdNguoiTao",
                table: "TrangThaiXetQuyUoc");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiLopHP_IdNguoiTao",
                table: "TrangThaiLopHP");

            migrationBuilder.DropIndex(
                name: "IX_ToBoMon_IdNguoiTao",
                table: "ToBoMon");

            migrationBuilder.DropIndex(
                name: "IX_TinhThanh_IdNguoiTao",
                table: "TinhThanh");

            migrationBuilder.DropIndex(
                name: "IX_TinhChatMonHoc_IdNguoiTao",
                table: "TinhChatMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_TieuChuanXetHocBong_IdNguoiTao",
                table: "TieuChuanXetHocBong");

            migrationBuilder.DropIndex(
                name: "IX_TieuChuanXetDanhHieu_IdNguoiTao",
                table: "TieuChuanXetDanhHieu");

            migrationBuilder.DropIndex(
                name: "IX_TieuChiTuyenSinh_IdNguoiTao",
                table: "TieuChiTuyenSinh");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiTao",
                table: "TiepNhanHoSoSv");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinChung_QuyCheTC_IdNguoiTao",
                table: "ThongTinChung_QuyCheTC");

            migrationBuilder.DropIndex(
                name: "IX_ThongKeInBieuMau_IdNguoiTao",
                table: "ThongKeInBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_ThoiKhoaBieu_IdNguoiTao",
                table: "ThoiKhoaBieu");

            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_IdNguoiTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienNganh2_IdNguoiTao",
                table: "SinhVienNganh2");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienMienMonHoc_IdNguoiTao",
                table: "SinhVienMienMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiTao",
                table: "SinhVienDangKiHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_IdNguoiTao",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_TC_IdNguoiTao",
                table: "QuyUocCotDiem_TC");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_NC_IdNguoiTao",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdNguoiTao",
                table: "QuyUocCotDiem_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinh_IdNguoiTao",
                table: "QuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_QuyChuanDauRa_IdNguoiTao",
                table: "QuyChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_QuyCheHocVu_IdNguoiTao",
                table: "QuyCheHocVu");

            migrationBuilder.DropIndex(
                name: "IX_QuyChe_TinChi_IdNguoiTao",
                table: "QuyChe_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_QuyChe_NienChe_IdNguoiTao",
                table: "QuyChe_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_QuanHuyen_IdNguoiTao",
                table: "QuanHuyen");

            migrationBuilder.DropIndex(
                name: "IX_PhuongXa_IdNguoiTao",
                table: "PhuongXa");

            migrationBuilder.DropIndex(
                name: "IX_PhongHoc_IdNguoiTao",
                table: "PhongHoc");

            migrationBuilder.DropIndex(
                name: "IX_PhanMonLopHoc_IdNguoiTao",
                table: "PhanMonLopHoc");

            migrationBuilder.DropIndex(
                name: "IX_PhanChuyenNganh_IdNguoiTao",
                table: "PhanChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_NoiDung_IdNguoiTao",
                table: "NoiDung");

            migrationBuilder.DropIndex(
                name: "IX_NhomLoaiKhenThuong_IdNguoiTao",
                table: "NhomLoaiKhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_NhomLoaiHanhViViPham_IdNguoiTao",
                table: "NhomLoaiHanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdNguoiTao",
                table: "NhatKyCapNhatTrangThaiSv");

            migrationBuilder.DropIndex(
                name: "IX_NganhHoc_IdNguoiTao",
                table: "NganhHoc");

            migrationBuilder.DropIndex(
                name: "IX_NamHoc_HocKy_IdNguoiTao",
                table: "NamHoc_HocKy");

            migrationBuilder.DropIndex(
                name: "IX_NamHoc_IdNguoiTao",
                table: "NamHoc");

            migrationBuilder.DropIndex(
                name: "IX_MucDoViPham_IdNguoiTao",
                table: "MucDoViPham");

            migrationBuilder.DropIndex(
                name: "IX_MonHocBacDaoTao_IdNguoiTao",
                table: "MonHocBacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_IdNguoiTao",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LyDoXinPhong_IdNguoiTao",
                table: "LyDoXinPhong");

            migrationBuilder.DropIndex(
                name: "IX_LopNienChe_IdNguoiTao",
                table: "LopNienChe");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_LopDuKien_IdNguoiTao",
                table: "LopHocPhan_LopDuKien");

            migrationBuilder.DropIndex(
                name: "IX_LopHocPhan_IdNguoiTao",
                table: "LopHocPhan");

            migrationBuilder.DropIndex(
                name: "IX_LopHoc_IdNguoiTao",
                table: "LopHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiTiet_IdNguoiTao",
                table: "LoaiTiet");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSinhVien_IdNguoiTao",
                table: "LoaiSinhVien");

            migrationBuilder.DropIndex(
                name: "IX_LoaiPhong_IdNguoiTao",
                table: "LoaiPhong");

            migrationBuilder.DropIndex(
                name: "IX_LoaiMonHoc_IdNguoiTao",
                table: "LoaiMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiKhoanThu_IdNguoiTao",
                table: "LoaiKhoanThu");

            migrationBuilder.DropIndex(
                name: "IX_LoaiKhenThuong_IdNguoiTao",
                table: "LoaiKhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_LoaiHinhGiangDay_IdNguoiTao",
                table: "LoaiHinhGiangDay");

            migrationBuilder.DropIndex(
                name: "IX_LoaiHanhViViPham_IdNguoiTao",
                table: "LoaiHanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_LoaiGiangVien_IdNguoiTao",
                table: "LoaiGiangVien");

            migrationBuilder.DropIndex(
                name: "IX_LoaiDaoTao_IdNguoiTao",
                table: "LoaiDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChungChi_IdNguoiTao",
                table: "LoaiChungChi");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChucVu_IdNguoiTao",
                table: "LoaiChucVu");

            migrationBuilder.DropIndex(
                name: "IX_LichHocThi_IdNguoiTao",
                table: "LichHocThi");

            migrationBuilder.DropIndex(
                name: "IX_KieuMonHoc_IdNguoiTao",
                table: "KieuMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_KieuLamTron_IdNguoiTao",
                table: "KieuLamTron");

            migrationBuilder.DropIndex(
                name: "IX_KhoiNganh_IdNguoiTao",
                table: "KhoiNganh");

            migrationBuilder.DropIndex(
                name: "IX_KhoiKienThuc_IdNguoiTao",
                table: "KhoiKienThuc");

            migrationBuilder.DropIndex(
                name: "IX_KhoaHoc_IdNguoiTao",
                table: "KhoaHoc");

            migrationBuilder.DropIndex(
                name: "IX_Khoa_IdNguoiTao",
                table: "Khoa");

            migrationBuilder.DropIndex(
                name: "IX_KhenThuong_IdNguoiTao",
                table: "KhenThuong");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachDaoTao_TinChi_IdNguoiTao",
                table: "KeHoachDaoTao_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachDaoTao_NienChe_IdNguoiTao",
                table: "KeHoachDaoTao_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_HTXLViPhamQCThi_IdNguoiTao",
                table: "HTXLViPhamQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HoSoSV_IdNguoiTao",
                table: "HoSoSV");

            migrationBuilder.DropIndex(
                name: "IX_HocVi_IdNguoiTao",
                table: "HocVi");

            migrationBuilder.DropIndex(
                name: "IX_HocKy_IdNguoiTao",
                table: "HocKy");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucXuLyVPQCThi_IdNguoiTao",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_IdNguoiTao",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucDaoTao_IdNguoiTao",
                table: "HinhThucDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_HanhViViPham_IdNguoiTao",
                table: "HanhViViPham");

            migrationBuilder.DropIndex(
                name: "IX_GiangVien_IdNguoiTao",
                table: "GiangVien");

            migrationBuilder.DropIndex(
                name: "IX_DiaDiemPhong_IdNguoiTao",
                table: "DiaDiemPhong");

            migrationBuilder.DropIndex(
                name: "IX_DayNha_IdNguoiTao",
                table: "DayNha");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachSinhVienDuocInThe_IdNguoiTao",
                table: "DanhSachSinhVienDuocInThe");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachKhoaSuDung_IdNguoiTao",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTonGiao_IdNguoiTao",
                table: "DanhMucTonGiao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucQuocTich_IdNguoiTao",
                table: "DanhMucQuocTich");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhongBan_IdNguoiTao",
                table: "DanhMucPhongBan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNoiDung_IdNguoiTao",
                table: "DanhMucNoiDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_IdNguoiTao",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_IdNguoiTao",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_IdNguoiTao",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNguoiTao",
                table: "DanhMucLoaiHinhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdNguoiTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuTuDo_IdNguoiTao",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_IdNguoiTao",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuHocPhi_IdNguoiTao",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanChi_IdNguoiTao",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHoSoHSSV_IdNguoiTao",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHocBong_IdNguoiTao",
                table: "DanhMucHocBong");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDoiTuongUuTien_IdNguoiTao",
                table: "DanhMucDoiTuongUuTien");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDanToc_IdNguoiTao",
                table: "DanhMucDanToc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucCanSuLop_IdNguoiTao",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucBieuMau_IdNguoiTao",
                table: "DanhMucBieuMau");

            migrationBuilder.DropIndex(
                name: "IX_DangKyMonHoc_IdNguoiTao",
                table: "DangKyMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_CoSoDaoTao_IdNguoiTao",
                table: "CoSoDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenTruong_IdNguoiTao",
                table: "ChuyenTruong");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenNganh_IdNguoiTao",
                table: "ChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenLop_IdNguoiTao",
                table: "ChuyenLop");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdNguoiTao",
                table: "ChuongTrinhKhungTinChi");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdNguoiTao",
                table: "ChuongTrinhKhungNienChe");

            migrationBuilder.DropIndex(
                name: "IX_ChungChi_IdNguoiTao",
                table: "ChungChi");

            migrationBuilder.DropIndex(
                name: "IX_ChuanDauRa_IdNguoiTao",
                table: "ChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdNguoiTao",
                table: "ChiTietKhungHocKy_TinChi");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdNguoiTao",
                table: "ChiTietChuongTrinhKhung_NienChe");

            migrationBuilder.DropIndex(
                name: "IX_CaHoc_IdNguoiTao",
                table: "CaHoc");

            migrationBuilder.DropIndex(
                name: "IX_Bang_BangDiem_TN_IdNguoiTao",
                table: "Bang_BangDiem_TN");

            migrationBuilder.DropIndex(
                name: "IX_BacDaoTao_IdNguoiTao",
                table: "BacDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_ApDungQuyCheHocVu_IdNguoiTao",
                table: "ApDungQuyCheHocVu");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "XetLLHB_QuyCheTC",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_XetLLHB_QuyCheTC_IdNguoiCapNhat",
                table: "XetLLHB_QuyCheTC",
                newName: "IX_XetLLHB_QuyCheTC_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TrangThaiXetQuyUoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TrangThaiXetQuyUoc_IdNguoiCapNhat",
                table: "TrangThaiXetQuyUoc",
                newName: "IX_TrangThaiXetQuyUoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TrangThaiLopHP",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TrangThaiLopHP_IdNguoiCapNhat",
                table: "TrangThaiLopHP",
                newName: "IX_TrangThaiLopHP_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ToBoMon",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ToBoMon_IdNguoiCapNhat",
                table: "ToBoMon",
                newName: "IX_ToBoMon_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TinhThanh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TinhThanh_IdNguoiCapNhat",
                table: "TinhThanh",
                newName: "IX_TinhThanh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TinhChatMonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TinhChatMonHoc_IdNguoiCapNhat",
                table: "TinhChatMonHoc",
                newName: "IX_TinhChatMonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TieuChuanXetHocBong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChuanXetHocBong_IdNguoiCapNhat",
                table: "TieuChuanXetHocBong",
                newName: "IX_TieuChuanXetHocBong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TieuChuanXetDanhHieu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChuanXetDanhHieu_IdNguoiCapNhat",
                table: "TieuChuanXetDanhHieu",
                newName: "IX_TieuChuanXetDanhHieu_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TieuChiTuyenSinh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TieuChiTuyenSinh_IdNguoiCapNhat",
                table: "TieuChiTuyenSinh",
                newName: "IX_TieuChiTuyenSinh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "TiepNhanHoSoSv",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TiepNhanHoSoSv_IdNguoiCapNhat",
                table: "TiepNhanHoSoSv",
                newName: "IX_TiepNhanHoSoSv_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ThongTinChung_QuyCheTC",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinChung_QuyCheTC_IdNguoiCapNhat",
                table: "ThongTinChung_QuyCheTC",
                newName: "IX_ThongTinChung_QuyCheTC_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ThongKeInBieuMau",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongKeInBieuMau_IdNguoiCapNhat",
                table: "ThongKeInBieuMau",
                newName: "IX_ThongKeInBieuMau_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ThoiKhoaBieu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiKhoaBieu_IdNguoiCapNhat",
                table: "ThoiKhoaBieu",
                newName: "IX_ThoiKhoaBieu_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ThoiGianDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ThoiGianDaoTao_IdNguoiCapNhat",
                table: "ThoiGianDaoTao",
                newName: "IX_ThoiGianDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "SinhVienNganh2",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienNganh2_IdNguoiCapNhat",
                table: "SinhVienNganh2",
                newName: "IX_SinhVienNganh2_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "SinhVienMienMonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienMienMonHoc_IdNguoiCapNhat",
                table: "SinhVienMienMonHoc",
                newName: "IX_SinhVienMienMonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "SinhVienDangKiHocPhan",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienDangKiHocPhan_IdNguoiCapNhat",
                table: "SinhVienDangKiHocPhan",
                newName: "IX_SinhVienDangKiHocPhan_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "SinhVien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_IdNguoiCapNhat",
                table: "SinhVien",
                newName: "IX_SinhVien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyUocCotDiem_TC",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_TC_IdNguoiCapNhat",
                table: "QuyUocCotDiem_TC",
                newName: "IX_QuyUocCotDiem_TC_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyUocCotDiem_NC",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_NC_IdNguoiCapNhat",
                table: "QuyUocCotDiem_NC",
                newName: "IX_QuyUocCotDiem_NC_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyUocCotDiem_MonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyUocCotDiem_MonHoc_IdNguoiCapNhat",
                table: "QuyUocCotDiem_MonHoc",
                newName: "IX_QuyUocCotDiem_MonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyetDinh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyetDinh_IdNguoiCapNhat",
                table: "QuyetDinh",
                newName: "IX_QuyetDinh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyChuanDauRa",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChuanDauRa_IdNguoiCapNhat",
                table: "QuyChuanDauRa",
                newName: "IX_QuyChuanDauRa_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyCheHocVu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyCheHocVu_IdNguoiCapNhat",
                table: "QuyCheHocVu",
                newName: "IX_QuyCheHocVu_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyChe_TinChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChe_TinChi_IdNguoiCapNhat",
                table: "QuyChe_TinChi",
                newName: "IX_QuyChe_TinChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuyChe_NienChe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuyChe_NienChe_IdNguoiCapNhat",
                table: "QuyChe_NienChe",
                newName: "IX_QuyChe_NienChe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "QuanHuyen",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_QuanHuyen_IdNguoiCapNhat",
                table: "QuanHuyen",
                newName: "IX_QuanHuyen_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "PhuongXa",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhuongXa_IdNguoiCapNhat",
                table: "PhuongXa",
                newName: "IX_PhuongXa_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "PhongHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhongHoc_IdNguoiCapNhat",
                table: "PhongHoc",
                newName: "IX_PhongHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "PhanMonLopHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhanMonLopHoc_IdNguoiCapNhat",
                table: "PhanMonLopHoc",
                newName: "IX_PhanMonLopHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "PhanChuyenNganh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhanChuyenNganh_IdNguoiCapNhat",
                table: "PhanChuyenNganh",
                newName: "IX_PhanChuyenNganh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NoiDung",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NoiDung_IdNguoiCapNhat",
                table: "NoiDung",
                newName: "IX_NoiDung_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NhomLoaiKhenThuong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NhomLoaiKhenThuong_IdNguoiCapNhat",
                table: "NhomLoaiKhenThuong",
                newName: "IX_NhomLoaiKhenThuong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NhomLoaiHanhViViPham",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NhomLoaiHanhViViPham_IdNguoiCapNhat",
                table: "NhomLoaiHanhViViPham",
                newName: "IX_NhomLoaiHanhViViPham_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NhatKyCapNhatTrangThaiSv",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_IdNguoiCapNhat",
                table: "NhatKyCapNhatTrangThaiSv",
                newName: "IX_NhatKyCapNhatTrangThaiSv_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NguoiDung",
                newName: "IdNguoiCapNhap");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDung_IdNguoiCapNhat",
                table: "NguoiDung",
                newName: "IX_NguoiDung_IdNguoiCapNhap");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NganhHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NganhHoc_IdNguoiCapNhat",
                table: "NganhHoc",
                newName: "IX_NganhHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NamHoc_HocKy",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NamHoc_HocKy_IdNguoiCapNhat",
                table: "NamHoc_HocKy",
                newName: "IX_NamHoc_HocKy_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "NamHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_NamHoc_IdNguoiCapNhat",
                table: "NamHoc",
                newName: "IX_NamHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "MucDoViPham",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_MucDoViPham_IdNguoiCapNhat",
                table: "MucDoViPham",
                newName: "IX_MucDoViPham_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "MonHocBacDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_MonHocBacDaoTao_IdNguoiCapNhat",
                table: "MonHocBacDaoTao",
                newName: "IX_MonHocBacDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "MonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_MonHoc_IdNguoiCapNhat",
                table: "MonHoc",
                newName: "IX_MonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LyDoXinPhong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LyDoXinPhong_IdNguoiCapNhat",
                table: "LyDoXinPhong",
                newName: "IX_LyDoXinPhong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LopNienChe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LopNienChe_IdNguoiCapNhat",
                table: "LopNienChe",
                newName: "IX_LopNienChe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LopHocPhan_LopDuKien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_LopDuKien_IdNguoiCapNhat",
                table: "LopHocPhan_LopDuKien",
                newName: "IX_LopHocPhan_LopDuKien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LopHocPhan",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_IdNguoiCapNhat",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LopHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LopHoc_IdNguoiCapNhat",
                table: "LopHoc",
                newName: "IX_LopHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiTiet",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiTiet_IdNguoiCapNhat",
                table: "LoaiTiet",
                newName: "IX_LoaiTiet_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiSinhVien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiSinhVien_IdNguoiCapNhat",
                table: "LoaiSinhVien",
                newName: "IX_LoaiSinhVien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiPhong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiPhong_IdNguoiCapNhat",
                table: "LoaiPhong",
                newName: "IX_LoaiPhong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiMonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiMonHoc_IdNguoiCapNhat",
                table: "LoaiMonHoc",
                newName: "IX_LoaiMonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiKhoanThu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiKhoanThu_IdNguoiCapNhat",
                table: "LoaiKhoanThu",
                newName: "IX_LoaiKhoanThu_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiKhenThuong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiKhenThuong_IdNguoiCapNhat",
                table: "LoaiKhenThuong",
                newName: "IX_LoaiKhenThuong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiHinhGiangDay",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiHinhGiangDay_IdNguoiCapNhat",
                table: "LoaiHinhGiangDay",
                newName: "IX_LoaiHinhGiangDay_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiHanhViViPham",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiHanhViViPham_IdNguoiCapNhat",
                table: "LoaiHanhViViPham",
                newName: "IX_LoaiHanhViViPham_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiGiangVien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiGiangVien_IdNguoiCapNhat",
                table: "LoaiGiangVien",
                newName: "IX_LoaiGiangVien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiDaoTao_IdNguoiCapNhat",
                table: "LoaiDaoTao",
                newName: "IX_LoaiDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiChungChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiChungChi_IdNguoiCapNhat",
                table: "LoaiChungChi",
                newName: "IX_LoaiChungChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LoaiChucVu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LoaiChucVu_IdNguoiCapNhat",
                table: "LoaiChucVu",
                newName: "IX_LoaiChucVu_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "LichHocThi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_LichHocThi_IdNguoiCapNhat",
                table: "LichHocThi",
                newName: "IX_LichHocThi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KieuMonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KieuMonHoc_IdNguoiCapNhat",
                table: "KieuMonHoc",
                newName: "IX_KieuMonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KieuLamTron",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KieuLamTron_IdNguoiCapNhat",
                table: "KieuLamTron",
                newName: "IX_KieuLamTron_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KhoiNganh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KhoiNganh_IdNguoiCapNhat",
                table: "KhoiNganh",
                newName: "IX_KhoiNganh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KhoiKienThuc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KhoiKienThuc_IdNguoiCapNhat",
                table: "KhoiKienThuc",
                newName: "IX_KhoiKienThuc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KhoaHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KhoaHoc_IdNguoiCapNhat",
                table: "KhoaHoc",
                newName: "IX_KhoaHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "Khoa",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Khoa_IdNguoiCapNhat",
                table: "Khoa",
                newName: "IX_Khoa_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KhenThuong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KhenThuong_IdNguoiCapNhat",
                table: "KhenThuong",
                newName: "IX_KhenThuong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KeHoachDaoTao_TinChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KeHoachDaoTao_TinChi_IdNguoiCapNhat",
                table: "KeHoachDaoTao_TinChi",
                newName: "IX_KeHoachDaoTao_TinChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "KeHoachDaoTao_NienChe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_KeHoachDaoTao_NienChe_IdNguoiCapNhat",
                table: "KeHoachDaoTao_NienChe",
                newName: "IX_KeHoachDaoTao_NienChe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HTXLViPhamQCThi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HTXLViPhamQCThi_IdNguoiCapNhat",
                table: "HTXLViPhamQCThi",
                newName: "IX_HTXLViPhamQCThi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HoSoSV",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HoSoSV_IdNguoiCapNhat",
                table: "HoSoSV",
                newName: "IX_HoSoSV_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HocVi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HocVi_IdNguoiCapNhat",
                table: "HocVi",
                newName: "IX_HocVi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HocKy",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HocKy_IdNguoiCapNhat",
                table: "HocKy",
                newName: "IX_HocKy_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HinhThucXuLyVPQCThi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucXuLyVPQCThi_IdNguoiCapNhat",
                table: "HinhThucXuLyVPQCThi",
                newName: "IX_HinhThucXuLyVPQCThi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HinhThucThi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucThi_IdNguoiCapNhat",
                table: "HinhThucThi",
                newName: "IX_HinhThucThi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HinhThucDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HinhThucDaoTao_IdNguoiCapNhat",
                table: "HinhThucDaoTao",
                newName: "IX_HinhThucDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "HanhViViPham",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HanhViViPham_IdNguoiCapNhat",
                table: "HanhViViPham",
                newName: "IX_HanhViViPham_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "GiangVien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_GiangVien_IdNguoiCapNhat",
                table: "GiangVien",
                newName: "IX_GiangVien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DiaDiemPhong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DiaDiemPhong_IdNguoiCapNhat",
                table: "DiaDiemPhong",
                newName: "IX_DiaDiemPhong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DayNha",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DayNha_IdNguoiCapNhat",
                table: "DayNha",
                newName: "IX_DayNha_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhSachSinhVienDuocInThe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachSinhVienDuocInThe_IdNguoiCapNhat",
                table: "DanhSachSinhVienDuocInThe",
                newName: "IX_DanhSachSinhVienDuocInThe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhSachKhoaSuDung",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachKhoaSuDung_IdNguoiCapNhat",
                table: "DanhSachKhoaSuDung",
                newName: "IX_DanhSachKhoaSuDung_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucTonGiao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucTonGiao_IdNguoiCapNhat",
                table: "DanhMucTonGiao",
                newName: "IX_DanhMucTonGiao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucQuocTich",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucQuocTich_IdNguoiCapNhat",
                table: "DanhMucQuocTich",
                newName: "IX_DanhMucQuocTich_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucPhongBan",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhongBan_IdNguoiCapNhat",
                table: "DanhMucPhongBan",
                newName: "IX_DanhMucPhongBan_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucNoiDung",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucNoiDung_IdNguoiCapNhat",
                table: "DanhMucNoiDung",
                newName: "IX_DanhMucNoiDung_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucNganhDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucNganhDaoTao_IdNguoiCapNhat",
                table: "DanhMucNganhDaoTao",
                newName: "IX_DanhMucNganhDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucLoaiThuPhi_MonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_IdNguoiCapNhat",
                table: "DanhMucLoaiThuPhi_MonHoc",
                newName: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_IdNguoiCapNhat",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                newName: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_IdNguoiCapNhat",
                table: "DanhMucLoaiHinhDaoTao",
                newName: "IX_DanhMucLoaiHinhDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucKhungHoSoHSSV",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdNguoiCapNhat",
                table: "DanhMucKhungHoSoHSSV",
                newName: "IX_DanhMucKhungHoSoHSSV_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucKhoanThuTuDo",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuTuDo_IdNguoiCapNhat",
                table: "DanhMucKhoanThuTuDo",
                newName: "IX_DanhMucKhoanThuTuDo_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_IdNguoiCapNhat",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                newName: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucKhoanThuHocPhi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanThuHocPhi_IdNguoiCapNhat",
                table: "DanhMucKhoanThuHocPhi",
                newName: "IX_DanhMucKhoanThuHocPhi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucKhoanChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucKhoanChi_IdNguoiCapNhat",
                table: "DanhMucKhoanChi",
                newName: "IX_DanhMucKhoanChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucHoSoHSSV",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucHoSoHSSV_IdNguoiCapNhat",
                table: "DanhMucHoSoHSSV",
                newName: "IX_DanhMucHoSoHSSV_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucHocBong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucHocBong_IdNguoiCapNhat",
                table: "DanhMucHocBong",
                newName: "IX_DanhMucHocBong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucDoiTuongUuTien",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucDoiTuongUuTien_IdNguoiCapNhat",
                table: "DanhMucDoiTuongUuTien",
                newName: "IX_DanhMucDoiTuongUuTien_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucDanToc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucDanToc_IdNguoiCapNhat",
                table: "DanhMucDanToc",
                newName: "IX_DanhMucDanToc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucCanSuLop",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucCanSuLop_IdNguoiCapNhat",
                table: "DanhMucCanSuLop",
                newName: "IX_DanhMucCanSuLop_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DanhMucBieuMau",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucBieuMau_IdNguoiCapNhat",
                table: "DanhMucBieuMau",
                newName: "IX_DanhMucBieuMau_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "DangKyMonHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DangKyMonHoc_IdNguoiCapNhat",
                table: "DangKyMonHoc",
                newName: "IX_DangKyMonHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "CoSoDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_CoSoDaoTao_IdNguoiCapNhat",
                table: "CoSoDaoTao",
                newName: "IX_CoSoDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuyenTruong",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenTruong_IdNguoiCapNhat",
                table: "ChuyenTruong",
                newName: "IX_ChuyenTruong_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuyenNganh",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenNganh_IdNguoiCapNhat",
                table: "ChuyenNganh",
                newName: "IX_ChuyenNganh_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuyenLop",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuyenLop_IdNguoiCapNhat",
                table: "ChuyenLop",
                newName: "IX_ChuyenLop_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuongTrinhKhungTinChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhKhungTinChi_IdNguoiCapNhat",
                table: "ChuongTrinhKhungTinChi",
                newName: "IX_ChuongTrinhKhungTinChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuongTrinhKhungNienChe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhKhungNienChe_IdNguoiCapNhat",
                table: "ChuongTrinhKhungNienChe",
                newName: "IX_ChuongTrinhKhungNienChe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChungChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChungChi_IdNguoiCapNhat",
                table: "ChungChi",
                newName: "IX_ChungChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChuanDauRa",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChuanDauRa_IdNguoiCapNhat",
                table: "ChuanDauRa",
                newName: "IX_ChuanDauRa_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_IdNguoiCapNhat",
                table: "ChiTietKhungHocKy_TinChi",
                newName: "IX_ChiTietKhungHocKy_TinChi_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_IdNguoiCapNhat",
                table: "ChiTietChuongTrinhKhung_NienChe",
                newName: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "CaHoc",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_CaHoc_IdNguoiCapNhat",
                table: "CaHoc",
                newName: "IX_CaHoc_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "Bang_BangDiem_TN",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Bang_BangDiem_TN_IdNguoiCapNhat",
                table: "Bang_BangDiem_TN",
                newName: "IX_Bang_BangDiem_TN_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "BacDaoTao",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_BacDaoTao_IdNguoiCapNhat",
                table: "BacDaoTao",
                newName: "IX_BacDaoTao_NguoiTaoId");

            migrationBuilder.RenameColumn(
                name: "IdNguoiCapNhat",
                table: "ApDungQuyCheHocVu",
                newName: "NguoiTaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ApDungQuyCheHocVu_IdNguoiCapNhat",
                table: "ApDungQuyCheHocVu",
                newName: "IX_ApDungQuyCheHocVu_NguoiTaoId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "XetLLHB_QuyCheTC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TrangThaiXetQuyUoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TrangThaiLopHP",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TrangThaiLopHP",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ToBoMon",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ToBoMon",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TinhThanh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TinhThanh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TinhChatMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TinhChatMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TieuChuanXetHocBong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TieuChuanXetHocBong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TieuChuanXetDanhHieu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TieuChiTuyenSinh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TieuChiTuyenSinh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "TiepNhanHoSoSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ThongTinChung_QuyCheTC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ThongKeInBieuMau",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ThongKeInBieuMau",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ThoiKhoaBieu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ThoiKhoaBieu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ThoiGianDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ThoiGianDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "SinhVienNganh2",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "SinhVienMienMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "SinhVienMienMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "SinhVienDangKiHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "SinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_TC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_TC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_NC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_NC",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyUocCotDiem_MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyetDinh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyetDinh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyChuanDauRa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyChuanDauRa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyCheHocVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyCheHocVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyChe_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyChe_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuyChe_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuyChe_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "QuanHuyen",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "QuanHuyen",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "PhuongXa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "PhuongXa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "PhongHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "PhongHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "PhanMonLopHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "PhanMonLopHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "PhanChuyenNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "PhanChuyenNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NoiDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NoiDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NhomLoaiKhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NhomLoaiKhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NhomLoaiHanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NhatKyCapNhatTrangThaiSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NganhHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NganhHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NamHoc_HocKy",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NamHoc_HocKy",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "NamHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "NamHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "MucDoViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "MucDoViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "MonHocBacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "MonHocBacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LyDoXinPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LyDoXinPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LopNienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LopNienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LopHocPhan_LopDuKien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LopHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LopHocPhan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LopHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LopHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiTiet",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiTiet",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiSinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiSinhVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiKhoanThu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiKhoanThu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiKhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiKhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiHinhGiangDay",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiHinhGiangDay",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiHanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiHanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiGiangVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiGiangVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiChungChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiChungChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LoaiChucVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LoaiChucVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "LichHocThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "LichHocThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KieuMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KieuMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KieuLamTron",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KieuLamTron",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KhoiNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KhoiNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KhoiKienThuc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KhoiKienThuc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KhoaHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KhoaHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "Khoa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "Khoa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KhenThuong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KeHoachDaoTao_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "KeHoachDaoTao_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HTXLViPhamQCThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HTXLViPhamQCThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HoSoSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HoSoSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HocVi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HocVi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HocKy",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HocKy",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HinhThucXuLyVPQCThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HinhThucThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HinhThucThi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HinhThucDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HinhThucDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "HanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "HanhViViPham",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "GiangVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "GiangVien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DiaDiemPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DiaDiemPhong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DayNha",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DayNha",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhSachSinhVienDuocInThe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhSachKhoaSuDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhSachKhoaSuDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucTonGiao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucTonGiao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucQuocTich",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucQuocTich",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucPhongBan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucPhongBan",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucNoiDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucNoiDung",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucNganhDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucNganhDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiThuPhi_MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucLoaiHinhDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhungHoSoHSSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuTuDo",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanThuHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucKhoanChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucKhoanChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucHoSoHSSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucHoSoHSSV",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucHocBong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucHocBong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucDoiTuongUuTien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucDanToc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucDanToc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucCanSuLop",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucCanSuLop",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DanhMucBieuMau",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DanhMucBieuMau",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "DangKyMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "DangKyMonHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "CoSoDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "CoSoDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuyenTruong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuyenTruong",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuyenNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuyenNganh",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuyenLop",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuyenLop",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuongTrinhKhungTinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuongTrinhKhungNienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChungChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChungChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChuanDauRa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChuanDauRa",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChiTietKhungHocKy_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ChiTietChuongTrinhKhung_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "CaHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "CaHoc",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "Bang_BangDiem_TN",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "Bang_BangDiem_TN",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "BacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "BacDaoTao",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdNguoiCapNhap",
                table: "ApDungQuyCheHocVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiCapNhapId",
                table: "ApDungQuyCheHocVu",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_XetLLHB_QuyCheTC_NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiXetQuyUoc_NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiLopHP_NguoiCapNhapId",
                table: "TrangThaiLopHP",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ToBoMon_NguoiCapNhapId",
                table: "ToBoMon",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanh_NguoiCapNhapId",
                table: "TinhThanh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhChatMonHoc_NguoiCapNhapId",
                table: "TinhChatMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetHocBong_NguoiCapNhapId",
                table: "TieuChuanXetHocBong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanXetDanhHieu_NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiTuyenSinh_NguoiCapNhapId",
                table: "TieuChiTuyenSinh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanHoSoSv_NguoiCapNhapId",
                table: "TiepNhanHoSoSv",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinChung_QuyCheTC_NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeInBieuMau_NguoiCapNhapId",
                table: "ThongKeInBieuMau",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_NguoiCapNhapId",
                table: "ThoiKhoaBieu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_NguoiCapNhapId",
                table: "ThoiGianDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienNganh2_NguoiCapNhapId",
                table: "SinhVienNganh2",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienMienMonHoc_NguoiCapNhapId",
                table: "SinhVienMienMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienDangKiHocPhan_NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_NguoiCapNhapId",
                table: "SinhVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_TC_NguoiCapNhapId",
                table: "QuyUocCotDiem_TC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_NC_NguoiCapNhapId",
                table: "QuyUocCotDiem_NC",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyUocCotDiem_MonHoc_NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_NguoiCapNhapId",
                table: "QuyetDinh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_NguoiCapNhapId",
                table: "QuyChuanDauRa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyCheHocVu_NguoiCapNhapId",
                table: "QuyCheHocVu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_TinChi_NguoiCapNhapId",
                table: "QuyChe_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyChe_NienChe_NguoiCapNhapId",
                table: "QuyChe_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_NguoiCapNhapId",
                table: "QuanHuyen",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_NguoiCapNhapId",
                table: "PhuongXa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongHoc_NguoiCapNhapId",
                table: "PhongHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanMonLopHoc_NguoiCapNhapId",
                table: "PhanMonLopHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanChuyenNganh_NguoiCapNhapId",
                table: "PhanChuyenNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDung_NguoiCapNhapId",
                table: "NoiDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiKhenThuong_NguoiCapNhapId",
                table: "NhomLoaiKhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhomLoaiHanhViViPham_NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyCapNhatTrangThaiSv_NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHoc_NguoiCapNhapId",
                table: "NganhHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_HocKy_NguoiCapNhapId",
                table: "NamHoc_HocKy",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHoc_NguoiCapNhapId",
                table: "NamHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MucDoViPham_NguoiCapNhapId",
                table: "MucDoViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocBacDaoTao_NguoiCapNhapId",
                table: "MonHocBacDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_NguoiCapNhapId",
                table: "MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LyDoXinPhong_NguoiCapNhapId",
                table: "LyDoXinPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopNienChe_NguoiCapNhapId",
                table: "LopNienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_NguoiCapNhapId",
                table: "LopHocPhan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_NguoiCapNhapId",
                table: "LopHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTiet_NguoiCapNhapId",
                table: "LoaiTiet",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSinhVien_NguoiCapNhapId",
                table: "LoaiSinhVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiPhong_NguoiCapNhapId",
                table: "LoaiPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiMonHoc_NguoiCapNhapId",
                table: "LoaiMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhoanThu_NguoiCapNhapId",
                table: "LoaiKhoanThu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiKhenThuong_NguoiCapNhapId",
                table: "LoaiKhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHinhGiangDay_NguoiCapNhapId",
                table: "LoaiHinhGiangDay",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHanhViViPham_NguoiCapNhapId",
                table: "LoaiHanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiGiangVien_NguoiCapNhapId",
                table: "LoaiGiangVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDaoTao_NguoiCapNhapId",
                table: "LoaiDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChungChi_NguoiCapNhapId",
                table: "LoaiChungChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_NguoiCapNhapId",
                table: "LoaiChucVu",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocThi_NguoiCapNhapId",
                table: "LichHocThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuMonHoc_NguoiCapNhapId",
                table: "KieuMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KieuLamTron_NguoiCapNhapId",
                table: "KieuLamTron",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiNganh_NguoiCapNhapId",
                table: "KhoiNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoiKienThuc_NguoiCapNhapId",
                table: "KhoiKienThuc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_NguoiCapNhapId",
                table: "KhoaHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_NguoiCapNhapId",
                table: "Khoa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_NguoiCapNhapId",
                table: "KhenThuong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_TinChi_NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachDaoTao_NienChe_NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HTXLViPhamQCThi_NguoiCapNhapId",
                table: "HTXLViPhamQCThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoSV_NguoiCapNhapId",
                table: "HoSoSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVi_NguoiCapNhapId",
                table: "HocVi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_NguoiCapNhapId",
                table: "HocKy",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_NguoiCapNhapId",
                table: "HinhThucThi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucDaoTao_NguoiCapNhapId",
                table: "HinhThucDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HanhViViPham_NguoiCapNhapId",
                table: "HanhViViPham",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_NguoiCapNhapId",
                table: "GiangVien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemPhong_NguoiCapNhapId",
                table: "DiaDiemPhong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DayNha_NguoiCapNhapId",
                table: "DayNha",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachSinhVienDuocInThe_NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_NguoiCapNhapId",
                table: "DanhSachKhoaSuDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTonGiao_NguoiCapNhapId",
                table: "DanhMucTonGiao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucQuocTich_NguoiCapNhapId",
                table: "DanhMucQuocTich",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhongBan_NguoiCapNhapId",
                table: "DanhMucPhongBan",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_NguoiCapNhapId",
                table: "DanhMucNoiDung",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_NguoiCapNhapId",
                table: "DanhMucNganhDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHinhDaoTao_NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_NguoiCapNhapId",
                table: "DanhMucKhoanChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_NguoiCapNhapId",
                table: "DanhMucHoSoHSSV",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHocBong_NguoiCapNhapId",
                table: "DanhMucHocBong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDoiTuongUuTien_NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanToc_NguoiCapNhapId",
                table: "DanhMucDanToc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_NguoiCapNhapId",
                table: "DanhMucCanSuLop",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucBieuMau_NguoiCapNhapId",
                table: "DanhMucBieuMau",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyMonHoc_NguoiCapNhapId",
                table: "DangKyMonHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_CoSoDaoTao_NguoiCapNhapId",
                table: "CoSoDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenTruong_NguoiCapNhapId",
                table: "ChuyenTruong",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_NguoiCapNhapId",
                table: "ChuyenNganh",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenLop_NguoiCapNhapId",
                table: "ChuyenLop",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungTinChi_NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhKhungNienChe_NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChi_NguoiCapNhapId",
                table: "ChungChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuanDauRa_NguoiCapNhapId",
                table: "ChuanDauRa",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhungHocKy_TinChi_NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChuongTrinhKhung_NienChe_NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_CaHoc_NguoiCapNhapId",
                table: "CaHoc",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_NguoiCapNhapId",
                table: "Bang_BangDiem_TN",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_BacDaoTao_NguoiCapNhapId",
                table: "BacDaoTao",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDungQuyCheHocVu_NguoiCapNhapId",
                table: "ApDungQuyCheHocVu",
                column: "NguoiCapNhapId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiCapNhapId",
                table: "ApDungQuyCheHocVu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDungQuyCheHocVu_NguoiDung_NguoiTaoId",
                table: "ApDungQuyCheHocVu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BacDaoTao_NguoiDung_NguoiCapNhapId",
                table: "BacDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BacDaoTao_NguoiDung_NguoiTaoId",
                table: "BacDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiCapNhapId",
                table: "Bang_BangDiem_TN",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bang_BangDiem_TN_NguoiDung_NguoiTaoId",
                table: "Bang_BangDiem_TN",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaHoc_NguoiDung_NguoiCapNhapId",
                table: "CaHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaHoc_NguoiDung_NguoiTaoId",
                table: "CaHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiCapNhapId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietChuongTrinhKhung_NienChe_NguoiDung_NguoiTaoId",
                table: "ChiTietChuongTrinhKhung_NienChe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiCapNhapId",
                table: "ChiTietKhungHocKy_TinChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhungHocKy_TinChi_NguoiDung_NguoiTaoId",
                table: "ChiTietKhungHocKy_TinChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_NguoiCapNhapId",
                table: "ChuanDauRa",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuanDauRa_NguoiDung_NguoiTaoId",
                table: "ChuanDauRa",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChi_NguoiDung_NguoiCapNhapId",
                table: "ChungChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChi_NguoiDung_NguoiTaoId",
                table: "ChungChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiCapNhapId",
                table: "ChuongTrinhKhungNienChe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungNienChe_NguoiDung_NguoiTaoId",
                table: "ChuongTrinhKhungNienChe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiCapNhapId",
                table: "ChuongTrinhKhungTinChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhKhungTinChi_NguoiDung_NguoiTaoId",
                table: "ChuongTrinhKhungTinChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenLop_NguoiDung_NguoiCapNhapId",
                table: "ChuyenLop",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenLop_NguoiDung_NguoiTaoId",
                table: "ChuyenLop",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_NguoiCapNhapId",
                table: "ChuyenNganh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenNganh_NguoiDung_NguoiTaoId",
                table: "ChuyenNganh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_NguoiCapNhapId",
                table: "ChuyenTruong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenTruong_NguoiDung_NguoiTaoId",
                table: "ChuyenTruong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_NguoiCapNhapId",
                table: "CoSoDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoSoDaoTao_NguoiDung_NguoiTaoId",
                table: "CoSoDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_NguoiCapNhapId",
                table: "DangKyMonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyMonHoc_NguoiDung_NguoiTaoId",
                table: "DangKyMonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_NguoiCapNhapId",
                table: "DanhMucBieuMau",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucBieuMau_NguoiDung_NguoiTaoId",
                table: "DanhMucBieuMau",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_NguoiCapNhapId",
                table: "DanhMucCanSuLop",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucCanSuLop_NguoiDung_NguoiTaoId",
                table: "DanhMucCanSuLop",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_NguoiCapNhapId",
                table: "DanhMucDanToc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanToc_NguoiDung_NguoiTaoId",
                table: "DanhMucDanToc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiCapNhapId",
                table: "DanhMucDoiTuongUuTien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDoiTuongUuTien_NguoiDung_NguoiTaoId",
                table: "DanhMucDoiTuongUuTien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_NguoiCapNhapId",
                table: "DanhMucHocBong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHocBong_NguoiDung_NguoiTaoId",
                table: "DanhMucHocBong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiCapNhapId",
                table: "DanhMucHoSoHSSV",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucHoSoHSSV_NguoiDung_NguoiTaoId",
                table: "DanhMucHoSoHSSV",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanChi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuHocPhi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuHocPhi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhoanThuTuDo",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhoanThuTuDo_NguoiDung_NguoiTaoId",
                table: "DanhMucKhoanThuTuDo",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiCapNhapId",
                table: "DanhMucKhungHoSoHSSV",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhungHoSoHSSV_NguoiDung_NguoiTaoId",
                table: "DanhMucKhungHoSoHSSV",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiHinhDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiHinhDaoTao_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiHinhDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiKhoanThuNgoaiHocPhi_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucLoaiThuPhi_MonHoc_NguoiDung_NguoiTaoId",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucNganhDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNganhDaoTao_NguoiDung_NguoiTaoId",
                table: "DanhMucNganhDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_NguoiCapNhapId",
                table: "DanhMucNoiDung",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucNoiDung_NguoiDung_NguoiTaoId",
                table: "DanhMucNoiDung",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_NguoiCapNhapId",
                table: "DanhMucPhongBan",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBan_NguoiDung_NguoiTaoId",
                table: "DanhMucPhongBan",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_NguoiCapNhapId",
                table: "DanhMucQuocTich",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucQuocTich_NguoiDung_NguoiTaoId",
                table: "DanhMucQuocTich",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_NguoiCapNhapId",
                table: "DanhMucTonGiao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTonGiao_NguoiDung_NguoiTaoId",
                table: "DanhMucTonGiao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiCapNhapId",
                table: "DanhSachKhoaSuDung",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachKhoaSuDung_NguoiDung_NguoiTaoId",
                table: "DanhSachKhoaSuDung",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiCapNhapId",
                table: "DanhSachSinhVienDuocInThe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachSinhVienDuocInThe_NguoiDung_NguoiTaoId",
                table: "DanhSachSinhVienDuocInThe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayNha_NguoiDung_NguoiCapNhapId",
                table: "DayNha",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayNha_NguoiDung_NguoiTaoId",
                table: "DayNha",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_NguoiCapNhapId",
                table: "DiaDiemPhong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaDiemPhong_NguoiDung_NguoiTaoId",
                table: "DiaDiemPhong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_NguoiDung_NguoiCapNhapId",
                table: "GiangVien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_NguoiDung_NguoiTaoId",
                table: "GiangVien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "HanhViViPham",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HanhViViPham_NguoiDung_NguoiTaoId",
                table: "HanhViViPham",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_NguoiCapNhapId",
                table: "HinhThucDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucDaoTao_NguoiDung_NguoiTaoId",
                table: "HinhThucDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucThi_NguoiDung_NguoiCapNhapId",
                table: "HinhThucThi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucThi_NguoiDung_NguoiTaoId",
                table: "HinhThucThi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiCapNhapId",
                table: "HinhThucXuLyVPQCThi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhThucXuLyVPQCThi_NguoiDung_NguoiTaoId",
                table: "HinhThucXuLyVPQCThi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocKy_NguoiDung_NguoiCapNhapId",
                table: "HocKy",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocKy_NguoiDung_NguoiTaoId",
                table: "HocKy",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVi_NguoiDung_NguoiCapNhapId",
                table: "HocVi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVi_NguoiDung_NguoiTaoId",
                table: "HocVi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoSV_NguoiDung_NguoiCapNhapId",
                table: "HoSoSV",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoSV_NguoiDung_NguoiTaoId",
                table: "HoSoSV",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiCapNhapId",
                table: "HTXLViPhamQCThi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HTXLViPhamQCThi_NguoiDung_NguoiTaoId",
                table: "HTXLViPhamQCThi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiCapNhapId",
                table: "KeHoachDaoTao_NienChe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_NienChe_NguoiDung_NguoiTaoId",
                table: "KeHoachDaoTao_NienChe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiCapNhapId",
                table: "KeHoachDaoTao_TinChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachDaoTao_TinChi_NguoiDung_NguoiTaoId",
                table: "KeHoachDaoTao_TinChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhenThuong_NguoiDung_NguoiCapNhapId",
                table: "KhenThuong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhenThuong_NguoiDung_NguoiTaoId",
                table: "KhenThuong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_NguoiDung_NguoiCapNhapId",
                table: "Khoa",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_NguoiDung_NguoiTaoId",
                table: "Khoa",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_NguoiDung_NguoiCapNhapId",
                table: "KhoaHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_NguoiDung_NguoiTaoId",
                table: "KhoaHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_NguoiCapNhapId",
                table: "KhoiKienThuc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiKienThuc_NguoiDung_NguoiTaoId",
                table: "KhoiKienThuc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiNganh_NguoiDung_NguoiCapNhapId",
                table: "KhoiNganh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoiNganh_NguoiDung_NguoiTaoId",
                table: "KhoiNganh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuLamTron_NguoiDung_NguoiCapNhapId",
                table: "KieuLamTron",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuLamTron_NguoiDung_NguoiTaoId",
                table: "KieuLamTron",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_NguoiCapNhapId",
                table: "KieuMonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuMonHoc_NguoiDung_NguoiTaoId",
                table: "KieuMonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichHocThi_NguoiDung_NguoiCapNhapId",
                table: "LichHocThi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichHocThi_NguoiDung_NguoiTaoId",
                table: "LichHocThi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_NguoiCapNhapId",
                table: "LoaiChucVu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChucVu_NguoiDung_NguoiTaoId",
                table: "LoaiChucVu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_NguoiCapNhapId",
                table: "LoaiChungChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiChungChi_NguoiDung_NguoiTaoId",
                table: "LoaiChungChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_NguoiCapNhapId",
                table: "LoaiDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiDaoTao_NguoiDung_NguoiTaoId",
                table: "LoaiDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_NguoiCapNhapId",
                table: "LoaiGiangVien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiGiangVien_NguoiDung_NguoiTaoId",
                table: "LoaiGiangVien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "LoaiHanhViViPham",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHanhViViPham_NguoiDung_NguoiTaoId",
                table: "LoaiHanhViViPham",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiCapNhapId",
                table: "LoaiHinhGiangDay",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHinhGiangDay_NguoiDung_NguoiTaoId",
                table: "LoaiHinhGiangDay",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                table: "LoaiKhenThuong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhenThuong_NguoiDung_NguoiTaoId",
                table: "LoaiKhenThuong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_NguoiCapNhapId",
                table: "LoaiKhoanThu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiKhoanThu_NguoiDung_NguoiTaoId",
                table: "LoaiKhoanThu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_NguoiCapNhapId",
                table: "LoaiMonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiMonHoc_NguoiDung_NguoiTaoId",
                table: "LoaiMonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiPhong_NguoiDung_NguoiCapNhapId",
                table: "LoaiPhong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiPhong_NguoiDung_NguoiTaoId",
                table: "LoaiPhong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_NguoiCapNhapId",
                table: "LoaiSinhVien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiSinhVien_NguoiDung_NguoiTaoId",
                table: "LoaiSinhVien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiTiet_NguoiDung_NguoiCapNhapId",
                table: "LoaiTiet",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiTiet_NguoiDung_NguoiTaoId",
                table: "LoaiTiet",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_NguoiDung_NguoiCapNhapId",
                table: "LopHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_NguoiDung_NguoiTaoId",
                table: "LopHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_NguoiDung_NguoiCapNhapId",
                table: "LopHocPhan",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_NguoiDung_NguoiTaoId",
                table: "LopHocPhan",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiTaoId",
                table: "LopHocPhan_LopDuKien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopNienChe_NguoiDung_NguoiCapNhapId",
                table: "LopNienChe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopNienChe_NguoiDung_NguoiTaoId",
                table: "LopNienChe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_NguoiCapNhapId",
                table: "LyDoXinPhong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LyDoXinPhong_NguoiDung_NguoiTaoId",
                table: "LyDoXinPhong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "MonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_NguoiDung_NguoiTaoId",
                table: "MonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_NguoiCapNhapId",
                table: "MonHocBacDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocBacDaoTao_NguoiDung_NguoiTaoId",
                table: "MonHocBacDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MucDoViPham_NguoiDung_NguoiCapNhapId",
                table: "MucDoViPham",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MucDoViPham_NguoiDung_NguoiTaoId",
                table: "MucDoViPham",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_NguoiDung_NguoiCapNhapId",
                table: "NamHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_NguoiDung_NguoiTaoId",
                table: "NamHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_NguoiCapNhapId",
                table: "NamHoc_HocKy",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NamHoc_HocKy_NguoiDung_NguoiTaoId",
                table: "NamHoc_HocKy",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_NguoiDung_NguoiCapNhapId",
                table: "NganhHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NganhHoc_NguoiDung_NguoiTaoId",
                table: "NganhHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_NguoiDung_IdNguoiCapNhap",
                table: "NguoiDung",
                column: "IdNguoiCapNhap",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiCapNhapId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyCapNhatTrangThaiSv_NguoiDung_NguoiTaoId",
                table: "NhatKyCapNhatTrangThaiSv",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiCapNhapId",
                table: "NhomLoaiHanhViViPham",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiHanhViViPham_NguoiDung_NguoiTaoId",
                table: "NhomLoaiHanhViViPham",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiCapNhapId",
                table: "NhomLoaiKhenThuong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhomLoaiKhenThuong_NguoiDung_NguoiTaoId",
                table: "NhomLoaiKhenThuong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoiDung_NguoiDung_NguoiCapNhapId",
                table: "NoiDung",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoiDung_NguoiDung_NguoiTaoId",
                table: "NoiDung",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_NguoiCapNhapId",
                table: "PhanChuyenNganh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanChuyenNganh_NguoiDung_NguoiTaoId",
                table: "PhanChuyenNganh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_NguoiCapNhapId",
                table: "PhanMonLopHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanMonLopHoc_NguoiDung_NguoiTaoId",
                table: "PhanMonLopHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhongHoc_NguoiDung_NguoiCapNhapId",
                table: "PhongHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhongHoc_NguoiDung_NguoiTaoId",
                table: "PhongHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongXa_NguoiDung_NguoiCapNhapId",
                table: "PhuongXa",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongXa_NguoiDung_NguoiTaoId",
                table: "PhuongXa",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanHuyen_NguoiDung_NguoiCapNhapId",
                table: "QuanHuyen",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanHuyen_NguoiDung_NguoiTaoId",
                table: "QuanHuyen",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_NguoiCapNhapId",
                table: "QuyChe_NienChe",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_NienChe_NguoiDung_NguoiTaoId",
                table: "QuyChe_NienChe",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_NguoiCapNhapId",
                table: "QuyChe_TinChi",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChe_TinChi_NguoiDung_NguoiTaoId",
                table: "QuyChe_TinChi",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_NguoiCapNhapId",
                table: "QuyCheHocVu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyCheHocVu_NguoiDung_NguoiTaoId",
                table: "QuyCheHocVu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_NguoiCapNhapId",
                table: "QuyChuanDauRa",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyChuanDauRa_NguoiDung_NguoiTaoId",
                table: "QuyChuanDauRa",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinh_NguoiDung_NguoiCapNhapId",
                table: "QuyetDinh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinh_NguoiDung_NguoiTaoId",
                table: "QuyetDinh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_MonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_MonHoc_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_MonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_NC",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_NC_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_NC",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiCapNhapId",
                table: "QuyUocCotDiem_TC",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyUocCotDiem_TC_NguoiDung_NguoiTaoId",
                table: "QuyUocCotDiem_TC",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_NguoiDung_NguoiCapNhapId",
                table: "SinhVien",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_NguoiDung_NguoiTaoId",
                table: "SinhVien",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiCapNhapId",
                table: "SinhVienDangKiHocPhan",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienDangKiHocPhan_NguoiDung_NguoiTaoId",
                table: "SinhVienDangKiHocPhan",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiCapNhapId",
                table: "SinhVienMienMonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienMienMonHoc_NguoiDung_NguoiTaoId",
                table: "SinhVienMienMonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_NguoiCapNhapId",
                table: "SinhVienNganh2",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienNganh2_NguoiDung_NguoiTaoId",
                table: "SinhVienNganh2",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_NguoiCapNhapId",
                table: "ThoiGianDaoTao",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiGianDaoTao_NguoiDung_NguoiTaoId",
                table: "ThoiGianDaoTao",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_NguoiCapNhapId",
                table: "ThoiKhoaBieu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_NguoiDung_NguoiTaoId",
                table: "ThoiKhoaBieu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_NguoiCapNhapId",
                table: "ThongKeInBieuMau",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeInBieuMau_NguoiDung_NguoiTaoId",
                table: "ThongKeInBieuMau",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiCapNhapId",
                table: "ThongTinChung_QuyCheTC",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinChung_QuyCheTC_NguoiDung_NguoiTaoId",
                table: "ThongTinChung_QuyCheTC",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiCapNhapId",
                table: "TiepNhanHoSoSv",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanHoSoSv_NguoiDung_NguoiTaoId",
                table: "TiepNhanHoSoSv",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiCapNhapId",
                table: "TieuChiTuyenSinh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChiTuyenSinh_NguoiDung_NguoiTaoId",
                table: "TieuChiTuyenSinh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiCapNhapId",
                table: "TieuChuanXetDanhHieu",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetDanhHieu_NguoiDung_NguoiTaoId",
                table: "TieuChuanXetDanhHieu",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiCapNhapId",
                table: "TieuChuanXetHocBong",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TieuChuanXetHocBong_NguoiDung_NguoiTaoId",
                table: "TieuChuanXetHocBong",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_NguoiCapNhapId",
                table: "TinhChatMonHoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhChatMonHoc_NguoiDung_NguoiTaoId",
                table: "TinhChatMonHoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhThanh_NguoiDung_NguoiCapNhapId",
                table: "TinhThanh",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhThanh_NguoiDung_NguoiTaoId",
                table: "TinhThanh",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToBoMon_NguoiDung_NguoiCapNhapId",
                table: "ToBoMon",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToBoMon_NguoiDung_NguoiTaoId",
                table: "ToBoMon",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_NguoiCapNhapId",
                table: "TrangThaiLopHP",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiLopHP_NguoiDung_NguoiTaoId",
                table: "TrangThaiLopHP",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiCapNhapId",
                table: "TrangThaiXetQuyUoc",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiXetQuyUoc_NguoiDung_NguoiTaoId",
                table: "TrangThaiXetQuyUoc",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiCapNhapId",
                table: "XetLLHB_QuyCheTC",
                column: "NguoiCapNhapId",
                principalTable: "NguoiDung",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_XetLLHB_QuyCheTC_NguoiDung_NguoiTaoId",
                table: "XetLLHB_QuyCheTC",
                column: "NguoiTaoId",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }
    }
}
