using System.Reflection.Metadata;
using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucLoaiKhoanThuNgoaiHocPhiServices;
using EMS.Domain.Entities;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace EMS.API.Controllers;

public class DanhMucLoaiKhoanThuNgoaiHocPhiController : BaseController<DanhMucLoaiKhoanThuNgoaiHocPhi>
{
    private readonly IDanhMucLoaiKhoanThuNgoaiHocPhiService _danhMucLoaiKhoanThuNgoaiHocPhiService;
    public DanhMucLoaiKhoanThuNgoaiHocPhiController(IDanhMucLoaiKhoanThuNgoaiHocPhiService danhMucLoaiKhoanThuNgoaiHocPhiService) : base(danhMucLoaiKhoanThuNgoaiHocPhiService)
    {
        _danhMucLoaiKhoanThuNgoaiHocPhiService = danhMucLoaiKhoanThuNgoaiHocPhiService;
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowerKeyword = keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => string.IsNullOrEmpty(lowerKeyword)
            || (q.MaLoaiKhoanThu.ToLower().Contains(lowerKeyword))
            || (q.TenLoaiKhoanThu.ToLower().Contains(lowerKeyword))
            || (q.STT != null && q.STT.ToString().ToLower().Contains(lowerKeyword))
            || (!string.IsNullOrEmpty(q.MaTKNganHang) && q.MaTKNganHang.ToLower().Contains(lowerKeyword))
        );
        return result.ToResult();
    }
    
    
}