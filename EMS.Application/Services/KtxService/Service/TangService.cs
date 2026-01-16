using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class TangService : BaseService<KtxTang>, ITangService
    {
        private readonly ITangRepository _repository;

        public TangService(IUnitOfWork unitOfWork, ITangRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxTang existingEntity, KtxTang newEntity)
        {
            existingEntity.ToaNhaId = newEntity.ToaNhaId;
            existingEntity.TenTang = newEntity.TenTang;
            existingEntity.LoaiTang = newEntity.LoaiTang;
            existingEntity.SoLuongPhong = newEntity.SoLuongPhong;
            return Task.CompletedTask;
        }
    }
}