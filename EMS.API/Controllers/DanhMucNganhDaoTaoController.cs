using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucNganhDaoTaoServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucNganhDaoTaoController : BaseController<DanhMucNganhDaoTao>
{
    private readonly IDanhMucNganhDaoTaoService _danhMucNganhDaoTaoService;

    public DanhMucNganhDaoTaoController(IDanhMucNganhDaoTaoService danhMucNganhDaoTaoService) : base(danhMucNganhDaoTaoService)
    {
        _danhMucNganhDaoTaoService = danhMucNganhDaoTaoService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.Khoa)
            .Include(x => x.KhoiNganh)
        );
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
            include: q => 
                q.Include(x => x.Khoa)
                .Include(x => x.KhoiNganh),
            filter: q => string.IsNullOrEmpty(lowercaseKeyword)
                    || (q.MaNganh.ToLower().Contains(lowercaseKeyword))
                    || (q.TenNganh.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.TenVietTat) && q.TenVietTat.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.TenTiengAnh) && q.TenTiengAnh.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.MaTuyenSinh) && q.MaTuyenSinh.ToLower().Contains(lowercaseKeyword))
                    || (q.Khoa != null && q.Khoa.TenKhoa.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.KhoiThi) && q.KhoiThi.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.KyTuMaSV) && q.KyTuMaSV.ToLower().Contains(lowercaseKeyword))
                    || (q.KhoiNganh != null && q.KhoiNganh.TenKhoiNganh.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.STT) && q.STT.Contains(lowercaseKeyword))
        );
        return result.ToResult();
    }
}

