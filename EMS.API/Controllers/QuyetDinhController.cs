using EMS.API.Controllers.Base;
using EMS.Application.Services.QuyetDinhServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class QuyetDinhController : BaseController<QuyetDinh>
{
    private readonly IQuyetDinhService _quyetDinhService;

    public QuyetDinhController(IQuyetDinhService quyetDinhService) : base(quyetDinhService)
    {
        _quyetDinhService = quyetDinhService;
    }

    // Override GetAll to include related entities if needed
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    // Override GetPaginated with custom filtering
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] QuyetDinhFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                (string.IsNullOrEmpty(filter.SoQuyetDinh) || 
                    q.SoQuyetDinh.ToLower().Contains(filter.SoQuyetDinh.ToLower()))
                && (string.IsNullOrEmpty(filter.TenQuyetDinh) || 
                    q.TenQuyetDinh.ToLower().Contains(filter.TenQuyetDinh.ToLower()))
                && (filter.NgayQuyetDinhFrom == null || q.NgayRaQuyetDinh >= filter.NgayQuyetDinhFrom)
                && (filter.NgayQuyetDinhTo == null || q.NgayRaQuyetDinh <= filter.NgayQuyetDinhTo)
                && (filter.NgayKyQuyetDinhFrom == null || q.NgayKyQuyetDinh <= filter.NgayKyQuyetDinhFrom)
                && (filter.NgayKyQuyetDinhTo == null || q.NgayKyQuyetDinh <= filter.NgayKyQuyetDinhTo)
                && (string.IsNullOrEmpty(filter.NguoiKy) || 
                    q.NguoiKyQD != null && q.NguoiKyQD.ToLower().Contains(filter.NguoiKy.ToLower()))
                && (string.IsNullOrEmpty(filter.NguoiRaQD) || 
                    q.NguoiRaQD != null && q.NguoiRaQD.ToLower().Contains(filter.NguoiRaQD.ToLower()))
        );
        return result.ToResult();
    }
}

// Filter class for pagination
public class QuyetDinhFilter
{
    public string? SoQuyetDinh { get; set; }
    public string? TenQuyetDinh { get; set; }
    public DateTime? NgayQuyetDinhFrom { get; set; }
    public DateTime? NgayQuyetDinhTo { get; set; }
    
    public DateTime? NgayKyQuyetDinhFrom { get; set; }
    public DateTime? NgayKyQuyetDinhTo { get; set; }
    public string? NguoiKy { get; set; }
    public string? NguoiRaQD { get; set; }
    // Add other filter properties as needed
}