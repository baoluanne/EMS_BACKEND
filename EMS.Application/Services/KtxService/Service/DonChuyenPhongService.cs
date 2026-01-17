using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonChuyenPhongService : BaseService<KtxDonChuyenPhong>, IDonChuyenPhongService
    {
        private readonly IDonChuyenPhongRepository _repository;

        public DonChuyenPhongService(IUnitOfWork unitOfWork, IDonChuyenPhongRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDonChuyenPhong existingEntity, KtxDonChuyenPhong newEntity)
        {
            existingEntity.PhongHienTaiId = newEntity.PhongHienTaiId;
            existingEntity.GiuongHienTaiId = newEntity.GiuongHienTaiId;
            existingEntity.PhongYeuCauId = newEntity.PhongYeuCauId;
            existingEntity.LyDoChuyenPhong = newEntity.LyDoChuyenPhong;
            return Task.CompletedTask;
        }
    }
}