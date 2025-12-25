using EMS.API.Controllers.Base;
using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Financial;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Extensions;
using EMS.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Financial
{
    [Route("api/[controller]")]
    public class ChinhSachMienGiamController : BaseController<ChinhSachMienGiam>
    {
        private readonly IChinhSachMienGiamService _chinhSachService;
        private readonly AppDbContext _context;

        public ChinhSachMienGiamController(
            IChinhSachMienGiamService chinhSachService,
            AppDbContext context) : base(chinhSachService)
        {
            _chinhSachService = chinhSachService;
            _context = context;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaged(int page, int pageSize, string? keyword)
        {
            var result = await _chinhSachService.GetPagedAsync(page, pageSize, keyword);
            return result.ToResult();
        }  
    }
}