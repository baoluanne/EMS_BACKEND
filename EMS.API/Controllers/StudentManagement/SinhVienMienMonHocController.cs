using EMS.API.Controllers.Base;
using EMS.Application.Services.SinhVienMienMonHocServices;
using EMS.Application.Services.SinhVienMienMonHocServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class SinhVienMienMonHocController : BaseController<SinhVienMienMonHoc>
    {
        private readonly ISinhVienMienMonHocService _sinhVienMienMonHocService;

        public SinhVienMienMonHocController(ISinhVienMienMonHocService sinhVienMienMonHocService) : base(sinhVienMienMonHocService)
        {
            _sinhVienMienMonHocService = sinhVienMienMonHocService;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
                .Include(x => x.MonHocBacDaoTao)
                .ThenInclude(x => x.MonHoc)
                .Include(x => x.QuyetDinh)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] SinhVienMienMonHocFilter filter)
        {
            var result = await _sinhVienMienMonHocService.GetSinhVienMienMonHocPaginatedAsync(request, filter);
            return result.ToResult();
        }

        [HttpPost("bulk-create")]
        public virtual async Task<IActionResult> BulkCreateAsync([FromBody] BulkCreateRequestDto body)
        {
            var result = await _sinhVienMienMonHocService.BulkCreateAsync(body);
            return Ok(result);
        }

        [HttpPost("import")]
        public override async Task<IActionResult> Import([FromBody] ImportRequest request)
        {
            if (request?.File == null || request.File.Length == 0)
                return BadRequest("File is invalid");
            var result = await _sinhVienMienMonHocService.ImportMienMonHocAsync(request.File);
            return Ok(result);
        }
    }
}