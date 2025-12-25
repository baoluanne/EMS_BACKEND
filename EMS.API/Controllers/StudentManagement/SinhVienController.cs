using EMS.API.Controllers.Base;
using EMS.Application.Services.SinhVienServices;
using EMS.Application.Services.SinhVienServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class SinhVienController : BaseController<SinhVien>
    {
        private readonly ISinhVienService _sinhVienService;

        public SinhVienController(ISinhVienService sinhVienService) : base(sinhVienService)
        {
            _sinhVienService = sinhVienService;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            var result = await _sinhVienService.GetSinhVienAllAsync();
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request,
            [FromQuery] SinhVienFilter filter)
        {
            var result = await _sinhVienService.GetSinhVienPaginationAsync(request, filter);
            return result.ToResult();
        }

        [HttpPost("import-images")]
        public async Task<IActionResult> ImportSinhVienImages([FromForm] ImportHinhSinhVienRequestDto request)
        {
            if (request.Files == null || !request.Files.Any())
                return BadRequest(new { message = "Không có file nào được upload." });

            try
            {
                var result = await _sinhVienService.ImportImagesAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        [HttpGet("tim-kiem-sinh-vien")]
        public virtual async Task<IActionResult> GetSinhVienPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] TimKiemSinhVienFilterRequestDto filter)
        {
            var result = await _sinhVienService.SearchStudentsPaginatedAsync(request, filter);
            return result.ToResult();
        }

        [HttpGet("ids")]
        public async Task<IActionResult> GetByIds([FromQuery] List<Guid> ids)
        {
            var result = await _sinhVienService.GetByIdsAsync(ids);
            return result.ToResult();
        }

        [HttpGet("pagination/cap-nhat-trang-thai")]
        public async Task<IActionResult> GetPaginationCapNhatTrangThaiSinhVien(
            [FromQuery] PaginationRequest request,
            [FromQuery] CapNhatTrangThaiSinhVienFilter filter)
        {
            var today = DateTime.UtcNow.Date;
            DateTime? bornFrom = null, bornTo = null;

            if (filter.DoTuoiTu.HasValue) bornTo = today.AddYears(-filter.DoTuoiTu.Value);
            if (filter.DoTuoiDen.HasValue)
                bornFrom = today.AddYears(-(filter.DoTuoiDen.Value + 1)).AddDays(1);

            var nhTu = filter.NgayNhapHocTu?.Date;
            var nhDen = filter.NgayNhapHocDen?.Date;

            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
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
                    (!filter.IdTinh.HasValue || q.IdHKTTTinh == filter.IdTinh) &&
                    (!filter.IdHuyen.HasValue || q.IdHKTTHuyen == filter.IdTinh) &&
                    (!filter.IdQuocTich.HasValue || q.IdQuocTich == filter.IdQuocTich) &&
                    (!filter.IdDanToc.HasValue || q.IdDanToc == filter.IdDanToc) &&
                    (!filter.IdTonGiao.HasValue || q.IdTonGiao == filter.IdTonGiao) &&
                    (!filter.IdDoiTuongUuTien.HasValue || q.IdDoiTuongUuTien == filter.IdDoiTuongUuTien) &&
                    (string.IsNullOrEmpty(filter.DotRaQuyetDinh) || q.DotRaQuyetDinh == filter.DotRaQuyetDinh) &&
                    (filter.DoiTuongChinhSach == null || q.DoiTuongChinhSach == filter.DoiTuongChinhSach) &&

                    (string.IsNullOrEmpty(filter.NoiSinh)
                        || (
                            (q.NoiSinhPhuongXa != null && !string.IsNullOrEmpty(q.NoiSinhPhuongXa.TenPhuongXa) &&
                                EF.Functions.Like(q.NoiSinhPhuongXa.TenPhuongXa, $"%{filter.NoiSinh}%"))
                            || (q.NoiSinhHuyen != null && !string.IsNullOrEmpty(q.NoiSinhHuyen.TenQuanHuyen) &&
                                EF.Functions.Like(q.NoiSinhHuyen.TenQuanHuyen, $"%{filter.NoiSinh}%"))
                            || (q.NoiSinhTinh != null && !string.IsNullOrEmpty(q.NoiSinhTinh.TenTinhThanh) &&
                                EF.Functions.Like(q.NoiSinhTinh.TenTinhThanh, $"%{filter.NoiSinh}%"))
                        )
                    ) &&

                    (string.IsNullOrEmpty(filter.HoKhauThuongTru)
                        || (!string.IsNullOrEmpty(q.HKTTSoNhaThonXom)
                            && EF.Functions.Like(q.HKTTSoNhaThonXom, $"%{filter.HoKhauThuongTru}%"))) &&

                    (string.IsNullOrWhiteSpace(filter.MaLienKet) || EF.Functions.Like(q.MaBarcode, $"%{filter.MaLienKet.Trim()}%")) &&

                    (string.IsNullOrWhiteSpace(filter.DotRaQuyetDinh) || EF.Functions.Like(q.DotRaQuyetDinh, $"%{filter.DotRaQuyetDinh.Trim()}%")) &&
                    (string.IsNullOrWhiteSpace(filter.MaHoSo) || EF.Functions.Like(q.MaHoSo, $"%{filter.MaHoSo.Trim()}%")) &&
                    (string.IsNullOrWhiteSpace(filter.MaSinhVien) || EF.Functions.Like(q.MaSinhVien, $"%{filter.MaSinhVien.Trim()}%")) &&
                    (string.IsNullOrWhiteSpace(filter.HoDem) || EF.Functions.Like(q.HoDem, $"%{filter.HoDem.Trim()}%")) &&
                    (string.IsNullOrWhiteSpace(filter.Ten) || EF.Functions.Like(q.Ten, $"%{filter.Ten.Trim()}%")) &&
                    (string.IsNullOrWhiteSpace(filter.SoDienThoai) ||
                        (q.SoDienThoai != null && EF.Functions.Like(q.SoDienThoai, $"%{filter.SoDienThoai.Trim()}%")) ||
                        (q.SoDienThoai2 != null && EF.Functions.Like(q.SoDienThoai2, $"%{filter.SoDienThoai.Trim()}%")) ||
                        (q.SoDienThoai3 != null && EF.Functions.Like(q.SoDienThoai3, $"%{filter.SoDienThoai.Trim()}%"))) &&

                    (!filter.GioiTinh.HasValue || q.GioiTinh == filter.GioiTinh) &&
                    (!filter.LoaiCuTru.HasValue || q.LoaiCuTru == filter.LoaiCuTru) &&

                    (!bornFrom.HasValue || (q.NgaySinh.HasValue && q.NgaySinh.Value.Date >= bornFrom.Value)) &&
                    (!bornTo.HasValue || (q.NgaySinh.HasValue && q.NgaySinh.Value.Date <= bornTo.Value)) &&

                    (!nhTu.HasValue || (q.NgayNhapHoc.HasValue && q.NgayNhapHoc.Value.Date >= nhTu.Value)) &&
                    (!nhDen.HasValue || (q.NgayNhapHoc.HasValue && q.NgayNhapHoc.Value.Date <= nhDen.Value)) &&

                    (!filter.ThuTuNhanHoSoTu.HasValue || (q.ThuTuNhanHoSo.HasValue && q.ThuTuNhanHoSo >= filter.ThuTuNhanHoSoTu)) &&
                    (!filter.ThuTuNhanHoSoDen.HasValue || (q.ThuTuNhanHoSo.HasValue && q.ThuTuNhanHoSo <= filter.ThuTuNhanHoSoDen)) &&
                    (string.IsNullOrEmpty(filter.SoQuyetDinh) || (q.SoQuyetDinh != null && q.SoQuyetDinh.Contains(filter.SoQuyetDinh))) &&
                    (!filter.NgayRaQDFrom.HasValue || (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh >= filter.NgayRaQDFrom)) &&
                    (!filter.NgayRaQDTo.HasValue || (q.NgayQuyetDinh.HasValue && q.NgayQuyetDinh <= filter.NgayRaQDTo)) &&
                    (!filter.NgayImportFrom.HasValue || (q.NgayImportAnhTheSv.HasValue && q.NgayImportAnhTheSv >= filter.NgayImportFrom)) &&
                    (!filter.NgayImportTo.HasValue || (q.NgayImportAnhTheSv.HasValue && q.NgayImportAnhTheSv <= filter.NgayImportTo)) &&
                    (!filter.IdHkttTinh.HasValue || q.IdHKTTTinh == filter.IdHkttTinh) &&
                    (!filter.IdHkttHuyen.HasValue || q.IdHKTTHuyen == filter.IdHkttHuyen) &&
                    (!filter.IdHkttPhuongXa.HasValue || q.IdHKTTPhuongXa == filter.IdHkttPhuongXa) &&
                    (string.IsNullOrEmpty(filter.HkSoNha) || (!string.IsNullOrEmpty(q.HKTTSoNhaThonXom) && EF.Functions.Like(q.HKTTSoNhaThonXom, $"%{filter.HkSoNha}%"))) &&
                    (!filter.IdDcllTinh.HasValue || q.IdDCLLTinh == filter.IdDcllTinh) &&
                    (!filter.IdDcllHuyen.HasValue || q.IdDCLLHuyen == filter.IdDcllHuyen) &&
                    (!filter.IdDcllPhuongXa.HasValue || q.IdDCLLPhuongXa == filter.IdDcllPhuongXa) &&
                    (string.IsNullOrEmpty(filter.HkSoNha) || (!string.IsNullOrEmpty(q.DCLLSoNhaThonXom) && EF.Functions.Like(q.DCLLSoNhaThonXom, $"%{filter.DcllSoNha}%"))) &&
                    (!filter.IdThptTinh.HasValue || q.IdTHPTTinh == filter.IdThptTinh) &&
                    (!filter.IdThptHuyen.HasValue || q.IdTHPTHuyen == filter.IdThptHuyen) &&
                    (string.IsNullOrEmpty(filter.TimNhanh)
                        || (EF.Functions.Like(q.MaSinhVien, $"%{filter.TimNhanh}%")
                            || EF.Functions.Like(q.HoDem, $"%{filter.TimNhanh}%")
                            || EF.Functions.Like(q.Ten, $"%{filter.TimNhanh}%"))),

                include: query => query
                    .Include(x => x.CoSoDaoTao)
                    .Include(x => x.KhoaHoc)
                    .Include(x => x.BacDaoTao)
                    .Include(x => x.LoaiDaoTao)
                    .Include(x => x.Nganh)
                    .Include(x => x.ChuyenNganh)
                    .Include(x => x.Nganh2)
                    .Include(x => x.LopHoc)
                    .Include(x => x.DoiTuongUuTien)
                    .Include(x => x.DanToc)
                    .Include(x => x.TonGiao)
                    .Include(x => x.QuocTich)
                    .Include(x => x.LoaiSinhVien)
                    .Include(x => x.NoiSinhPhuongXa)
                    .Include(x => x.NoiSinhHuyen)
                    .Include(x => x.NoiSinhTinh)
            );

            return result.ToResult();
        }
    }
}