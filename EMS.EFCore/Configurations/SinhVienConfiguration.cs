using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class SinhVienConfiguration : IEntityTypeConfiguration<SinhVien>
    {
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.HasKey(e => e.Id);

            // Required properties
            builder.Property(e => e.MaHoSo).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SoBaoDanh).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MaSinhVien).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MaBarcode).IsRequired().HasMaxLength(50);
            builder.Property(e => e.HoDem).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Ten).IsRequired().HasMaxLength(50);

            // Optional properties with max length
            builder.Property(e => e.DonViCuDiHoc).HasMaxLength(200);
            builder.Property(e => e.HoKhauTamTru).HasMaxLength(500);
            builder.Property(e => e.DiaChiLienLac).HasMaxLength(500);
            builder.Property(e => e.NguyenQuan).HasMaxLength(200);
            builder.Property(e => e.KhuVuc).HasMaxLength(50);
            builder.Property(e => e.PhanHe).HasMaxLength(50);
            builder.Property(e => e.TruongTotNghiep).HasMaxLength(200);
            builder.Property(e => e.SoCMND).HasMaxLength(50);
            builder.Property(e => e.NoiCapCMND).HasMaxLength(200);
            builder.Property(e => e.NoiCap).HasMaxLength(200);
            builder.Property(e => e.HoTenCha).HasMaxLength(100);
            builder.Property(e => e.NgheNghiepCha).HasMaxLength(200);
            builder.Property(e => e.HoTenMe).HasMaxLength(100);
            builder.Property(e => e.NgheNghiepMe).HasMaxLength(200);
            builder.Property(e => e.SoDienThoai).HasMaxLength(20);
            builder.Property(e => e.SoDienThoaiPhuHuynh).HasMaxLength(20);
            builder.Property(e => e.SoDienThoai2).HasMaxLength(20);
            builder.Property(e => e.SoDienThoai3).HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.EmailTruong).HasMaxLength(100);
            builder.Property(e => e.SoTaiKhoan).HasMaxLength(50);
            builder.Property(e => e.TenTaiKhoan).HasMaxLength(100);
            builder.Property(e => e.TenNganHang).HasMaxLength(200);
            builder.Property(e => e.ChiNhanhNganHang).HasMaxLength(200);
            builder.Property(e => e.MaBHXHBHYT).HasMaxLength(50);
            builder.Property(e => e.TruongLop12).HasMaxLength(200);
            builder.Property(e => e.SoQuyetDinh).HasMaxLength(50);
            builder.Property(e => e.DotRaQuyetDinh).HasMaxLength(100);
            builder.Property(e => e.ChucVu).HasMaxLength(100);
            builder.Property(e => e.DonViCongTac).HasMaxLength(200);
            builder.Property(e => e.GhiChu).HasMaxLength(500);
            builder.Property(e => e.HinhTheSinhVienUrl).HasMaxLength(500);
            builder.Property(e => e.AnhCMNDMatTruoc).HasMaxLength(500);
            builder.Property(e => e.AnhCMNDMatSau).HasMaxLength(500);
            builder.Property(e => e.AnhBangTotNghiep).HasMaxLength(500);
            builder.Property(e => e.AnhHocBa).HasMaxLength(500);
            builder.Property(e => e.AnhGiayKhaiSinh).HasMaxLength(500);
            builder.Property(e => e.AnhHoKhau).HasMaxLength(500);
            builder.Property(e => e.AnhCMTQuanSu).HasMaxLength(500);
            builder.Property(e => e.AnhGiayUuTien).HasMaxLength(500);
            builder.Property(e => e.AnhKhac).HasMaxLength(500);
            builder.Property(e => e.GhiChuHoSo).HasMaxLength(500);
            builder.Property(e => e.LoaiCuTru);
            builder.Property(e => e.KiemTraSinhVien);
            builder.Property(e => e.DoiTuongChinhSach);
            builder.Property(e => e.TrangThai);
            builder.Property(e => e.HKTTSoNhaThonXom)
                .HasMaxLength(500);
            builder.Property(e => e.DCLLSoNhaThonXom)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(e => e.BacDaoTao)
                .WithMany()
                .HasForeignKey(e => e.IdBacDaoTao)
                .IsRequired(false);

            builder.HasOne(e => e.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(e => e.IdLoaiDaoTao)
                .IsRequired(false);

            builder.HasOne(e => e.LoaiSinhVien)
                .WithMany()
                .HasForeignKey(e => e.IdLoaiSinhVien)
                .IsRequired(false);

            builder.HasOne(e => e.Nganh)
                .WithMany()
                .HasForeignKey(e => e.IdNganh)
                .IsRequired(false);

            builder.HasOne(e => e.ChuyenNganh)
                .WithMany()
                .HasForeignKey(e => e.IdChuyenNganh)
                .IsRequired(false);

            builder.HasOne(e => e.Nganh2)
                .WithMany()
                .HasForeignKey(e => e.IdNganh2)
                .IsRequired(false);

            builder.HasOne(e => e.LopHoc)
                .WithMany()
                .HasForeignKey(e => e.IdLopHoc)
                .IsRequired(false);

            builder.HasOne(e => e.LopNienChe)
                .WithMany()
                .HasForeignKey(e => e.IdLopNienChe)
                .IsRequired(false);

            builder.HasOne(e => e.NguoiXacThuc)
                .WithMany()
                .HasForeignKey(e => e.IdNguoiXacThuc)
                .IsRequired(false);

            builder.HasOne(e => e.CoSoDaoTao)
                .WithMany()
                .HasForeignKey(e => e.IdCoSo)
                .IsRequired(false);
            builder.HasOne(e => e.KhoaHoc)
                .WithMany()
                .HasForeignKey(e => e.IdKhoaHoc)
                .IsRequired(false);

            builder.HasMany(x => x.DangKyHocPhans)
                .WithOne()
                .HasForeignKey(x => x.IdLopHocPhan)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.DoiTuongUuTien)
                .WithMany()
                .HasForeignKey(e => e.IdDoiTuongUuTien)
                .IsRequired(false);

            builder.HasOne(e => e.DanToc)
                .WithMany()
                .HasForeignKey(e => e.IdDanToc)
                .IsRequired(false);

            builder.HasOne(e => e.TonGiao)
                .WithMany()
                .HasForeignKey(e => e.IdTonGiao)
                .IsRequired(false);

            builder.HasOne(e => e.QuocTich)
                .WithMany()
                .HasForeignKey(e => e.IdQuocTich)
                .IsRequired(false);
            
            builder.HasOne(e => e.TenTinh)
                .WithMany()
                .HasForeignKey(e => e.IdTenTinh)
                .IsRequired(false);
            
            builder.HasOne(e => e.TenHuyen)
                .WithMany()
                .HasForeignKey(e => e.IdTenHuyen)
                .IsRequired(false);
            
            builder.HasOne(e => e.TenPhuongXa)
                .WithMany()
                .HasForeignKey(e => e.IdTenPhuongXa)
                .IsRequired(false);
            
            builder.HasOne(e => e.NoiSinhTinh)
                .WithMany()
                .HasForeignKey(e => e.IdNoiSinhTinh)
                .IsRequired(false);
            
            builder.HasOne(e => e.NoiSinhHuyen)
                .WithMany()
                .HasForeignKey(e => e.IdNoiSinhHuyen)
                .IsRequired(false);
            
            builder.HasOne(e => e.NoiSinhPhuongXa)
                .WithMany()
                .HasForeignKey(e => e.IdNoiSinhPhuongXa)
                .IsRequired(false);
            
            builder.HasOne(e => e.HKTTTinh)
                .WithMany()
                .HasForeignKey(e => e.IdHKTTTinh)
                .IsRequired(false);
            
            builder.HasOne(e => e.HKTTHuyen)
                .WithMany()
                .HasForeignKey(e => e.IdHKTTHuyen)
                .IsRequired(false);
            
            builder.HasOne(e => e.HKTTPhuongXa)
                .WithMany()
                .HasForeignKey(e => e.IdHKTTPhuongXa)
                .IsRequired(false);
            
            builder.HasOne(e => e.DCLLTinh)
                .WithMany()
                .HasForeignKey(e => e.IdDCLLTinh)
                .IsRequired(false);
            
            builder.HasOne(e => e.DCLLHuyen)
                .WithMany()
                .HasForeignKey(e => e.IdDCLLHuyen)
                .IsRequired(false);
            
            builder.HasOne(e => e.DCLLPhuongXa)
                .WithMany()
                .HasForeignKey(e => e.IdDCLLPhuongXa)
                .IsRequired(false);
            
            builder.HasOne(e => e.THPTTinh)
                .WithMany()
                .HasForeignKey(e => e.IdTHPTTinh)
                .IsRequired(false);
            
            builder.HasOne(e => e.THPTHuyen)
                .WithMany()
                .HasForeignKey(e => e.IdTHPTHuyen)
                .IsRequired(false);
            
            builder.HasOne(e => e.THPTPhuongXa)
                .WithMany()
                .HasForeignKey(e => e.IdTHPTPhuongXa)
                .IsRequired(false);
        }
    }
}