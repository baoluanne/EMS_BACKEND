using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService;

public class TaiSanKtxService : BaseService<TaiSanKtx>, ITaiSanKtxService
{
    private readonly ITaiSanKtxRepository _taiSanRepository;
    private readonly ILogger<TaiSanKtxService> _logger;

    public TaiSanKtxService(
        IUnitOfWork unitOfWork,
        ITaiSanKtxRepository taiSanRepository,
        ILogger<TaiSanKtxService> logger)
        : base(unitOfWork, taiSanRepository)
    {
        _taiSanRepository = taiSanRepository;
        _logger = logger;
    }

    public async Task<Result<TaiSanKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        string? tinhTrang = null,
        string? searchTerm = null)
    {
        try
        {
            var (data, total) = await _taiSanRepository.GetPaginatedWithDetailsAsync(
                request, phongKtxId, tinhTrang, searchTerm);

            return new Result<TaiSanKtxPagingResponse>(
                new TaiSanKtxPagingResponse { Data = data, Total = total });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi lấy danh sách tài sản KTX");
            return new Result<TaiSanKtxPagingResponse>(ex);
        }
    }

    public async Task<Result<Guid>> CreateTaiSanAsync(CreateTaiSanKtxDto dto)
    {
        try
        {
            var entity = new TaiSanKtx
            {
                MaTaiSan = dto.MaTaiSan,
                TenTaiSan = dto.TenTaiSan,
                TinhTrang = dto.TinhTrang,
                GiaTri = dto.GiaTri,
                GhiChu = dto.GhiChu,
                PhongKtxId = dto.PhongKtxId
            };

            _taiSanRepository.Add(entity);
            await UnitOfWork.CommitAsync();

            return new Result<Guid>(entity.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi tạo tài sản KTX");
            return new Result<Guid>(ex);
        }
    }

    public async Task<Result<bool>> UpdateTaiSanAsync(UpdateTaiSanKtxDto dto)
    {
        try
        {
            var entity = await _taiSanRepository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new Result<bool>(new Exception("Không tìm thấy tài sản"));

            entity.MaTaiSan = dto.MaTaiSan;
            entity.TenTaiSan = dto.TenTaiSan;
            entity.TinhTrang = dto.TinhTrang;
            entity.GiaTri = dto.GiaTri;
            entity.GhiChu = dto.GhiChu;
            entity.PhongKtxId = dto.PhongKtxId;

            _taiSanRepository.Update(entity);
            await UnitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi cập nhật tài sản KTX");
            return new Result<bool>(ex);
        }
    }

    protected override Task UpdateEntityProperties(TaiSanKtx existing, TaiSanKtx newEntity)
    {
        existing.MaTaiSan = newEntity.MaTaiSan;
        existing.TenTaiSan = newEntity.TenTaiSan;
        existing.TinhTrang = newEntity.TinhTrang;
        existing.GiaTri = newEntity.GiaTri;
        existing.GhiChu = newEntity.GhiChu;
        existing.PhongKtxId = newEntity.PhongKtxId;
        return Task.CompletedTask;
    }
}