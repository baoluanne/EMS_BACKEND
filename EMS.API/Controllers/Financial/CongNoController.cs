using System.Data.Entity;
using EMS.API.Controllers.Base;
using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Financial;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Financial
{
    public class CongNoController : BaseController<CongNoSinhVien>
    {
        private readonly ICongNoService _congNoService;
        private readonly AppDbContext _context;
        public CongNoController(ICongNoService service, AppDbContext context) : base(service)
        {
            _congNoService = service;
            _context = context;
        }

        [HttpPost("add-khoan-thu")]
        public async Task<IActionResult> AddKhoanThu([FromBody] AddKhoanThuDto dto)
        {
            try
            {

                var result = await _congNoService.AddKhoanThuAsync(dto);
                return result.ToResult();

            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetDetail([FromQuery] Guid sinhVienId, [FromQuery] Guid namHocHocKyId)
        {
            try
            {

                var result = await _congNoService.GetDetailByStudentAsync(sinhVienId, namHocHocKyId);
                return result.ToResult();

            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetDanhSachCustom(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 30,
            [FromQuery] string keyword = "")
        {
            try
            {
                var result = await _congNoService.GetDanhSachCongNoCustomAsync(page, pageSize, keyword);

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
        /*[HttpGet("con-no-chua-dong/{sinhVienId}")]
        public async Task<IActionResult> GetCongNoChuaDong(Guid sinhVienId)
        {
            var data = await _context.CongNoSinhViens
                .Where(c => c.SinhVienId == sinhVienId && c.ConNo > 0 && !c.IsDeleted)
                .Select(c => new
                {
                    id = c.Id,
                    tenHocKy = c.NamHocHocKy.TenDot,
                    hanNop = c.HanNop,
                    phaiThu = c.SoTienPhaiThu,
                    daThu = c.DaThu,
                    mienGiam = c.TongMienGiam,
                    conNo = c.ConNo,
                    ghiChu = c.GhiChu
                })
                .OrderBy(x => x.hanNop)
                .ToListAsync();

            return Ok(data);
        }*/
    }
}