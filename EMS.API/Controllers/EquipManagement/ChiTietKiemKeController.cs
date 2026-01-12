using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Service;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class ChiTietKiemKeController : BaseController<TSTBChiTietKiemKe>
    {
        private readonly IChiTietKiemKeService _chiTietKiemKeService;
        public ChiTietKiemKeController(IChiTietKiemKeService service) : base(service)
        {
            _chiTietKiemKeService = service;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            var result = await _chiTietKiemKeService.GetAllAsync();
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request, [FromQuery] Guid? dotKiemKeId)
        {
            var result = await _chiTietKiemKeService.GetPaginatedAsync(
                request,
                filter: x => !dotKiemKeId.HasValue || x.DotKiemKeId == dotKiemKeId,
                include: x => x.Include(detail => detail.ThietBi)
            );

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(error.Message)
            );
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] TSTBChiTietKiemKe entity)
        //{
        //    var result = await _chiTietKiemKeService.UpdateAsync(id, entity);
        //    return result.Match<IActionResult>(
        //        success => Ok(success),
        //        error => BadRequest(error.Message)
        //    );
        //}
    }
}
