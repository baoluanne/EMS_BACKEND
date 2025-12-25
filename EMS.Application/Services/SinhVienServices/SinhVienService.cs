using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Entities.Category;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Interfaces.Storages;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.SinhVienServices
{
    public class SinhVienService : BaseService<SinhVien>, ISinhVienService
    {
        private readonly IStorageService _storageService;

        public SinhVienService(IUnitOfWork unitOfWork, ISinhVienRepository repository,
            IStorageService storageService)
            : base(unitOfWork, repository)
        {
            _storageService = storageService;
        }

        protected override Task UpdateEntityProperties(SinhVien existingEntity, SinhVien newEntity)
        {
            existingEntity.MaHoSo = newEntity.MaHoSo;
            existingEntity.SoBaoDanh = newEntity.SoBaoDanh;
            existingEntity.ThuTuNhanHoSo = newEntity.ThuTuNhanHoSo;
            existingEntity.MaSinhVien = newEntity.MaSinhVien;
            existingEntity.MaBarcode = newEntity.MaBarcode;
            existingEntity.HoDem = newEntity.HoDem;
            existingEntity.Ten = newEntity.Ten;
            existingEntity.GioiTinh = newEntity.GioiTinh;
            existingEntity.NgaySinh = newEntity.NgaySinh;
            existingEntity.DonViCuDiHoc = newEntity.DonViCuDiHoc;
            existingEntity.IdTHPTTinh = newEntity.IdTHPTTinh;
            existingEntity.IdTHPTHuyen = newEntity.IdTHPTHuyen;
            existingEntity.IdTHPTPhuongXa = newEntity.IdTHPTPhuongXa;

            existingEntity.IdHKTTTinh = newEntity.IdHKTTTinh;
            existingEntity.IdHKTTHuyen = newEntity.IdHKTTHuyen;
            existingEntity.IdHKTTPhuongXa = newEntity.IdHKTTPhuongXa;
            existingEntity.HKTTSoNhaThonXom = newEntity.HKTTSoNhaThonXom;

            existingEntity.IdDCLLTinh = newEntity.IdDCLLTinh;
            existingEntity.IdDCLLHuyen = newEntity.IdDCLLHuyen;
            existingEntity.IdDCLLPhuongXa = newEntity.IdDCLLPhuongXa;
            existingEntity.DCLLSoNhaThonXom = newEntity.DCLLSoNhaThonXom;

            existingEntity.HoKhauTamTru = newEntity.HoKhauTamTru;
            existingEntity.DiaChiLienLac = newEntity.DiaChiLienLac;
            existingEntity.IdTenTinh = newEntity.IdTenTinh;
            existingEntity.IdTenHuyen = newEntity.IdTenHuyen;
            existingEntity.IdTenPhuongXa = newEntity.IdTenPhuongXa;
            existingEntity.IdNoiSinhTinh = newEntity.IdNoiSinhTinh;
            existingEntity.IdNoiSinhHuyen = newEntity.IdNoiSinhHuyen;
            existingEntity.IdNoiSinhPhuongXa = newEntity.IdNoiSinhPhuongXa;
            existingEntity.IdLopHoc = newEntity.IdLopHoc;
            existingEntity.IdLopNienChe = newEntity.IdLopNienChe;
            existingEntity.LoaiSinhVien = newEntity.LoaiSinhVien;
            existingEntity.NguyenQuan = newEntity.NguyenQuan;
            existingEntity.KhuVuc = newEntity.KhuVuc;
            existingEntity.PhanHe = newEntity.PhanHe;
            existingEntity.TruongTotNghiep = newEntity.TruongTotNghiep;
            existingEntity.NgayVaoDoan = newEntity.NgayVaoDoan;
            existingEntity.NgayVaoDang = newEntity.NgayVaoDang;
            existingEntity.SoCMND = newEntity.SoCMND;
            existingEntity.NgayCap = newEntity.NgayCap;
            existingEntity.NoiCapCMND = newEntity.NoiCapCMND;
            existingEntity.NoiCap = newEntity.NoiCap;
            existingEntity.IdCoSo = newEntity.IdCoSo;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdNganh = newEntity.IdNganh;
            existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
            existingEntity.IdNganh2 = newEntity.IdNganh2;
            existingEntity.NgayNhapHoc = newEntity.NgayNhapHoc;
            existingEntity.HoTenCha = newEntity.HoTenCha;
            existingEntity.NgheNghiepCha = newEntity.NgheNghiepCha;
            existingEntity.HoTenMe = newEntity.HoTenMe;
            existingEntity.NgheNghiepMe = newEntity.NgheNghiepMe;
            existingEntity.SoDienThoai = newEntity.SoDienThoai;
            existingEntity.SoDienThoaiPhuHuynh = newEntity.SoDienThoaiPhuHuynh;
            existingEntity.SoDienThoai2 = newEntity.SoDienThoai2;
            existingEntity.SoDienThoai3 = newEntity.SoDienThoai3;
            existingEntity.Email = newEntity.Email;
            existingEntity.EmailTruong = newEntity.EmailTruong;
            existingEntity.SoTaiKhoan = newEntity.SoTaiKhoan;
            existingEntity.TenTaiKhoan = newEntity.TenTaiKhoan;
            existingEntity.TenNganHang = newEntity.TenNganHang;
            existingEntity.ChiNhanhNganHang = newEntity.ChiNhanhNganHang;
            existingEntity.MaBHXHBHYT = newEntity.MaBHXHBHYT;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.TruongLop12 = newEntity.TruongLop12;
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            existingEntity.NgayQuyetDinh = newEntity.NgayQuyetDinh;
            existingEntity.DotRaQuyetDinh = newEntity.DotRaQuyetDinh;
            existingEntity.ChucVu = newEntity.ChucVu;
            existingEntity.DonViCongTac = newEntity.DonViCongTac;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.HinhTheSinhVienUrl = newEntity.HinhTheSinhVienUrl;
            existingEntity.NgayImportAnhTheSv = newEntity.NgayImportAnhTheSv;
            existingEntity.NgayCapNhatAnhThe = newEntity.NgayCapNhatAnhThe;
            existingEntity.AnhCMNDMatTruoc = newEntity.AnhCMNDMatTruoc;
            existingEntity.AnhCMNDMatSau = newEntity.AnhCMNDMatSau;
            existingEntity.AnhBangTotNghiep = newEntity.AnhBangTotNghiep;
            existingEntity.AnhHocBa = newEntity.AnhHocBa;
            existingEntity.AnhGiayKhaiSinh = newEntity.AnhGiayKhaiSinh;
            existingEntity.AnhHoKhau = newEntity.AnhHoKhau;
            existingEntity.AnhCMTQuanSu = newEntity.AnhCMTQuanSu;
            existingEntity.AnhGiayUuTien = newEntity.AnhGiayUuTien;
            existingEntity.AnhKhac = newEntity.AnhKhac;
            existingEntity.HoSoDaXacThuc = newEntity.HoSoDaXacThuc;
            existingEntity.NgayXacThucHoSo = newEntity.NgayXacThucHoSo;
            existingEntity.IdNguoiXacThuc = newEntity.IdNguoiXacThuc;
            existingEntity.GhiChuHoSo = newEntity.GhiChuHoSo;
            existingEntity.IdDanToc = newEntity.IdDanToc;
            existingEntity.IdTonGiao = newEntity.IdTonGiao;
            existingEntity.IdQuocTich = newEntity.IdQuocTich;
            existingEntity.IdDoiTuongUuTien = newEntity.IdDoiTuongUuTien;
            existingEntity.LoaiCuTru = newEntity.LoaiCuTru;
            existingEntity.KiemTraSinhVien = newEntity.KiemTraSinhVien;
            existingEntity.DoiTuongChinhSach = newEntity.DoiTuongChinhSach;

            return Task.CompletedTask;
        }


        public async Task<ImportHinhSinhVienResponseDto> ImportImagesAsync(ImportHinhSinhVienRequestDto request)
        {
            var successList = new List<ImportHinhSinhVienResult>();
            var failList = new List<ImportHinhSinhVienResult>();
            var extensionsAllowed = new[] { ".jpg", ".jpeg", ".png" };
            foreach (var file in request.Files)
            {
                try
                {
                    if (file.Length == 0) continue;

                    var ext = Path.GetExtension(file.FileName).ToLower();
                    if (!extensionsAllowed.Contains(ext))
                    {
                        failList.Add(new ImportHinhSinhVienResult
                        {
                            TenFile = file.FileName,
                            GhiChu = "Định dạng không hợp lệ"
                        });
                        continue;
                    }

                    string maSV = Path.GetFileNameWithoutExtension(file.FileName);
                    var student = await Repository.GetFirstAsync(x => x.MaSinhVien == maSV);

                    if (student == null)
                    {
                        failList.Add(new ImportHinhSinhVienResult
                        {
                            TenFile = file.FileName,
                            GhiChu = "Không tìm thấy sinh viên"
                        });
                        continue;
                    }

                    var subFolder =
                        $"avatars/{student.LopHoc?.KhoaHoc.TenKhoaHoc}/{student.LopHoc?.TenLop}/{student.MaSinhVien}";
                    var filePath = await _storageService.UploadFileAsync(file, subFolder);

                    student.HinhTheSinhVienUrl = filePath;
                    student.NgayImportAnhTheSv = DateTime.UtcNow;
                    Repository.Update(student);

                    successList.Add(new ImportHinhSinhVienResult
                    {
                        MaSinhVien = student.MaSinhVien,
                        TenSinhVien = student.FullName,
                        FilePath = student.HinhTheSinhVienUrl,
                    });
                }
                catch (Exception ex)
                {
                    failList.Add(new ImportHinhSinhVienResult { TenFile = file.FileName, GhiChu = ex.Message });
                }
            }

            // Commit all changes
            if (successList.Count != 0)
            {
                await UnitOfWork.CommitAsync();
            }

            return new ImportHinhSinhVienResponseDto(successList, failList, request.TotalChunks, request.ChunkIndex);
        }

        public async Task<Result<PaginationResponse<SinhVien>>> GetSinhVienPaginationAsync(
            PaginationRequest request,
            SinhVienFilter filter)
        {
            var today = DateTime.UtcNow.Date;

            DateTime? bornFrom = null, bornTo = null; // DOB range from age
            if (filter.DoTuoiTu.HasValue) bornTo = today.AddYears(-filter.DoTuoiTu.Value); // <= bornTo
            if (filter.DoTuoiDen.HasValue)
                bornFrom = today.AddYears(-(filter.DoTuoiDen.Value + 1)).AddDays(1); // >= bornFrom

            var nhTu = filter.NgayNhapHocTu?.Date;
            var nhDen = filter.NgayNhapHocDen?.Date;

            Expression<Func<SinhVien, bool>> filterExpression = q =>
                (!filter.IdCoSoDaoTao.HasValue || q.IdCoSo == filter.IdCoSoDaoTao) &&
                (!filter.IdKhoaHoc.HasValue || q.IdKhoaHoc == filter.IdKhoaHoc) &&
                (!filter.IdBacDaoTao.HasValue || q.IdBacDaoTao == filter.IdBacDaoTao) &&
                (!filter.IdLoaiDaoTao.HasValue || q.IdLoaiDaoTao == filter.IdLoaiDaoTao) &&
                (!filter.IdKhoa.HasValue || (q.LopHoc != null && q.LopHoc.IdKhoa == filter.IdKhoa)) &&
                (!filter.IdNganhHoc.HasValue || (q.LopHoc != null && q.LopHoc.IdNganhHoc == filter.IdNganhHoc)) &&
                (!filter.IdLopHoc.HasValue || q.IdLopHoc == filter.IdLopHoc) &&
                (!filter.IdLoaiSinhVien.HasValue || q.IdLoaiSinhVien == filter.IdLoaiSinhVien) &&
                (!filter.TrangThai.HasValue || q.TrangThai == filter.TrangThai) &&
                (!filter.IdDoiTuongUuTien.HasValue || q.IdDoiTuongUuTien == filter.IdDoiTuongUuTien) &&
                (filter.DoiTuongChinhSach == null || q.DoiTuongChinhSach == filter.DoiTuongChinhSach) &&
                (filter.IdQuocTich == null || q.IdQuocTich == filter.IdQuocTich) &&
                (filter.IdTonGiao == null || q.IdTonGiao == filter.IdTonGiao) &&
                (filter.IdDanToc == null || q.IdDanToc == filter.IdDanToc) &&

                // Text contains (server-side using LIKE)
                (string.IsNullOrWhiteSpace(filter.MaHoSo) ||
                 (EF.Functions.Like(q.MaHoSo, $"%{filter.MaHoSo.Trim()}%"))) &&
                (string.IsNullOrWhiteSpace(filter.MaSinhVien) || (EF.Functions.Like(q.MaSinhVien,
                    $"%{filter.MaSinhVien.Trim()}%"))) &&
                (string.IsNullOrWhiteSpace(filter.HoDem) ||
                 (EF.Functions.Like(q.HoDem, $"%{filter.HoDem.Trim()}%"))) &&
                (string.IsNullOrWhiteSpace(filter.Ten) ||
                 (EF.Functions.Like(q.Ten, $"%{filter.Ten.Trim()}%"))) &&
                (string.IsNullOrWhiteSpace(filter.DienThoai)
                 || (q.SoDienThoai != null && EF.Functions.Like(q.SoDienThoai, $"%{filter.DienThoai.Trim()}%"))) &&
                (string.IsNullOrEmpty(filter.TimNhanh) ||
                 q.HoDem.Contains(filter.TimNhanh) || q.Ten.Contains(filter.TimNhanh)) &&
                // Nơi sinh search across 3 text fields
                (string.IsNullOrWhiteSpace(filter.NoiSinh) ||
                 ((q.NoiSinhTinh != null &&
                   q.NoiSinhTinh.TenTinhThanh.Contains(filter.NoiSinh.Trim())) ||
                  (q.NoiSinhHuyen != null &&
                   q.NoiSinhHuyen.TenQuanHuyen.Contains(filter.NoiSinh.Trim())) ||
                  (q.NoiSinhPhuongXa != null &&
                   q.NoiSinhPhuongXa.TenPhuongXa.Contains(filter.NoiSinh.Trim())))) &&

                // Gender
                (!filter.GioiTinh.HasValue || q.GioiTinh == filter.GioiTinh) &&
                (!filter.LoaiCuTru.HasValue || q.LoaiCuTru == filter.LoaiCuTru) &&
                (!filter.KiemTra.HasValue || q.KiemTraSinhVien == filter.KiemTra) &&
                (!filter.Nhom.HasValue ||
                 q.DangKyHocPhans.Any(x => x.Nhom != null && x.Nhom == filter.Nhom)) &&

                // Age → DOB bounds
                (!bornFrom.HasValue || (q.NgaySinh.HasValue && q.NgaySinh.Value.Date >= bornFrom.Value)) &&
                (!bornTo.HasValue || (q.NgaySinh.HasValue && q.NgaySinh.Value.Date <= bornTo.Value)) &&

                // Ngày nhập học range
                (!nhTu.HasValue || (q.NgayNhapHoc.HasValue && q.NgayNhapHoc.Value.Date >= nhTu.Value)) &&
                (!nhDen.HasValue || (q.NgayNhapHoc.HasValue && q.NgayNhapHoc.Value.Date <= nhDen.Value)) &&
                (!filter.NgayImportTu.HasValue || q.NgayTao.Date >= filter.NgayImportTu.Value) &&
                (!filter.NgayImportDen.HasValue || q.NgayTao.Date <= filter.NgayImportDen.Value) &&
                (!filter.NgayImportHinhTu.HasValue
                 || (q.NgayImportAnhTheSv.HasValue &&
                     q.NgayImportAnhTheSv.Value.Date >= filter.NgayImportHinhTu.Value)) &&
                (!filter.NgayImportHinhDen.HasValue
                 || (q.NgayImportAnhTheSv.HasValue &&
                     q.NgayImportAnhTheSv.Value.Date <= filter.NgayImportHinhDen.Value)) &&
                (!filter.ThuTuHoSoTu.HasValue ||
                 (q.ThuTuNhanHoSo.HasValue && q.ThuTuNhanHoSo.Value >= filter.ThuTuHoSoTu.Value)) &&
                (!filter.ThuTuHoSoDen.HasValue ||
                 (q.ThuTuNhanHoSo.HasValue && q.ThuTuNhanHoSo.Value <= filter.ThuTuHoSoDen.Value)) &&
                (!filter.NgayRaQuyetDinhTu.HasValue ||
                 (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh.Value >= filter.NgayRaQuyetDinhTu.Value)) &&
                (!filter.NgayRaQuyetDinhDen.HasValue ||
                 (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh.Value <= filter.NgayRaQuyetDinhDen.Value)) &&
                (!filter.NgayKyTu.HasValue ||
                 (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh.Value >= filter.NgayKyTu.Value)) &&
                (!filter.NgayRaQuyetDinhDen.HasValue ||
                 (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh.Value <= filter.NgayRaQuyetDinhDen.Value)) &&
                (string.IsNullOrEmpty(filter.MaLienKet)
                 || (!string.IsNullOrEmpty(q.MaBarcode) && q.MaBarcode.Contains(filter.MaLienKet.Trim()))) &&
                (string.IsNullOrEmpty(filter.SoQuyetDinh)
                 || (!string.IsNullOrEmpty(q.SoQuyetDinh) && q.SoQuyetDinh.Contains(filter.SoQuyetDinh.Trim()))) &&

                // HKTT is a single string column; apply each provided piece to the same column
                (string.IsNullOrWhiteSpace(filter.HoKhauThuongTru)
                 || (q.HKTTTinh != null &&
                     EF.Functions.Like(q.HKTTTinh.TenTinhThanh, $"%{filter.HoKhauThuongTru.Trim()}%"))) &&
                (filter.IdTinh == null || (q.IdTenTinh != null && q.IdTenTinh == filter.IdTinh)) &&
                (!filter.ExcludeIds.Any() || !filter.ExcludeIds.Contains(q.Id)) &&
                (filter.IdHuyen == null || (q.IdTenHuyen != null && q.IdTenHuyen == filter.IdHuyen)) &&
                (filter.IdPhuongXa == null || (q.IdTenPhuongXa != null && q.IdTenPhuongXa == filter.IdPhuongXa));

            var result = await Repository.PaginateAsync(request, include: GetSinhVienIncludeFunc(),
                filter: filterExpression, select: GetSinhVienSelectFunc());

            return new Result<PaginationResponse<SinhVien>>(result);
        }

        public async Task<Result<List<SinhVien>>> GetSinhVienAllAsync()
        {
            var result = await Repository.ListAsync(include: GetSinhVienIncludeFunc(), select: GetSinhVienSelectFunc());

            return new Result<List<SinhVien>>(result);
        }

        public virtual async Task<Result<PaginationResponse<SinhVien>>> SearchStudentsPaginatedAsync(
            PaginationRequest request,
            TimKiemSinhVienFilterRequestDto filter)
        {
            try
            {
                Expression<Func<SinhVien, bool>> filterExpression = sv => true;
                if (filter.Id != null)
                {
                    filterExpression = filterExpression.And(sv => sv.Id == filter.Id);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(filter.MaSinhVien))
                    {
                        filterExpression = filterExpression.And(sv => sv.MaSinhVien.Contains(filter.MaSinhVien));
                    }

                    if (!string.IsNullOrWhiteSpace(filter.HoDem))
                    {
                        filterExpression = filterExpression.And(sv => sv.HoDem.Contains(filter.HoDem));
                    }

                    if (!string.IsNullOrWhiteSpace(filter.Ten))
                    {
                        filterExpression = filterExpression.And(sv => sv.Ten.Contains(filter.Ten));
                    }

                    if (filter.IdCoSo != null)
                        filterExpression = filterExpression.And(sv => sv.IdCoSo == filter.IdCoSo);

                    if (filter.IdKhoaHoc != null)
                        filterExpression = filterExpression.And(sv => sv.IdKhoaHoc == filter.IdKhoaHoc);

                    if (filter.IdBacDaoTao != null)
                        filterExpression = filterExpression.And(sv => sv.IdBacDaoTao == filter.IdBacDaoTao);

                    if (filter.IdLoaiDaoTao != null)
                        filterExpression = filterExpression.And(sv => sv.IdLoaiDaoTao == filter.IdLoaiDaoTao);

                    if (filter.IdNganh != null)
                        filterExpression = filterExpression.And(sv => sv.IdNganh == filter.IdNganh);

                    if (filter.IdChuyenNganh != null)
                        filterExpression = filterExpression.And(sv => sv.IdChuyenNganh == filter.IdChuyenNganh);

                    if (filter.IdLopHoc != null)
                        filterExpression = filterExpression.And(sv => sv.IdLopHoc == filter.IdLopHoc);

                    if (filter.TrangThai != null)
                        filterExpression = filterExpression.And(sv => sv.TrangThai == filter.TrangThai);

                    if (filter.NgaySinhTu != null)
                        filterExpression = filterExpression.And(sv =>
                            sv.NgaySinh != null && sv.NgaySinh.Value.Date >= filter.NgaySinhTu.Value.Date);

                    if (filter.NgaySinhDen != null)
                        filterExpression = filterExpression.And(sv =>
                            sv.NgaySinh != null && sv.NgaySinh.Value.Date <= filter.NgaySinhDen.Value.Date);

                    if (filter.GioiTinh != null)
                        filterExpression = filterExpression.And(sv => sv.GioiTinh == filter.GioiTinh);

                    if (!string.IsNullOrWhiteSpace(filter.DiaChi))
                        filterExpression = filterExpression.And(sv =>
                            sv.DiaChiLienLac != null &&
                            EF.Functions.Like(sv.DiaChiLienLac, $"%{filter.DiaChi.Trim()}%"));
                }

                IQueryable<SinhVien> includeFunc(IQueryable<SinhVien> q)
                {
                    return q.AsNoTracking().Include(sv => sv.LopHoc)
                        .Include(sv => sv.BacDaoTao)
                        .Include(sv => sv.CoSoDaoTao)
                        .Include(sv => sv.KhoaHoc)
                        .Include(sv => sv.LoaiDaoTao)
                        .Include(sv => sv.Nganh)
                        .Include(sv => sv.ChuyenNganh);
                }

                var result = await Repository.PaginateAsync(request, include: includeFunc, filter: filterExpression);

                return new Result<PaginationResponse<SinhVien>>(result);
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<SinhVien>>(ex);
            }
        }

        private Func<IQueryable<SinhVien>, IQueryable<SinhVien>> GetSinhVienIncludeFunc()
        {
            return q => q.Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.Nganh).ThenInclude(x => x.Khoa)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.Nganh2)
                .Include(x => x.LopHoc)
                .Include(x => x.LopNienChe)
                .Include(x => x.NguoiXacThuc)
                .Include(x => x.DanToc)
                .Include(x => x.TonGiao)
                .Include(x => x.DoiTuongUuTien)
                .Include(x => x.CoSoDaoTao)
                .Include(x => x.KhoaHoc)
                .Include(x => x.QuocTich)
                .Include(x => x.LoaiSinhVien)
                .Include(x => x.TenTinh)
                .Include(x => x.TenHuyen)
                .Include(x => x.NoiSinhHuyen)
                .Include(x => x.NoiSinhPhuongXa)
                .Include(x => x.NoiSinhTinh)
                .Include(x => x.DangKyHocPhans).ThenInclude(x => x.LopHocPhan);
        }

        private Func<IQueryable<SinhVien>, IQueryable<SinhVien>> GetSinhVienSelectFunc()
        {
            return q => q.Select(sv => new SinhVien
            {
                Id = sv.Id,
                MaHoSo = sv.MaHoSo,
                SoBaoDanh = sv.SoBaoDanh,
                ThuTuNhanHoSo = sv.ThuTuNhanHoSo,
                MaSinhVien = sv.MaSinhVien,
                MaBarcode = sv.MaBarcode,
                HoDem = sv.HoDem,
                Ten = sv.Ten,
                GioiTinh = sv.GioiTinh,
                NgaySinh = sv.NgaySinh,
                DonViCuDiHoc = sv.DonViCuDiHoc,
                NgayImportAnhTheSv = sv.NgayImportAnhTheSv,
                DanToc =
                    sv.DanToc != null
                        ? new DanhMucDanToc
                        {
                            Id = sv.DanToc.Id,
                            MaDanToc = sv.DanToc.MaDanToc,
                            TenDanToc = sv.DanToc.TenDanToc
                        }
                        : null,
                TonGiao =
                    sv.TonGiao != null
                        ? new DanhMucTonGiao
                        {
                            Id = sv.TonGiao.Id,
                            MaTonGiao = sv.TonGiao.MaTonGiao,
                            TenTonGiao = sv.TonGiao.TenTonGiao
                        }
                        : null,
                HoKhauTamTru = sv.HoKhauTamTru,
                DiaChiLienLac = sv.DiaChiLienLac,
                TenTinh =
                    sv.TenTinh != null
                        ? new TinhThanh
                        {
                            Id = sv.TenTinh.Id,
                            MaTinhThanh = sv.TenTinh.MaTinhThanh,
                            TenTinhThanh = sv.TenTinh.TenTinhThanh
                        }
                        : null,
                TenHuyen =
                    sv.TenHuyen != null
                        ? new QuanHuyen
                        {
                            Id = sv.TenHuyen.Id,
                            MaQuanHuyen = sv.TenHuyen.MaQuanHuyen,
                            TenQuanHuyen = sv.TenHuyen.TenQuanHuyen
                        }
                        : null,
                TenPhuongXa =
                    sv.TenPhuongXa != null
                        ? new PhuongXa
                        {
                            Id = sv.TenPhuongXa.Id,
                            MaPhuongXa = sv.TenPhuongXa.MaPhuongXa,
                            TenPhuongXa = sv.TenPhuongXa.TenPhuongXa
                        }
                        : null,
                NoiSinhTinh =
                    sv.NoiSinhTinh != null
                        ? new TinhThanh
                        {
                            Id = sv.NoiSinhTinh.Id,
                            MaTinhThanh = sv.NoiSinhTinh.MaTinhThanh,
                            TenTinhThanh = sv.NoiSinhTinh.TenTinhThanh
                        }
                        : null,
                NoiSinhHuyen =
                    sv.NoiSinhHuyen != null
                        ? new QuanHuyen
                        {
                            Id = sv.NoiSinhHuyen.Id,
                            MaQuanHuyen = sv.NoiSinhHuyen.MaQuanHuyen,
                            TenQuanHuyen = sv.NoiSinhHuyen.TenQuanHuyen
                        }
                        : null,
                NoiSinhPhuongXa =
                    sv.NoiSinhPhuongXa != null
                        ? new PhuongXa
                        {
                            Id = sv.NoiSinhPhuongXa.Id,
                            MaPhuongXa = sv.NoiSinhPhuongXa.MaPhuongXa,
                            TenPhuongXa = sv.NoiSinhPhuongXa.TenPhuongXa
                        }
                        : null,
                LopHoc =
                    sv.LopHoc != null
                        ? new LopHoc
                        {
                            Id = sv.LopHoc.Id,
                            MaLop = sv.LopHoc.MaLop,
                            TenLop = sv.LopHoc.TenLop,
                            SiSoDuKien = sv.LopHoc.SiSoDuKien,
                            IdCoSoDaoTao = sv.LopHoc.IdCoSoDaoTao,
                            IdKhoaHoc = sv.LopHoc.IdKhoaHoc,
                            IdBacDaoTao = sv.LopHoc.IdBacDaoTao,
                            IdLoaiDaoTao = sv.LopHoc.IdLoaiDaoTao,
                            IdNganhHoc = sv.LopHoc.IdNganhHoc,
                            IdChuyenNganh = sv.LopHoc.IdChuyenNganh,
                            IdKhoa = sv.LopHoc.IdKhoa
                        }
                        : null,
                LoaiSinhVien =
                    sv.LoaiSinhVien != null
                        ? new LoaiSinhVien
                        {
                            Id = sv.LoaiSinhVien.Id,
                            MaLoaiSinhVien = sv.LoaiSinhVien.MaLoaiSinhVien,
                            TenLoaiSinhVien = sv.LoaiSinhVien.TenLoaiSinhVien
                        }
                        : null,
                NguyenQuan = sv.NguyenQuan,
                DoiTuongUuTien =
                    sv.DoiTuongUuTien != null
                        ? new DanhMucDoiTuongUuTien
                        {
                            Id = sv.DoiTuongUuTien.Id,
                            MaDoiTuong = sv.DoiTuongUuTien.MaDoiTuong,
                            TenDoiTuong = sv.DoiTuongUuTien.TenDoiTuong
                        }
                        : null,
                DoiTuongChinhSach = sv.DoiTuongChinhSach,
                KhuVuc = sv.KhuVuc,
                PhanHe = sv.PhanHe,
                TruongTotNghiep = sv.TruongTotNghiep,
                NgayVaoDoan = sv.NgayVaoDoan,
                NgayVaoDang = sv.NgayVaoDang,
                SoCMND = sv.SoCMND,
                NgayCap = sv.NgayCap,
                NoiCapCMND = sv.NoiCapCMND,
                NoiCap = sv.NoiCap,
                CoSoDaoTao =
                    sv.CoSoDaoTao != null
                        ? new CoSoDaoTao
                        {
                            Id = sv.CoSoDaoTao.Id,
                            MaCoSo = sv.CoSoDaoTao.MaCoSo,
                            TenCoSo = sv.CoSoDaoTao.TenCoSo
                        }
                        : null,
                KhoaHoc =
                    sv.KhoaHoc != null
                        ? new KhoaHoc { Id = sv.KhoaHoc.Id, TenKhoaHoc = sv.KhoaHoc.TenKhoaHoc }
                        : null,
                BacDaoTao =
                    sv.BacDaoTao != null
                        ? new BacDaoTao
                        {
                            Id = sv.BacDaoTao.Id,
                            MaBacDaoTao = sv.BacDaoTao.MaBacDaoTao,
                            TenBacDaoTao = sv.BacDaoTao.TenBacDaoTao
                        }
                        : null,
                LoaiDaoTao =
                    sv.LoaiDaoTao != null
                        ? new LoaiDaoTao
                        {
                            Id = sv.LoaiDaoTao.Id,
                            MaLoaiDaoTao = sv.LoaiDaoTao.MaLoaiDaoTao,
                            TenLoaiDaoTao = sv.LoaiDaoTao.TenLoaiDaoTao
                        }
                        : null,
                Nganh =
                    sv.Nganh != null
                        ? new NganhHoc
                        {
                            Id = sv.Nganh.Id,
                            MaNganhHoc = sv.Nganh.MaNganhHoc,
                            TenNganhHoc = sv.Nganh.TenNganhHoc,
                            TenTiengAnh = sv.Nganh.TenTiengAnh,
                            MaTuyenSinh = sv.Nganh.MaTuyenSinh,
                            IdKhoa = sv.Nganh.IdKhoa,
                            Khoa = sv.Nganh.Khoa,
                        }
                        : null,
                ChuyenNganh =
                    sv.ChuyenNganh != null
                        ? new ChuyenNganh
                        {
                            Id = sv.ChuyenNganh.Id,
                            MaChuyenNganh = sv.ChuyenNganh.MaChuyenNganh,
                            TenChuyenNganh = sv.ChuyenNganh.TenChuyenNganh,
                            IdNganhHoc = sv.ChuyenNganh.IdNganhHoc
                        }
                        : null,
                Nganh2 =
                    sv.Nganh2 != null
                        ? new NganhHoc
                        {
                            Id = sv.Nganh2.Id,
                            MaNganhHoc = sv.Nganh2.MaNganhHoc,
                            TenNganhHoc = sv.Nganh2.TenNganhHoc,
                            TenTiengAnh = sv.Nganh2.TenTiengAnh,
                            MaTuyenSinh = sv.Nganh2.MaTuyenSinh,
                            IdKhoa = sv.Nganh2.IdKhoa
                        }
                        : null,
                NgayNhapHoc = sv.NgayNhapHoc,
                HoTenCha = sv.HoTenCha,
                NgheNghiepCha = sv.NgheNghiepCha,
                HoTenMe = sv.HoTenMe,
                NgheNghiepMe = sv.NgheNghiepMe,
                SoDienThoai = sv.SoDienThoai,
                SoDienThoaiPhuHuynh = sv.SoDienThoaiPhuHuynh,
                SoDienThoai2 = sv.SoDienThoai2,
                SoDienThoai3 = sv.SoDienThoai3,
                Email = sv.Email,
                EmailTruong = sv.EmailTruong,
                SoTaiKhoan = sv.SoTaiKhoan,
                TenNganHang = sv.TenNganHang,
                ChiNhanhNganHang = sv.ChiNhanhNganHang,
                MaBHXHBHYT = sv.MaBHXHBHYT,
                TrangThai = sv.TrangThai,
                QuocTich =
                    sv.QuocTich != null
                        ? new DanhMucQuocTich
                        {
                            Id = sv.QuocTich.Id,
                            MaQuocGia = sv.QuocTich.MaQuocGia,
                            TenQuocGia = sv.QuocTich.TenQuocGia
                        }
                        : null,
                TruongLop12 = sv.TruongLop12,
                SoQuyetDinh = sv.SoQuyetDinh,
                NgayQuyetDinh = sv.NgayQuyetDinh,
                DotRaQuyetDinh = sv.DotRaQuyetDinh,
                ChucVu = sv.ChucVu,
                DonViCongTac = sv.DonViCongTac,
                GhiChu = sv.GhiChu
            });
        }

        public override async Task<Result<SinhVien>> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await Repository.GetFirstAsync(
                    sv => sv.Id == id,
                    q => q.Include(sv => sv.LopHoc)
                );
                if (entity == null)
                {
                    return new Result<SinhVien>(new NotFoundException($"Entity with ID {id} not found."));
                }

                return new Result<SinhVien>(entity);
            }
            catch (Exception ex)
            {
                return new Result<SinhVien>(ex);
            }
        }
    }
}
