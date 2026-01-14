using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService;

public class YeuCauSuaChuaService : BaseService<KtxYeuCauSuaChua>, IYeuCauSuaChuaService
{
    private readonly IYeuCauSuaChuaRepository _yeuCauRepository;
    private readonly ITaiSanKtxRepository _taiSanRepository;
    private readonly ILogger<YeuCauSuaChuaService> _logger;

    public YeuCauSuaChuaService(
        IUnitOfWork unitOfWork,
        IYeuCauSuaChuaRepository yeuCauRepository,
        ITaiSanKtxRepository taiSanRepository,
        ILogger<YeuCauSuaChuaService> logger)
        : base(unitOfWork, yeuCauRepository)
    {
        _yeuCauRepository = yeuCauRepository;
        _taiSanRepository = taiSanRepository;
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
            var entity = new KtxYeuCauSuaChua
            {
                TieuDe = dto.TieuDe,
                NoiDung = dto.NoiDung,
                TrangThai = "MoiGui",
                SinhVienId = dto.SinhVienId,
                PhongKtxId = dto.PhongKtxId,
                TaiSanKtxId = dto.TaiSanKtxId,
                NgayGui = EnsureUtcDateTime(dto.NgayGui)
            };

            _yeuCauRepository.Add(entity);
            await UnitOfWork.CommitAsync();

            if (dto.TaiSanKtxId.HasValue)
            {
                await UpdateAssetStatusAsync(dto.TaiSanKtxId.Value, "CầnSửaChữa");
                _logger.LogInformation(
                    $"Cập nhật tài sản {dto.TaiSanKtxId} sang 'CầnSửaChữa' cho yêu cầu {entity.Id}");
            }

            _logger.LogInformation($"Tạo yêu cầu sửa chữa {entity.Id} thành công");
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
                return new Result<bool>(new Exception("Không tìm thấy yêu cầu sửa chữa"));

            if (entity.NgayHoanThanh.HasValue)
                return new Result<bool>(new Exception("Yêu cầu đã hoàn thành, không thể sửa"));

            string trangThaiCu = entity.TrangThai;

            entity.TrangThai = dto.TrangThai ?? trangThaiCu;
            entity.GhiChuXuLy = dto.GhiChuXuLy;

            if (dto.TrangThai == "DangXuLy")
            {
                entity.NgayXuLy = EnsureUtcDateTime(dto.NgayXuLy);
            }
            else if (dto.TrangThai == "DaXong")
            {
                entity.NgayHoanThanh = EnsureUtcDateTime(dto.NgayHoanThanh);
                if (!entity.NgayXuLy.HasValue)
                {
                    entity.NgayXuLy = EnsureUtcDateTime(dto.NgayXuLy);
                }
            }

            _yeuCauRepository.Update(entity);
            await UnitOfWork.CommitAsync();

            if (entity.TaiSanKtxId.HasValue && dto.TrangThai != trangThaiCu)
            {
                string tinhTrangMoi = GetAssetStatusFromRequestStatus(dto.TrangThai!);
                if (!string.IsNullOrEmpty(tinhTrangMoi))
                {
                    await UpdateAssetStatusAsync(entity.TaiSanKtxId.Value, tinhTrangMoi);
                    _logger.LogInformation(
                        $"Cập nhật tài sản {entity.TaiSanKtxId} sang '{tinhTrangMoi}' " +
                        $"do yêu cầu chuyển sang trạng thái '{dto.TrangThai}'");
                }
            }

            _logger.LogInformation($"Cập nhật yêu cầu {entity.Id} thành công");
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi cập nhật trạng thái yêu cầu sửa chữa");
            return new Result<bool>(ex);
        }
    }

    private string GetAssetStatusFromRequestStatus(string trangThai)
    {
        return trangThai switch
        {
            "DaXong" => "Tốt",
            "Huy" => "Hỏng",
            "DangXuLy" => "CầnSửaChữa",
            _ => null
        };
    }

    private async Task UpdateAssetStatusAsync(Guid taiSanId, string tinhTrang)
    {
        try
        {
            var taiSan = await _taiSanRepository.GetByIdAsync(taiSanId);
            if (taiSan != null)
            {
                taiSan.TinhTrang = tinhTrang;
                _taiSanRepository.Update(taiSan);
                await UnitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Lỗi cập nhật trạng thái tài sản {taiSanId}");
        }
    }
    private DateTime EnsureUtcDateTime(DateTime? dateTime)
    {
        if (dateTime == null)
            return DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

        if (dateTime.Value.Kind == DateTimeKind.Utc)
            return dateTime.Value;

        if (dateTime.Value.Kind == DateTimeKind.Unspecified)
            return DateTime.SpecifyKind(dateTime.Value, DateTimeKind.Utc);

        return dateTime.Value.ToUniversalTime();
    }

    protected override Task UpdateEntityProperties(KtxYeuCauSuaChua existing, KtxYeuCauSuaChua newEntity)
    {
        existing.TieuDe = newEntity.TieuDe;
        existing.NoiDung = newEntity.NoiDung;
        existing.TrangThai = newEntity.TrangThai;
        existing.GhiChuXuLy = newEntity.GhiChuXuLy;
        existing.NgayXuLy = newEntity.NgayXuLy;
        existing.NgayHoanThanh = newEntity.NgayHoanThanh;
        existing.ChiPhiPhatSinh = newEntity.ChiPhiPhatSinh;
        return Task.CompletedTask;
    }
}