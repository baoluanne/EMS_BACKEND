using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService;

public class GiuongKtxService(
    IUnitOfWork unitOfWork,
    IGiuongKtxRepository giuongRepository,
    IPhongKtxRepository phongRepository)
    : BaseService<KtxGiuong>(unitOfWork, giuongRepository), IGiuongKtxService
{
    public async Task<Result<GiuongKtxPagingResponse>> GetPaginatedAsync(PaginationRequest request,
        string? maGiuong = null,
        string? phongKtxId = null,
        string? trangThai = null)
    {
        try
        {
            var (data, total) = await giuongRepository.GetPaginatedWithDetailsAsync(request, maGiuong, phongKtxId, trangThai);
            return new Result<GiuongKtxPagingResponse>(new GiuongKtxPagingResponse { data = data, total = total });
        }
        catch (Exception ex)
        {
            return new Result<GiuongKtxPagingResponse>(ex);
        }
    }
    public override async Task<Result<KtxGiuong>> CreateAsync(KtxGiuong entity)
    {
        try
        {
            var exits = await giuongRepository.GetFirstAsync(g => g.MaGiuong == entity.MaGiuong && !g.IsDeleted);
            if (exits != null)
            {
                return new Result<KtxGiuong>(new BadRequestException($"Mã Giường '{entity.MaGiuong}' đã tồn tại."));
            }
            var PhongKtx = await phongRepository.GetFirstAsync(g => g.Id == entity.PhongKtxId);
            if (PhongKtx != null)
            {
                PhongKtx.SoLuongGiuong += 1;
                phongRepository.Update(PhongKtx);
            }

            return await base.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            return new Result<KtxGiuong>(ex);
        }
    }

    public override async Task<Result<KtxGiuong>> UpdateAsync(Guid id, KtxGiuong entity)
    {
        try
        {
            var existingGiuong = await giuongRepository.GetByIdAsync(id);
            if (existingGiuong == null)
            {
                return new Result<KtxGiuong>(new NotFoundException("Không tìm thấy giường cần cập nhật."));
            }
            if (existingGiuong.MaGiuong != entity.MaGiuong)
            {
                var duplicate = await giuongRepository.GetFirstAsync(g => g.MaGiuong == entity.MaGiuong && g.Id != id && !g.IsDeleted);
                if (duplicate != null)
                {
                    return new Result<KtxGiuong>(new BadRequestException($"Mã giường '{entity.MaGiuong}' đã tồn tại ở một giường khác."));
                }
            })
            var result = await base.UpdateAsync(id, entity);

            if (result.IsSuccess)
            {
                await UnitOfWork.CommitAsync();
            }

            return result;
        }
        catch (Exception ex)
        {
            return new Result<KtxGiuong>(ex);
        }
    }

    protected override Task UpdateEntityProperties(KtxGiuong existingEntity, KtxGiuong newEntity)
    {
        existingEntity.MaGiuong = newEntity.MaGiuong;
        existingEntity.TrangThai = newEntity.TrangThai;
        return Task.CompletedTask;
    }
}