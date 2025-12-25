using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_QuyChuanDauRa_IdCoSoDaoTao_IdKhoaHoc_IdBacDaoTao_IdLoaiDaoT~",
                table: "QuyChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_MaMonHoc",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucXuLyVPQCThi_MaHinhThucXL",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachKhoaSuDung_IdPhong_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNoiDung_LoaiNoiDung_NoiDung",
                table: "DanhMucNoiDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_MaNganh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_MaTuyenSinh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_MaLoaiThuPhi",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_MaLoaiKhoanThu",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuTuDo_MaKhoanThu",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanChi_MaKhoanChi",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHoSoHSSV_MaHoSo",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucCanSuLop_MaChucVu",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_Bang_BangDiem_TN_MaBang_BangDiem",
                table: "Bang_BangDiem_TN");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                columns: new[] { "IdBacDaoTao", "IdLoaiDaoTao" });

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdCoSoDaoTao_IdKhoaHoc_IdBacDaoTao_IdLoaiDaoT~",
                table: "QuyChuanDauRa",
                columns: new[] { "IdCoSoDaoTao", "IdKhoaHoc", "IdBacDaoTao", "IdLoaiDaoTao", "IdChungChi" });

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaMonHoc",
                table: "MonHoc",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu",
                columns: new[] { "MaLoaiChucVu", "TenLoaiChucVu" });

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_MaHinhThucXL",
                table: "HinhThucXuLyVPQCThi",
                column: "MaHinhThucXL");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi",
                column: "MaHinhThucThi");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_IdPhong_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung",
                columns: new[] { "IdPhong", "IdKhoaSuDung" });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_LoaiNoiDung_NoiDung",
                table: "DanhMucNoiDung",
                columns: new[] { "LoaiNoiDung", "NoiDung" });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaNganh",
                table: "DanhMucNganhDaoTao",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaTuyenSinh",
                table: "DanhMucNganhDaoTao",
                column: "MaTuyenSinh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_MaLoaiThuPhi",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "MaLoaiThuPhi");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_MaLoaiKhoanThu",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "MaLoaiKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                columns: new[] { "IdHoSoHSSV", "IdBacDaoTao", "IdLoaiDaoTao" });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_MaKhoanThu",
                table: "DanhMucKhoanThuTuDo",
                column: "MaKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "MaKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuHocPhi",
                column: "MaKhoanThu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_MaKhoanChi",
                table: "DanhMucKhoanChi",
                column: "MaKhoanChi");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_MaHoSo",
                table: "DanhMucHoSoHSSV",
                column: "MaHoSo");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_MaChucVu",
                table: "DanhMucCanSuLop",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh",
                column: "MaChuyenNganh");

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_MaBang_BangDiem",
                table: "Bang_BangDiem_TN",
                column: "MaBang_BangDiem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_QuyChuanDauRa_IdCoSoDaoTao_IdKhoaHoc_IdBacDaoTao_IdLoaiDaoT~",
                table: "QuyChuanDauRa");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_MaMonHoc",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucXuLyVPQCThi_MaHinhThucXL",
                table: "HinhThucXuLyVPQCThi");

            migrationBuilder.DropIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachKhoaSuDung_IdPhong_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNoiDung_LoaiNoiDung_NoiDung",
                table: "DanhMucNoiDung");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_MaNganh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucNganhDaoTao_MaTuyenSinh",
                table: "DanhMucNganhDaoTao");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_MaLoaiThuPhi",
                table: "DanhMucLoaiThuPhi_MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_MaLoaiKhoanThu",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuTuDo_MaKhoanThu",
                table: "DanhMucKhoanThuTuDo");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanThuHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhoanChi_MaKhoanChi",
                table: "DanhMucKhoanChi");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucHoSoHSSV_MaHoSo",
                table: "DanhMucHoSoHSSV");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucCanSuLop_MaChucVu",
                table: "DanhMucCanSuLop");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh");

            migrationBuilder.DropIndex(
                name: "IX_Bang_BangDiem_TN_MaBang_BangDiem",
                table: "Bang_BangDiem_TN");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDaoTao_IdBacDaoTao_IdLoaiDaoTao",
                table: "ThoiGianDaoTao",
                columns: new[] { "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuyChuanDauRa_IdCoSoDaoTao_IdKhoaHoc_IdBacDaoTao_IdLoaiDaoT~",
                table: "QuyChuanDauRa",
                columns: new[] { "IdCoSoDaoTao", "IdKhoaHoc", "IdBacDaoTao", "IdLoaiDaoTao", "IdChungChi" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaMonHoc",
                table: "MonHoc",
                column: "MaMonHoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiChucVu_MaLoaiChucVu_TenLoaiChucVu",
                table: "LoaiChucVu",
                columns: new[] { "MaLoaiChucVu", "TenLoaiChucVu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucXuLyVPQCThi_MaHinhThucXL",
                table: "HinhThucXuLyVPQCThi",
                column: "MaHinhThucXL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThi_MaHinhThucThi",
                table: "HinhThucThi",
                column: "MaHinhThucThi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachKhoaSuDung_IdPhong_IdKhoaSuDung",
                table: "DanhSachKhoaSuDung",
                columns: new[] { "IdPhong", "IdKhoaSuDung" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNoiDung_LoaiNoiDung_NoiDung",
                table: "DanhMucNoiDung",
                columns: new[] { "LoaiNoiDung", "NoiDung" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaNganh",
                table: "DanhMucNganhDaoTao",
                column: "MaNganh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNganhDaoTao_MaTuyenSinh",
                table: "DanhMucNganhDaoTao",
                column: "MaTuyenSinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThuPhi_MonHoc_MaLoaiThuPhi",
                table: "DanhMucLoaiThuPhi_MonHoc",
                column: "MaLoaiThuPhi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiKhoanThuNgoaiHocPhi_MaLoaiKhoanThu",
                table: "DanhMucLoaiKhoanThuNgoaiHocPhi",
                column: "MaLoaiKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhungHoSoHSSV_IdHoSoHSSV_IdBacDaoTao_IdLoaiDaoTao",
                table: "DanhMucKhungHoSoHSSV",
                columns: new[] { "IdHoSoHSSV", "IdBacDaoTao", "IdLoaiDaoTao" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuTuDo_MaKhoanThu",
                table: "DanhMucKhoanThuTuDo",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuNgoaiHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuNgoaiHocPhi",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanThuHocPhi_MaKhoanThu",
                table: "DanhMucKhoanThuHocPhi",
                column: "MaKhoanThu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhoanChi_MaKhoanChi",
                table: "DanhMucKhoanChi",
                column: "MaKhoanChi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucHoSoHSSV_MaHoSo",
                table: "DanhMucHoSoHSSV",
                column: "MaHoSo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCanSuLop_MaChucVu",
                table: "DanhMucCanSuLop",
                column: "MaChucVu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganh_MaChuyenNganh",
                table: "ChuyenNganh",
                column: "MaChuyenNganh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bang_BangDiem_TN_MaBang_BangDiem",
                table: "Bang_BangDiem_TN",
                column: "MaBang_BangDiem",
                unique: true);
        }
    }
}
