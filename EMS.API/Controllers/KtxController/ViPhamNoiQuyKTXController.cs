using Microsoft.AspNetCore.Mvc;
using EMS.API.Controllers.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Application.Services.Base;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Extensions;

namespace EMS.API.Controllers.KtxManagement
{
    public class ViPhamNoiQuyKTXController : BaseController<KtxViPhamNoiQuy>
    {
        private readonly IViPhamNoiQuyKTXService _service;
        public ViPhamNoiQuyKTXController(IViPhamNoiQuyKTXService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("sinh-vien/{sinhVienId}")]
        public async Task<IActionResult> GetBySinhVien(Guid sinhVienId)
        {
            var result = await _service.GetAllAsync(
                include: i => i.Include(x => x.SinhVien!.CuTruKtxs),
                filter: x => x.SinhVienId == sinhVienId
            );

            return result.ToResult();
        }
    }
}