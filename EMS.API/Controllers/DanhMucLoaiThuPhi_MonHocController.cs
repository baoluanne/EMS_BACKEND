using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucLoaiThuPhi_MonHocServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucLoaiThuPhi_MonHocController : BaseController<DanhMucLoaiThuPhi_MonHoc>
{
    private readonly IDanhMucLoaiThuPhi_MonHocService _danhMucLoaiThuPhi_MonHocService;

    public DanhMucLoaiThuPhi_MonHocController(IDanhMucLoaiThuPhi_MonHocService danhMucLoaiThuPhi_MonHocService) : base(danhMucLoaiThuPhi_MonHocService)
    {
        _danhMucLoaiThuPhi_MonHocService = danhMucLoaiThuPhi_MonHocService;
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
                string.IsNullOrEmpty(lowercaseKeyword) ||
                q.MaLoaiThuPhi.ToLower().Contains(lowercaseKeyword) ||
                q.TenLoaiThuPhi.ToLower().Contains(lowercaseKeyword) ||
                (q.STT != null && q.STT.ToString().ToLower().Contains(lowercaseKeyword.ToLower())) ||
                (!string.IsNullOrEmpty(q.CongThucQuyDoi) && q.CongThucQuyDoi.ToLower().Contains(lowercaseKeyword.ToLower())) ||
                (!string.IsNullOrEmpty(q.MaTKNganHang) && q.MaTKNganHang.ToLower().Contains(lowercaseKeyword.ToLower()) ||
                 (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower())))
        );
        return result.ToResult();
    }
}

