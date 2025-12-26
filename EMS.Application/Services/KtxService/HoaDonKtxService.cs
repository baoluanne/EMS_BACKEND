using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService;

public class HoaDonKtxService : BaseService<HoaDonKtx>, IHoaDonKtxService
{
    private readonly IHoaDonKtxRepository _hoaDonRepository;
    private readonly ILogger<HoaDonKtxService> _logger;

    public HoaDonKtxService(
        IUnitOfWork unitOfWork,
        IHoaDonKtxRepository hoaDonRepository,
        ILogger<HoaDonKtxService> logger)
        : base(unitOfWork, hoaDonRepository)
    {
        _hoaDonRepository = hoaDonRepository;
        _logger = logger;
    }

    public async Task<Result<HoaDonKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        int? thang = null,
        int? nam = null,
        string? trangThai = null)
    {
        try
        {
            var (data, total) = await _hoaDonRepository.GetPaginatedWithDetailsAsync(
                request, phongKtxId, thang, nam, trangThai);

            return new Result<HoaDonKtxPagingResponse>(
                new HoaDonKtxPagingResponse { Data = data, Total = total });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi lấy danh sách hóa đơn KTX");
            return new Result<HoaDonKtxPagingResponse>(ex);
        }
    }

    public async Task<Result<Guid>> CreateHoaDonAsync(CreateHoaDonKtxDto dto)
    {
        try
        {
            var entity = new HoaDonKtx
            {
                Thang = dto.Thang,
                Nam = dto.Nam,
                TienDien = dto.TienDien,
                TienNuoc = dto.TienNuoc,
                TongTien = dto.TongTien,
                TrangThai = "ChuaThanhToan",
                PhongKtxId = dto.PhongKtxId,
                ChiSoDienNuocId = dto.ChiSoDienNuocId
            };

             _hoaDonRepository.Add(entity);
            await UnitOfWork.CommitAsync();

            return new Result<Guid>(entity.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi tạo hóa đơn KTX");
            return new Result<Guid>(ex);
        }
    }

    public async Task<Result<bool>> ThanhToanHoaDonAsync(Guid id, string? ghiChu = null)
    {
        try
        {
            var entity = await _hoaDonRepository.GetByIdAsync(id);
            if (entity == null)
                return new Result<bool>(new Exception("Không tìm thấy hóa đơn"));

            if (entity.TrangThai != "ChuaThanhToan")
                return new Result<bool>(new Exception("Hóa đơn không ở trạng thái chờ thanh toán"));

            entity.TrangThai = "DaThanhToan";
            entity.NgayThanhToan = DateTime.UtcNow;
            entity.GhiChu = ghiChu ?? entity.GhiChu;

            _hoaDonRepository.Update(entity);
            await UnitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi thanh toán hóa đơn KTX");
            return new Result<bool>(ex);
        }
    }

    protected override Task UpdateEntityProperties(HoaDonKtx existing, HoaDonKtx newEntity)
    {
        existing.Thang = newEntity.Thang;
        existing.Nam = newEntity.Nam;
        existing.TienDien = newEntity.TienDien;
        existing.TienNuoc = newEntity.TienNuoc;
        existing.TongTien = newEntity.TongTien;
        existing.TrangThai = newEntity.TrangThai;
        existing.NgayThanhToan = newEntity.NgayThanhToan;
        existing.GhiChu = newEntity.GhiChu;
        return Task.CompletedTask;
    }
}