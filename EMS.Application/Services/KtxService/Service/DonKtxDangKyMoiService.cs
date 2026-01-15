using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonKtxDangKyMoiService : BaseService<KtxDonDangKyMoi>, IDonKtxDangKyMoiService
    {
        private readonly IDonDangKyMoiRepository _repository;

        public DonKtxDangKyMoiService(IUnitOfWork unitOfWork, IDonDangKyMoiRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDonDangKyMoi existingEntity, KtxDonDangKyMoi newEntity)
        {
            existingEntity.PhongYeuCauId = newEntity.PhongYeuCauId;
            existingEntity.LyDo = newEntity.LyDo;
            return Task.CompletedTask;
        }
    }
}