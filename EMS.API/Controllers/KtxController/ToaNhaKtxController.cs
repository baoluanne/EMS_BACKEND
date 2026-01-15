using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement
{
    public class ToaNhaKtxController : BaseController<KTXToaNha>
    {
        public ToaNhaKtxController(IToaNhaKtxService service) : base(service)
        {
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ToaNhaFilter filter)
        {

            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.TenToaNha) || q.TenToaNha!.ToLower().Contains(filter.TenToaNha.ToLower()))
                && (filter.LoaiToaNha == null || q.LoaiToaNha == filter.LoaiToaNha)
            );

            return result.ToResult();
        }
    }

    public class ToaNhaFilter
    {
        public int? LoaiToaNha { get; set; }
        public string? TenToaNha { get; set; }
    }
}