using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class ToaNhaKtxService : BaseService<ToaNhaKtx>, IToaNhaKtxService
    {
        private readonly IToaNhaKtxRepository _toaNhaRepository;

        public ToaNhaKtxService(
            IUnitOfWork unitOfWork,
            IToaNhaKtxRepository toaNhaRepository)
            : base(unitOfWork, toaNhaRepository)
        {
            _toaNhaRepository = toaNhaRepository;
        }

        public async Task<Result<ToaNhaKtxPagingResponse>> GetPaginatedAsync(PaginationRequest request)
        {
            try
            {
                var (data, total) = await _toaNhaRepository.GetPaginatedWithDetailsAsync(request);
                return new Result<ToaNhaKtxPagingResponse>(new ToaNhaKtxPagingResponse { Data = data, Total = total });
            }
            catch (Exception ex)
            {
                return new Result<ToaNhaKtxPagingResponse>(ex);
            }
        }

        protected override Task UpdateEntityProperties(ToaNhaKtx existingEntity, ToaNhaKtx newEntity)
        {
            existingEntity.TenToaNha = newEntity.TenToaNha;
            existingEntity.LoaiToaNha = newEntity.LoaiToaNha;
            return Task.CompletedTask;
        }
    }
}