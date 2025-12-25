using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucKhoanThuNgoaiHocPhiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucKhoanThuNgoaiHocPhiController : BaseController<DanhMucKhoanThuNgoaiHocPhi>
{
    private readonly IDanhMucKhoanThuNgoaiHocPhiService _danhMucKhoanThuNgoaiHocPhiService;

    public DanhMucKhoanThuNgoaiHocPhiController(IDanhMucKhoanThuNgoaiHocPhiService danhMucKhoanThuNgoaiHocPhiService) :
        base(danhMucKhoanThuNgoaiHocPhiService)
    {
        _danhMucKhoanThuNgoaiHocPhiService = danhMucKhoanThuNgoaiHocPhiService;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.LoaiKhoanThu));
        return result.ToResult();
    }
    
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.LoaiKhoanThu),
        filter:
        q =>
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