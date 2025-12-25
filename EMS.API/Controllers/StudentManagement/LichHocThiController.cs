using EMS.API.Controllers.Base;
using EMS.Application.Services.LichHocThiServices;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class LichHocThiController : BaseController<LichHocThi>
    {
        private readonly ILichHocThiService _lichHocThiService;

        public LichHocThiController(ILichHocThiService lichHocThiService) : base(lichHocThiService)
        {
            _lichHocThiService = lichHocThiService;
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.DotHoc)
                .Include(x => x.SinhVien)
                .ThenInclude(x => x.LopHoc)
                .ThenInclude(x => x.CaHoc)
                .Include(x => x.LopHocPhan)
                .ThenInclude(x => x.GiangVien)
                .Include(x => x.LopHocPhan)
                .ThenInclude(r => r.MonHoc)
            );
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] LichHocThiFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.DotHoc)
                    .Include(x => x.SinhVien)
                    .ThenInclude(x => x.LopHoc)
                    .ThenInclude(x => x.CaHoc)
                    .Include(x => x.LopHocPhan)
                    .ThenInclude(x => x.GiangVien)
                    .Include(x => x.LopHocPhan)
                    .ThenInclude(r => r.MonHoc),
                filter: q =>
                    (filter.IdDotHoc == null || q.IdDotHoc == filter.IdDotHoc)
                    && (string.IsNullOrEmpty(filter.HoDem)
                        || (q.SinhVien != null && q.SinhVien.HoDem.ToLower().Contains(filter.HoDem.ToLower())))
                    && (filter.LoaiLich == null || q.LoaiLich == filter.LoaiLich)
                    && (string.IsNullOrEmpty(filter.Ten)
                        || (q.SinhVien != null && q.SinhVien.Ten.ToLower().Contains(filter.Ten.ToLower())))
                    && (string.IsNullOrEmpty(filter.MaSinhVien)
                        || (q.SinhVien != null &&
                            q.SinhVien.MaSinhVien.ToLower().Contains(filter.MaSinhVien.ToLower())))
                    && (filter.TrangThai == null ||
                        (q.LopHocPhan != null && q.LopHocPhan.TrangThai == filter.TrangThai))
            );
            return result.ToResult();
        }
    }

    public class LichHocThiFilter
    {
        public LoaiLich? LoaiLich { get; set; }
        public Guid? IdDotHoc { get; set; }
        public TrangThaiLopHocPhanEnum? TrangThai { get; set; }
        public string? HoDem { get; set; }
        public string? Ten { get; set; }
        public string? MaSinhVien { get; set; }
    }
}