using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EquipManagementv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoCaoThietBi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenBaoCao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LoaiBaoCao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NgayTaoBaoCao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThucKyBaoCao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DuLieuBaoCao = table.Column<string>(type: "text", nullable: false),
                    NguoiTaoBaoCaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                    ThietBiId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HanhDong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NguoiThucHienId = table.Column<Guid>(type: "uuid", nullable: true),
                    MoTaChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhat = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaoThietBi");

            migrationBuilder.DropTable(
                name: "ChiTietKiemKe");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuMuon");

            migrationBuilder.DropTable(
                name: "ChiTietThanhLy");

            migrationBuilder.DropTable(
                name: "NhatKyThietBi");

            migrationBuilder.DropTable(
                name: "PhieuBaoTri");

            migrationBuilder.DropTable(
                name: "DotKiemKe");

            migrationBuilder.DropTable(
                name: "PhieuMuonTra");

            migrationBuilder.DropTable(
                name: "PhieuThanhLy");

            migrationBuilder.DropTable(
                name: "ThietBi");

            migrationBuilder.DropTable(
                name: "LoaiThietBi");

            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
