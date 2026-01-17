using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonRoiService : BaseService<KtxDonRoiKtx>, IDonRoiService
    {
        private readonly IDonRoiKtxRepository _repository;

        public DonRoiService(IUnitOfWork unitOfWork, IDonRoiKtxRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDonRoiKtx existingEntity, KtxDonRoiKtx newEntity)
        {
            existingEntity.PhongHienTaiId = newEntity.PhongHienTaiId;
            existingEntity.GiuongHienTaiId = newEntity.GiuongHienTaiId;
            existingEntity.LyDoRoi = newEntity.LyDoRoi;
            existingEntity.NgayRoiThucTe = newEntity.NgayRoiThucTe;
            return Task.CompletedTask;
        }
    }
}