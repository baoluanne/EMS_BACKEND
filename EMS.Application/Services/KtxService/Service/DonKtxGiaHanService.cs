using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonKtxGiaHanService : BaseService<KtxDonGiaHan>, IDonKtxGiaHanService
    {
        private readonly IDonGiaHanRepository _repository;

        public DonKtxGiaHanService(IUnitOfWork unitOfWork, IDonGiaHanRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDonGiaHan existingEntity, KtxDonGiaHan newEntity)
        {
            existingEntity.PhongHienTaiId = newEntity.PhongHienTaiId;
            existingEntity.GiuongHienTaiId = newEntity.GiuongHienTaiId;
            existingEntity.LyDo = newEntity.LyDo;
            return Task.CompletedTask;
        }
    }
}