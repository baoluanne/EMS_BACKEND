using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EquipManagementv2_drop_2_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "BaoCaoThietBi");

            //migrationBuilder.DropTable(
            //    name: "ChiTietKiemKe");

            //migrationBuilder.DropTable(
            //    name: "ChiTietPhieuMuon");

            //migrationBuilder.DropTable(
            //    name: "ChiTietThanhLy");

            //migrationBuilder.DropTable(
            //    name: "NhatKyThietBi");

            //migrationBuilder.DropTable(
            //    name: "PhieuBaoTri");

            //migrationBuilder.DropTable(
            //    name: "DotKiemKe");

            //migrationBuilder.DropTable(
            //    name: "PhieuMuonTra");

            //migrationBuilder.DropTable(
            //    name: "PhieuThanhLy");

            //migrationBuilder.DropTable(
            //    name: "ThietBi");

            //migrationBuilder.DropTable(
            //    name: "LoaiThietBi");

            //migrationBuilder.DropTable(
            //    name: "NhaCungCap");

            migrationBuilder.CreateTable(
                name: "TSTBDotKiemKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenDotKiemKe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DaHoanThanh = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NguoiBatDauId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBDotKiemKe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBDotKiemKe_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBDotKiemKe_NguoiDung_NguoiBatDauId",
                        column: x => x.NguoiBatDauId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TSTBLoaiThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaLoai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenLoai = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBLoaiThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBLoaiThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TSTBNhaCungCap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DienThoai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NguoiLienHe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ChucVuNguoiLienHe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBNhaCungCap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBNhaCungCap_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TSTBPhieuMuonTra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhieu = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LoaiDoiTuong = table.Column<int>(type: "integer", nullable: false),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    GiangVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiDuyetId = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTraId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayMuon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTraDuKien = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTraThucTe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LyDoMuon = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBPhieuMuonTra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiDuyetId",
                        column: x => x.NguoiDuyetId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_NguoiDung_NguoiTraId",
                        column: x => x.NguoiTraId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuMuonTra_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBPhieuThanhLy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NgayThanhLy = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoiDongThanhLy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LyDo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TongTienThuHoi = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NguoiLapPhieuId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBPhieuThanhLy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuThanhLy_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuThanhLy_NguoiDung_NguoiLapPhieuId",
                        column: x => x.NguoiLapPhieuId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaThietBi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenThietBi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ThongSoKyThuat = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    NamSanXuat = table.Column<int>(type: "integer", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayHetHanBaoHanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguyenGia = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GiaTriKhauHao = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    HinhAnhUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LoaiThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    NhaCungCapId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongHocId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBThietBi_PhongHoc_PhongHocId",
                        column: x => x.PhongHocId,
                        principalTable: "PhongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBThietBi_TSTBLoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "TSTBLoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBThietBi_TSTBNhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "TSTBNhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBChiTietKiemKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DotKiemKeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiSoSach = table.Column<int>(type: "integer", nullable: false),
                    TrangThaiThucTe = table.Column<int>(type: "integer", nullable: false),
                    KhopDot = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NguoiKiemKeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBChiTietKiemKe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietKiemKe_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietKiemKe_NguoiDung_NguoiKiemKeId",
                        column: x => x.NguoiKiemKeId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietKiemKe_TSTBDotKiemKe_DotKiemKeId",
                        column: x => x.DotKiemKeId,
                        principalTable: "TSTBDotKiemKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietKiemKe_TSTBThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "TSTBThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBChiTietPhieuMuon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhieuMuonTraId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    TinhTrangKhiMuon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TinhTrangKhiTra = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GhiChuChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBChiTietPhieuMuon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietPhieuMuon_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietPhieuMuon_TSTBPhieuMuonTra_PhieuMuonTraId",
                        column: x => x.PhieuMuonTraId,
                        principalTable: "TSTBPhieuMuonTra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietPhieuMuon_TSTBThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "TSTBThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBChiTietThanhLy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhieuThanhLyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiaTriConLai = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBChiTietThanhLy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietThanhLy_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBChiTietThanhLy_TSTBPhieuThanhLy_PhieuThanhLyId",
                        column: x => x.PhieuThanhLyId,
                        principalTable: "TSTBPhieuThanhLy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TSTBChiTietThanhLy_TSTBThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "TSTBThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TSTBPhieuBaoTri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaPhieu = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    NhaCungCapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiLapPhieuId = table.Column<Guid>(type: "uuid", nullable: false),
                    NguoiXuLyId = table.Column<Guid>(type: "uuid", nullable: true),
                    LoaiBaoTri = table.Column<int>(type: "integer", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NoiDungBaoTri = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    KetQuaXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ChiPhi = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    HinhAnhUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSTBPhieuBaoTri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiLapPhieuId",
                        column: x => x.NguoiLapPhieuId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_NguoiDung_NguoiXuLyId",
                        column: x => x.NguoiXuLyId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_TSTBNhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "TSTBNhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TSTBPhieuBaoTri_TSTBThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "TSTBThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietKiemKe_DotKiemKeId",
                table: "TSTBChiTietKiemKe",
                column: "DotKiemKeId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietKiemKe_IdNguoiCapNhat",
                table: "TSTBChiTietKiemKe",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietKiemKe_IdNguoiTao",
                table: "TSTBChiTietKiemKe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietKiemKe_NguoiKiemKeId",
                table: "TSTBChiTietKiemKe",
                column: "NguoiKiemKeId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietKiemKe_ThietBiId",
                table: "TSTBChiTietKiemKe",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietPhieuMuon_IdNguoiCapNhat",
                table: "TSTBChiTietPhieuMuon",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietPhieuMuon_IdNguoiTao",
                table: "TSTBChiTietPhieuMuon",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietPhieuMuon_PhieuMuonTraId",
                table: "TSTBChiTietPhieuMuon",
                column: "PhieuMuonTraId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietPhieuMuon_ThietBiId",
                table: "TSTBChiTietPhieuMuon",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietThanhLy_IdNguoiCapNhat",
                table: "TSTBChiTietThanhLy",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietThanhLy_IdNguoiTao",
                table: "TSTBChiTietThanhLy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietThanhLy_PhieuThanhLyId",
                table: "TSTBChiTietThanhLy",
                column: "PhieuThanhLyId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBChiTietThanhLy_ThietBiId",
                table: "TSTBChiTietThanhLy",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBDotKiemKe_IdNguoiCapNhat",
                table: "TSTBDotKiemKe",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBDotKiemKe_IdNguoiTao",
                table: "TSTBDotKiemKe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBDotKiemKe_NguoiBatDauId",
                table: "TSTBDotKiemKe",
                column: "NguoiBatDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBLoaiThietBi_IdNguoiCapNhat",
                table: "TSTBLoaiThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBLoaiThietBi_IdNguoiTao",
                table: "TSTBLoaiThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBLoaiThietBi_MaLoai",
                table: "TSTBLoaiThietBi",
                column: "MaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBNhaCungCap_IdNguoiCapNhat",
                table: "TSTBNhaCungCap",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBNhaCungCap_IdNguoiTao",
                table: "TSTBNhaCungCap",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_IdNguoiCapNhat",
                table: "TSTBPhieuBaoTri",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_IdNguoiTao",
                table: "TSTBPhieuBaoTri",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_MaPhieu",
                table: "TSTBPhieuBaoTri",
                column: "MaPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_NguoiLapPhieuId",
                table: "TSTBPhieuBaoTri",
                column: "NguoiLapPhieuId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_NguoiXuLyId",
                table: "TSTBPhieuBaoTri",
                column: "NguoiXuLyId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_NhaCungCapId",
                table: "TSTBPhieuBaoTri",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuBaoTri_ThietBiId",
                table: "TSTBPhieuBaoTri",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_GiangVienId",
                table: "TSTBPhieuMuonTra",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_IdNguoiCapNhat",
                table: "TSTBPhieuMuonTra",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_IdNguoiTao",
                table: "TSTBPhieuMuonTra",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_MaPhieu",
                table: "TSTBPhieuMuonTra",
                column: "MaPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_NguoiDuyetId",
                table: "TSTBPhieuMuonTra",
                column: "NguoiDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_NguoiTraId",
                table: "TSTBPhieuMuonTra",
                column: "NguoiTraId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuMuonTra_SinhVienId",
                table: "TSTBPhieuMuonTra",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuThanhLy_IdNguoiCapNhat",
                table: "TSTBPhieuThanhLy",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuThanhLy_IdNguoiTao",
                table: "TSTBPhieuThanhLy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuThanhLy_NguoiLapPhieuId",
                table: "TSTBPhieuThanhLy",
                column: "NguoiLapPhieuId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBPhieuThanhLy_SoQuyetDinh",
                table: "TSTBPhieuThanhLy",
                column: "SoQuyetDinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_IdNguoiCapNhat",
                table: "TSTBThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_IdNguoiTao",
                table: "TSTBThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_LoaiThietBiId",
                table: "TSTBThietBi",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_MaThietBi",
                table: "TSTBThietBi",
                column: "MaThietBi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_NhaCungCapId",
                table: "TSTBThietBi",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_TSTBThietBi_PhongHocId",
                table: "TSTBThietBi",
                column: "PhongHocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TSTBChiTietKiemKe");

            migrationBuilder.DropTable(
                name: "TSTBChiTietPhieuMuon");

            migrationBuilder.DropTable(
                name: "TSTBChiTietThanhLy");

            migrationBuilder.DropTable(
                name: "TSTBPhieuBaoTri");

            migrationBuilder.DropTable(
                name: "TSTBDotKiemKe");

            migrationBuilder.DropTable(
                name: "TSTBPhieuMuonTra");

            migrationBuilder.DropTable(
                name: "TSTBPhieuThanhLy");

            migrationBuilder.DropTable(
                name: "TSTBThietBi");

            migrationBuilder.DropTable(
                name: "TSTBLoaiThietBi");

            migrationBuilder.DropTable(
                name: "TSTBNhaCungCap");

            migrationBuilder.CreateTable(
                name: "BaoCaoThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoBaoCaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DuLieuBaoCao = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LoaiBaoCao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThucKyBaoCao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTaoBaoCao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenBaoCao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCaoThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaoCaoThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaoCaoThietBi_NguoiDung_NguoiTaoBaoCaoId",
                        column: x => x.NguoiTaoBaoCaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DotKiemKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiBatDauId = table.Column<Guid>(type: "uuid", nullable: true),
                    DaHoanThanh = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenDotKiemKe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotKiemKe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DotKiemKe_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DotKiemKe_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DotKiemKe_NguoiDung_NguoiBatDauId",
                        column: x => x.NguoiBatDauId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MaLoai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenLoai = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    ChucVuNguoiLienHe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DienThoai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NguoiLienHe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhaCungCap_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhaCungCap_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhieuMuonTra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GiangVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiDuyetId = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTraId = table.Column<Guid>(type: "uuid", nullable: true),
                    SinhVienId = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LoaiDoiTuong = table.Column<int>(type: "integer", nullable: false),
                    LyDoMuon = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MaPhieu = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTraDuKien = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTraThucTe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrangThai = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMuonTra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_NguoiDung_NguoiDuyetId",
                        column: x => x.NguoiDuyetId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_NguoiDung_NguoiTraId",
                        column: x => x.NguoiTraId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PhieuMuonTra_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThanhLy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiLapPhieuId = table.Column<Guid>(type: "uuid", nullable: false),
                    HoiDongThanhLy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LyDo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayThanhLy = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TongTienThuHoi = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThanhLy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuThanhLy_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuThanhLy_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuThanhLy_NguoiDung_NguoiLapPhieuId",
                        column: x => x.NguoiLapPhieuId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    LoaiThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    NhaCungCapId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongHocId = table.Column<Guid>(type: "uuid", nullable: true),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    GiaTriKhauHao = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    HinhAnhUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MaThietBi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NamSanXuat = table.Column<int>(type: "integer", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayHetHanBaoHanh = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayMua = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NguyenGia = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenThietBi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ThongSoKyThuat = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThietBi_LoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThietBi_NhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThietBi_PhongHoc_PhongHocId",
                        column: x => x.PhongHocId,
                        principalTable: "PhongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKiemKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DotKiemKeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiKiemKeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    KhopDot = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThaiSoSach = table.Column<int>(type: "integer", nullable: false),
                    TrangThaiThucTe = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKiemKe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKe_DotKiemKe_DotKiemKeId",
                        column: x => x.DotKiemKeId,
                        principalTable: "DotKiemKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKe_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKe_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKe_NguoiDung_NguoiKiemKeId",
                        column: x => x.NguoiKiemKeId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKe_ThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuMuon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhieuMuonTraId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChuChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TinhTrangKhiMuon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TinhTrangKhiTra = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuMuon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuon_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuon_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuon_PhieuMuonTra_PhieuMuonTraId",
                        column: x => x.PhieuMuonTraId,
                        principalTable: "PhieuMuonTra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuon_ThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThanhLy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    PhieuThanhLyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    GiaBan = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GiaTriConLai = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThanhLy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLy_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLy_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLy_PhieuThanhLy_PhieuThanhLyId",
                        column: x => x.PhieuThanhLyId,
                        principalTable: "PhieuThanhLy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLy_ThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiThucHienId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    HanhDong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MoTaChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyThietBi_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatKyThietBi_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatKyThietBi_NguoiDung_NguoiThucHienId",
                        column: x => x.NguoiThucHienId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NhatKyThietBi_ThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuBaoTri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiLapPhieuId = table.Column<Guid>(type: "uuid", nullable: false),
                    NguoiXuLyId = table.Column<Guid>(type: "uuid", nullable: true),
                    NhaCungCapId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiPhi = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    HinhAnhUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    KetQuaXuLy = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    LoaiBaoTri = table.Column<int>(type: "integer", nullable: false),
                    MaPhieu = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NoiDungBaoTri = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuBaoTri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_NguoiDung_IdNguoiCapNhat",
                        column: x => x.IdNguoiCapNhat,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_NguoiDung_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_NguoiDung_NguoiLapPhieuId",
                        column: x => x.NguoiLapPhieuId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_NguoiDung_NguoiXuLyId",
                        column: x => x.NguoiXuLyId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_NhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuBaoTri_ThietBi_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoThietBi_IdNguoiCapNhat",
                table: "BaoCaoThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoThietBi_IdNguoiTao",
                table: "BaoCaoThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoThietBi_NguoiTaoBaoCaoId",
                table: "BaoCaoThietBi",
                column: "NguoiTaoBaoCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKe_DotKiemKeId",
                table: "ChiTietKiemKe",
                column: "DotKiemKeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKe_IdNguoiCapNhat",
                table: "ChiTietKiemKe",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKe_IdNguoiTao",
                table: "ChiTietKiemKe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKe_NguoiKiemKeId",
                table: "ChiTietKiemKe",
                column: "NguoiKiemKeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKe_ThietBiId",
                table: "ChiTietKiemKe",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuon_IdNguoiCapNhat",
                table: "ChiTietPhieuMuon",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuon_IdNguoiTao",
                table: "ChiTietPhieuMuon",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuon_PhieuMuonTraId",
                table: "ChiTietPhieuMuon",
                column: "PhieuMuonTraId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuon_ThietBiId",
                table: "ChiTietPhieuMuon",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLy_IdNguoiCapNhat",
                table: "ChiTietThanhLy",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLy_IdNguoiTao",
                table: "ChiTietThanhLy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLy_PhieuThanhLyId",
                table: "ChiTietThanhLy",
                column: "PhieuThanhLyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLy_ThietBiId",
                table: "ChiTietThanhLy",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_DotKiemKe_IdNguoiCapNhat",
                table: "DotKiemKe",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_DotKiemKe_IdNguoiTao",
                table: "DotKiemKe",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DotKiemKe_NguoiBatDauId",
                table: "DotKiemKe",
                column: "NguoiBatDauId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBi_IdNguoiCapNhat",
                table: "LoaiThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBi_IdNguoiTao",
                table: "LoaiThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBi_MaLoai",
                table: "LoaiThietBi",
                column: "MaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_IdNguoiCapNhat",
                table: "NhaCungCap",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_IdNguoiTao",
                table: "NhaCungCap",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyThietBi_IdNguoiCapNhat",
                table: "NhatKyThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyThietBi_IdNguoiTao",
                table: "NhatKyThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyThietBi_NguoiThucHienId",
                table: "NhatKyThietBi",
                column: "NguoiThucHienId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyThietBi_ThietBiId",
                table: "NhatKyThietBi",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_IdNguoiCapNhat",
                table: "PhieuBaoTri",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_IdNguoiTao",
                table: "PhieuBaoTri",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_MaPhieu",
                table: "PhieuBaoTri",
                column: "MaPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_NguoiLapPhieuId",
                table: "PhieuBaoTri",
                column: "NguoiLapPhieuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_NguoiXuLyId",
                table: "PhieuBaoTri",
                column: "NguoiXuLyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_NhaCungCapId",
                table: "PhieuBaoTri",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoTri_ThietBiId",
                table: "PhieuBaoTri",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_GiangVienId",
                table: "PhieuMuonTra",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_IdNguoiCapNhat",
                table: "PhieuMuonTra",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_IdNguoiTao",
                table: "PhieuMuonTra",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_MaPhieu",
                table: "PhieuMuonTra",
                column: "MaPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_NguoiDuyetId",
                table: "PhieuMuonTra",
                column: "NguoiDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_NguoiTraId",
                table: "PhieuMuonTra",
                column: "NguoiTraId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuonTra_SinhVienId",
                table: "PhieuMuonTra",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThanhLy_IdNguoiCapNhat",
                table: "PhieuThanhLy",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThanhLy_IdNguoiTao",
                table: "PhieuThanhLy",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThanhLy_NguoiLapPhieuId",
                table: "PhieuThanhLy",
                column: "NguoiLapPhieuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThanhLy_SoQuyetDinh",
                table: "PhieuThanhLy",
                column: "SoQuyetDinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_IdNguoiCapNhat",
                table: "ThietBi",
                column: "IdNguoiCapNhat");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_IdNguoiTao",
                table: "ThietBi",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_LoaiThietBiId",
                table: "ThietBi",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_MaThietBi",
                table: "ThietBi",
                column: "MaThietBi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_NhaCungCapId",
                table: "ThietBi",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_PhongHocId",
                table: "ThietBi",
                column: "PhongHocId");
        }
    }
}
