using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class GiuongKtxService : BaseService<GiuongKtx>, IGiuongKtxService
    {
        private readonly IGiuongKtxRepository _giuongRepository;
         private readonly IPhongKtxRepository _phongRepository;

        public GiuongKtxService(
           IUnitOfWork unitOfWork,
           IGiuongKtxRepository giuongRepository,
           IPhongKtxRepository phongRepository)
           : base(unitOfWork, giuongRepository)
        {
            _giuongRepository = giuongRepository;
            _phongRepository = phongRepository;
        }

        public override async Task<Result<GiuongKtx>> CreateAsync(GiuongKtx entity)
        {
            try
            {
                var createResult = await base.CreateAsync(entity);

                if (createResult.IsFaulted)
                {
                    return createResult;
                }
                var phong = await _phongRepository.GetByIdAsync(entity.PhongKtxId);
                if (phong != null)
                {
                    phong.SoLuongGiuong += 1;

                    _phongRepository.Update(phong);
                    await UnitOfWork.CommitAsync();
                }

                return createResult;
            }
            catch (Exception ex)
            {
                return new Result<GiuongKtx>(ex);
            }
        }

        public override async Task<Result<bool>> DeleteAsync(Guid id)
        {
            try
            {
                var giuong = await _giuongRepository.GetByIdAsync(id);
                if (giuong == null)
                {
                    return new Result<bool>(new Exception("Không tìm thấy giường"));
                }

                var phongId = giuong.PhongKtxId;

                var deleteResult = await base.DeleteAsync(id);

                if (deleteResult.IsFaulted)
                {
                    return deleteResult;
                }

                var phong = await _phongRepository.GetByIdAsync(phongId);
                if (phong != null && phong.SoLuongGiuong > 0)
                {
                    phong.SoLuongGiuong -= 1;
                    _phongRepository.Update(phong);
                    await UnitOfWork.CommitAsync();
                }

                return deleteResult;
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public override async Task<Result<GiuongKtx>> UpdateAsync(Guid id, GiuongKtx entity)
        {
            try
            {
                var existingGiuong = await _giuongRepository.GetByIdAsync(id);
                if (existingGiuong == null)
                {
                    return new Result<GiuongKtx>(new Exception("Không tìm thấy giường"));
                }

                var oldPhongId = existingGiuong.PhongKtxId;
                var newPhongId = entity.PhongKtxId;

                var updateResult = await base.UpdateAsync(id, entity);

                if (updateResult.IsFaulted)
                {
                    return updateResult;
                }

                if (oldPhongId != newPhongId)
                {
                    var oldPhong = await _phongRepository.GetByIdAsync(oldPhongId);
                    if (oldPhong != null && oldPhong.SoLuongGiuong > 0)
                    {
                        oldPhong.SoLuongGiuong -= 1;
                        _phongRepository.Update(oldPhong);
                    }

                    var newPhong = await _phongRepository.GetByIdAsync(newPhongId);
                    if (newPhong != null)
                    {
                        newPhong.SoLuongGiuong += 1;
                        _phongRepository.Update(newPhong);
                    }

                    await UnitOfWork.CommitAsync();
                }

                return updateResult;
            }
            catch (Exception ex)
            {
                return new Result<GiuongKtx>(ex);
            }
        }

        public async Task<Result<GiuongKtxPagingResponse>> GetPaginatedAsync(PaginationRequest request)
        {
            try
            {
                var (data, total) = await _giuongRepository.GetPaginatedWithDetailsAsync(request);
                return new Result<GiuongKtxPagingResponse>(new GiuongKtxPagingResponse { Data = data, Total = total });
            }
            catch (Exception ex)
            {
                return new Result<GiuongKtxPagingResponse>(ex);
            }
        }


        protected override Task UpdateEntityProperties(GiuongKtx existingEntity, GiuongKtx newEntity)
        {
            existingEntity.MaGiuong = newEntity.MaGiuong;
            existingEntity.PhongKtxId = newEntity.PhongKtxId;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.SinhVienId = newEntity.SinhVienId;
            return Task.CompletedTask;
        }
    }
}