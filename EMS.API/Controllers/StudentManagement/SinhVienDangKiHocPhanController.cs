using EMS.API.Controllers.Base;
using EMS.Application.Services.SinhVienDangKiHocPhanServices;
using EMS.Application.Services.SinhVienDangKiHocPhanServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class SinhVienDangKiHocPhanController : BaseController<SinhVienDangKiHocPhan>
    {
        private readonly ISinhVienDangKiHocPhanService _sinhVienDangKiHocPhanService;

        public SinhVienDangKiHocPhanController(ISinhVienDangKiHocPhanService sinhVienDangKiHocPhanService) : base(sinhVienDangKiHocPhanService)
        {
            _sinhVienDangKiHocPhanService = sinhVienDangKiHocPhanService;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
                .Include(x => x.LopHocPhan)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] SinhVienDangKiHocPhanFilterRequestDto filter)
        {
            var result = await _sinhVienDangKiHocPhanService.GetSinhVienDangKyHocPhanPaginatedAsync(request, filter);
            return result.ToResult();
        }
    }
}