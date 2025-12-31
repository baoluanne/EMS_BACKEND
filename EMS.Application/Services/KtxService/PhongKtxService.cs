using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public class PhongKtxService(
    IUnitOfWork unitOfWork,
    IPhongKtxRepository phongRepository,
    IGiuongKtxRepository giuongRepository)
    : BaseService<PhongKtx>(unitOfWork, phongRepository), IPhongKtxService
{
    public override async Task<Result<PhongKtx>> CreateAsync(PhongKtx entity)
    {
        try
        {
            var existingPhong = await phongRepository.GetFirstAsync(p => p.MaPhong == entity.MaPhong && !p.IsDeleted);
            if (existingPhong != null)
            {
                return new Result<PhongKtx>(new BadRequestException($"Mã phòng '{entity.MaPhong}' đã tồn tại."));
            }
            if (entity.SoLuongGiuong > 0)
            {
                if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
                entity.GiuongKtxs ??= new List<GiuongKtx>();

                for (int i = 1; i <= entity.SoLuongGiuong; i++)
                {
                    var giuong = new GiuongKtx
                    {
                        Id = Guid.NewGuid(),
                        MaGiuong = $"{entity.MaPhong}-{i:00}",
                        PhongKtxId = entity.Id,
                        TrangThai = "Trong",
                        IsDeleted = false
                    };
                    giuongRepository.Add(giuong);
                }
            }

            return await base.CreateAsync(entity);

        }
        catch (Exception ex)
        {
            return new Result<PhongKtx>(ex);
        }
    }

    public async Task<Result<PhongKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        string? maPhong = null,
        string? toaNhaId = null,
        string? trangThai = null)
    {
        try
        {
            var (data, total) = await phongRepository.GetPaginatedWithDetailsAsync(request, maPhong, toaNhaId, trangThai);
            return new Result<PhongKtxPagingResponse>(new PhongKtxPagingResponse { data = data, total = total });
        }
        catch (Exception ex)
        {
            return new Result<PhongKtxPagingResponse>(ex);
        }
    }

    public override async Task<Result<PhongKtx>> UpdateAsync(Guid id, PhongKtx entity)
    {
        try
        {
            var existingPhong = await phongRepository.GetByIdAsync(id);
            if (existingPhong == null)
                return new Result<PhongKtx>(new NotFoundException("Không tìm thấy phòng"));

            if (entity.SoLuongGiuong < existingPhong.SoLuongDaO)
                return new Result<PhongKtx>(new BadRequestException(
                    $"Số lượng giường ({entity.SoLuongGiuong}) không thể nhỏ hơn số giường đã ở ({existingPhong.SoLuongDaO})"));

            if (entity.SoLuongGiuong > existingPhong.SoLuongGiuong)
            {
                int soGiuongCanThem = entity.SoLuongGiuong - existingPhong.SoLuongGiuong;
                int soGiuongHienTai = existingPhong.SoLuongGiuong;

                for (int i = 1; i <= soGiuongCanThem; i++)
                {
                    var giuongMoi = new GiuongKtx
                    {
                        Id = Guid.NewGuid(),
                        MaGiuong = $"{existingPhong.MaPhong}-{(soGiuongHienTai + i):00}",
                        PhongKtxId = id,
                        TrangThai = "TRONG"
                    };
                    giuongRepository.Add(giuongMoi);
                }
            }

            if (entity.SoLuongGiuong < existingPhong.SoLuongGiuong)
            {
                int soGiuongCanXoa = existingPhong.SoLuongGiuong - entity.SoLuongGiuong;
                var giuongTrong = await giuongRepository.GetListAsync(
                    g => g.PhongKtxId == id &&
                         g.TrangThai == "TRONG" &&
                         !g.IsDeleted);

                if (giuongTrong.Count < soGiuongCanXoa)
                    return new Result<PhongKtx>(new BadRequestException(
                        $"Không thể giảm số giường. Chỉ có {giuongTrong.Count} giường trống, cần {soGiuongCanXoa} để xóa"));

                var giuongCanXoa = giuongTrong.Take(soGiuongCanXoa).ToList();
                foreach (var giuong in giuongCanXoa)
                {
                    giuongRepository.Delete(giuong);
                }
            }

            var updateResult = await base.UpdateAsync(id, entity);
            if (updateResult.IsSuccess)
            {
                await UnitOfWork.CommitAsync();
            }
            return updateResult;
        }
        catch (Exception ex)
        {
            return new Result<PhongKtx>(ex);
        }
    }

    protected override Task UpdateEntityProperties(PhongKtx existingEntity, PhongKtx newEntity)
    {
        existingEntity.MaPhong = newEntity.MaPhong;
        existingEntity.ToaNhaId = newEntity.ToaNhaId;
        existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
        existingEntity.SoLuongDaO = newEntity.SoLuongDaO;
        existingEntity.TrangThai = newEntity.TrangThai;
        existingEntity.GiaPhong = newEntity.GiaPhong;
        return Task.CompletedTask;
    }
}