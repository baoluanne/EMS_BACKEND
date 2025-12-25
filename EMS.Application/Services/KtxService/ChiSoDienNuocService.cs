using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService
{
    public class ChiSoDienNuocService : BaseService<ChiSoDienNuoc>, IChiSoDienNuocService
    {
        private readonly IChiSoDienNuocRepository _repository;
        private readonly ILogger<ChiSoDienNuocService> _logger;

        public ChiSoDienNuocService(
            IUnitOfWork unitOfWork,
            IChiSoDienNuocRepository repository,
            ILogger<ChiSoDienNuocService> logger)
            : base(unitOfWork, repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<ChiSoDienNuocPagingResponse>> GetPaginatedAsync(
            PaginationRequest request,
            Guid? toaNhaId = null,
            Guid? phongId = null,
            int? thang = null,
            int? nam = null,
            bool? daChot = null)
        {
            try
            {
                var (data, total) = await _repository.GetPaginatedWithDetailsAsync(
                    request, toaNhaId, phongId, thang, nam, daChot);

                return new Result<ChiSoDienNuocPagingResponse>(
                    new ChiSoDienNuocPagingResponse { Data = data, Total = total });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi lấy danh sách chỉ số điện nước");
                return new Result<ChiSoDienNuocPagingResponse>(ex);
            }
        }

        public ChiSoDienNuocCalculationResponse CalculateConsumption(
            double dienCu,
            double dienMoi,
            double nuocCu,
            double nuocMoi)
        {
            return new ChiSoDienNuocCalculationResponse
            {
                TieuThuDien = dienMoi - dienCu,
                TieuThuNuoc = nuocMoi - nuocCu
            };
        }

        protected override Task UpdateEntityProperties(ChiSoDienNuoc existingEntity, ChiSoDienNuoc newEntity)
        {
            // Không cho phép sửa nếu đã chốt
            if (existingEntity.DaChot)
                throw new InvalidOperationException("Không thể sửa bản ghi đã chốt");

            existingEntity.PhongKtxId = newEntity.PhongKtxId;
            existingEntity.Thang = newEntity.Thang;
            existingEntity.Nam = newEntity.Nam;
            existingEntity.DienCu = newEntity.DienCu;
            existingEntity.DienMoi = newEntity.DienMoi;
            existingEntity.NuocCu = newEntity.NuocCu;
            existingEntity.NuocMoi = newEntity.NuocMoi;
            existingEntity.DaChot = newEntity.DaChot;

            return Task.CompletedTask;
        }

 /*       public override async Task<Result<ChiSoDienNuoc>> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity?.DaChot == true)
                    return new Result<ChiSoDienNuoc>(
                        new InvalidOperationException("Không thể xóa bản ghi đã chốt"));

                return await base.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xóa chỉ số điện nước");
                return new Result<ChiSoDienNuoc>(ex);
            }
        }*/
    }
}