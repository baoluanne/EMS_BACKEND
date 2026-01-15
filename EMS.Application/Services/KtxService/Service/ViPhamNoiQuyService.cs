using EMS.Application.Services.Base;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class ViPhamNoiQuyService : BaseService<KtxViPhamNoiQuy>, IViPhamNoiQuyKTXService
    {
        private readonly IViPhamNoiQuyKTXRepository _repository;

        public ViPhamNoiQuyService(IUnitOfWork unitOfWork, IViPhamNoiQuyKTXRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxViPhamNoiQuy existingEntity, KtxViPhamNoiQuy newEntity)
        {
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.NoiDungViPham = newEntity.NoiDungViPham;
            existingEntity.HinhThucXuLy = newEntity.HinhThucXuLy;
            existingEntity.DiemTru = newEntity.DiemTru;
            existingEntity.NgayViPham = newEntity.NgayViPham;
            return Task.CompletedTask;
        }
    }
}