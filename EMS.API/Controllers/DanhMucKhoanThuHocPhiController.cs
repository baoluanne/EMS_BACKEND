using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucKhoanThuHocPhiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucKhoanThuHocPhiController : BaseController<DanhMucKhoanThuHocPhi>
{
    private readonly IDanhMucKhoanThuHocPhiService _danhMucKhoanThuHocPhiService;

    public DanhMucKhoanThuHocPhiController(IDanhMucKhoanThuHocPhiService danhMucKhoanThuHocPhiService) : base(
        danhMucKhoanThuHocPhiService)
    {
        _danhMucKhoanThuHocPhiService = danhMucKhoanThuHocPhiService;
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || (q.TenKhoanThu.ToLower().Contains(lowercaseKeyword))
                || (q.MaKhoanThu.ToLower().Contains(lowercaseKeyword))
                || (q.STT != null && q.STT.ToString()!.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (!string.IsNullOrEmpty(q.GhiChu) &&
                    q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower()))
        );
        return result.ToResult();
    }
}