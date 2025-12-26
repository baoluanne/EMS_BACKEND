using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService;

public class YeuCauSuaChuaService : BaseService<YeuCauSuaChua>, IYeuCauSuaChuaService
{
    private readonly IYeuCauSuaChuaRepository _yeuCauRepository;
    private readonly ILogger<YeuCauSuaChuaService> _logger;

    public YeuCauSuaChuaService(
        IUnitOfWork unitOfWork,
        IYeuCauSuaChuaRepository yeuCauRepository,
        ILogger<YeuCauSuaChuaService> logger)
        : base(unitOfWork, yeuCauRepository)
    {
        _yeuCauRepository = yeuCauRepository;
        _logger = logger;
    }

    public async Task<Result<YeuCauSuaChuaPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        Guid? sinhVienId = null,
        string? trangThai = null,
        string? searchTerm = null)
    {
        try
        {
            var (data, total) = await _yeuCauRepository.GetPaginatedWithDetailsAsync(
                request, phongKtxId, sinhVienId, trangThai, searchTerm);

            return new Result<YeuCauSuaChuaPagingResponse>(
                new YeuCauSuaChuaPagingResponse { Data = data, Total = total });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi lấy danh sách yêu cầu sửa chữa");
            return new Result<YeuCauSuaChuaPagingResponse>(ex);
        }
    }

    public async Task<Result<Guid>> CreateYeuCauAsync(CreateYeuCauSuaChuaDto dto)
    {
        try
        {
            var entity = new YeuCauSuaChua
            {
                TieuDe = dto.TieuDe,
                NoiDung = dto.NoiDung,
                TrangThai = "ChoXuLy",
                SinhVienId = dto.SinhVienId,
                PhongKtxId = dto.PhongKtxId,
                TaiSanKtxId = dto.TaiSanKtxId
            };

            _yeuCauRepository.Add(entity);
            await UnitOfWork.CommitAsync();

            return new Result<Guid>(entity.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi tạo yêu cầu sửa chữa");
            return new Result<Guid>(ex);
        }
    }

    public async Task<Result<bool>> UpdateTrangThaiAsync(UpdateYeuCauSuaChuaDto dto)
    {
        try
        {
            var entity = await _yeuCauRepository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new Result<bool>(new Exception("Không tìm thấy yêu cầu"));

            if (dto.TrangThai != null)
                entity.TrangThai = dto.TrangThai;

            entity.GhiChuXuLy = dto.GhiChuXuLy;
            entity.NgayXuLy = dto.NgayXuLy ?? DateTime.UtcNow;

            _yeuCauRepository.Update(entity);
            await UnitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi cập nhật trạng thái yêu cầu sửa chữa");
            return new Result<bool>(ex);
        }
    }

    protected override Task UpdateEntityProperties(YeuCauSuaChua existing, YeuCauSuaChua newEntity)
    {
        existing.TieuDe = newEntity.TieuDe;
        existing.NoiDung = newEntity.NoiDung;
        existing.TrangThai = newEntity.TrangThai;
        existing.GhiChuXuLy = newEntity.GhiChuXuLy;
        existing.NgayXuLy = newEntity.NgayXuLy;
        return Task.CompletedTask;
    }
}