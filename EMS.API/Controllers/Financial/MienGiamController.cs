using EMS.API.Controllers.Base;
using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Financial;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Financial
{
    [Route("api/mien-giam")]
    public class MienGiamController : BaseController<MienGiamSinhVien>
    {
        private readonly IMienGiamService _mienGiamService;

        public MienGiamController(IMienGiamService service) : base(service)
        {
            _mienGiamService = service;
        }

        [HttpGet("custom-paged")]
        public async Task<IActionResult> GetCustomPaged([FromQuery] MienGiamFilterDto filter)
        {
            var result = await _mienGiamService.GetPagedCustomAsync(filter);
            return result.ToResult();
        }

        [HttpPost("apply")]
        public async Task<IActionResult> Apply([FromBody] ApplyMienGiamDto dto)
        {
            var result = await _mienGiamService.ApplyAsync(dto);
            return result.ToResult();
        }

        [HttpPost("approve")]
        public async Task<IActionResult> Approve([FromBody] ApprovalMienGiamDto dto)
        {
            var result = await _mienGiamService.ApproveAsync(dto);
            return result.ToResult();
        }
    }
}