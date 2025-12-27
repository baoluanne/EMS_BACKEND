using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

/// <summary>
/// Service interface cho Yêu Cầu Sửa Chữa
/// Quản lý tạo, cập nhật, xóa yêu cầu sửa chữa tài sản KTX
/// </summary>
public interface IYeuCauSuaChuaService : IBaseService<YeuCauSuaChua>
{
    /// <summary>
    /// Lấy danh sách yêu cầu sửa chữa với phân trang và filter
    /// </summary>
    /// <param name="request">Thông tin phân trang (page, pageSize)</param>
    /// <param name="phongKtxId">Lọc theo phòng KTX (tùy chọn)</param>
    /// <param name="sinhVienId">Lọc theo sinh viên (tùy chọn)</param>
    /// <param name="trangThai">Lọc theo trạng thái (tùy chọn): MoiGui, DangXuLy, DaXong, Huy</param>
    /// <param name="searchTerm">Tìm kiếm theo tiêu đề, nội dung (tùy chọn)</param>
    /// <returns>Response chứa danh sách và tổng số bản ghi</returns>
    Task<Result<YeuCauSuaChuaPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        Guid? sinhVienId = null,
        string? trangThai = null,
        string? searchTerm = null);

    /// <summary>
    /// Tạo yêu cầu sửa chữa mới
    /// - Trạng thái ban đầu: "MoiGui"
    /// - Nếu có chọn tài sản, tự động cập nhật tài sản sang "CầnSửaChữa"
    /// </summary>
    /// <param name="dto">Thông tin yêu cầu sửa chữa cần tạo</param>
    /// <returns>ID của yêu cầu vừa tạo</returns>
    Task<Result<Guid>> CreateYeuCauAsync(CreateYeuCauSuaChuaDto dto);

    /// <summary>
    /// Cập nhật trạng thái yêu cầu sửa chữa
    /// - Nếu chuyển sang "DaXong": Tài sản → "Tốt"
    /// - Nếu chuyển sang "Huy": Tài sản → "Hỏng"
    /// - Nếu chuyển sang "DangXuLy": Tài sản → "CầnSửaChữa" (giữ nguyên)
    /// </summary>
    /// <param name="dto">Thông tin cập nhật (ID, trạng thái mới, ghi chú)</param>
    /// <returns>Kết quả thành công/thất bại</returns>
    Task<Result<bool>> UpdateTrangThaiAsync(UpdateYeuCauSuaChuaDto dto);
}