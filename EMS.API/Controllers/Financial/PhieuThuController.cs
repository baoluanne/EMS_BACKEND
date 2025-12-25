using Microsoft.EntityFrameworkCore;
using EMS.API.Controllers.Base;
using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Financial;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.EFCore;
using Microsoft.AspNetCore.Mvc;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.API.Controllers.Financial
{
    public class PhieuThuController : BaseController<PhieuThuSinhVien>
    {
        private readonly IPhieuThuService _phieuThuService;
        private readonly AppDbContext _context;

        public PhieuThuController(IPhieuThuService service, AppDbContext context) : base(service)
        {
            _phieuThuService = service;
            _context = context;
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetDanhSachCustom(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 30,
            [FromQuery] string keyword = "")
        {
            try
            {
                var result = await _phieuThuService.GetDanhSachPhieuThuCustomAsync(page, pageSize, keyword);

                return Ok(new
                {
                    result = result.Data,
                    totalCount = result.Total
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("chua-dong/{sinhVienId}")]
        public async Task<IActionResult> GetCongNoChuaDong(Guid sinhVienId)
        {
            try
            {
                var data = await _context.CongNoSinhViens
                    .AsNoTracking()
                    .Where(c => c.SinhVienId == sinhVienId && !c.IsDeleted)
                    .Where(c => (c.ChiTiets.Sum(x => x.SoTien) - c.DaThu - c.TongMienGiam) > 0)
            .Select(c => new
            {
                maSinhVien = c.SinhVien.MaSinhVien,
                tenSinhVien = (c.SinhVien.HoDem + " " + c.SinhVien.Ten).Trim(),
                congNoId = c.Id,
                hocKy = c.NamHocHocKy != null ? c.NamHocHocKy.TenDot : "Chưa xác định",
                hanNop = c.HanNop,
                phaiThu = c.ChiTiets.Sum(x => x.SoTien),
                daThu = c.DaThu,
                mienGiam = c.TongMienGiam,
                conNo = c.ChiTiets.Sum(x => x.SoTien) - c.DaThu - c.TongMienGiam
            })
                    .OrderBy(x => x.hanNop)
                    .ToListAsync();

                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi API ChuaDong: {ex.Message}");
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }
        [HttpPost("thanh-toan")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePhieuThuDto dto)
        {
            var result = await _phieuThuService.CreatePaymentAsync(dto);
            return result.ToResult();
        }
    }
}