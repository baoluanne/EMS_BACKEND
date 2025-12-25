using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HinhThucDaoTaoServices
{
    public class HinhThucDaoTaoService : BaseService<HinhThucDaoTao>, IHinhThucDaoTaoService
    {
        public HinhThucDaoTaoService(IUnitOfWork unitOfWork, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository) 
            : base(unitOfWork, hinhThucDaoTaoRepository)
        {
        }

        protected override Task UpdateEntityProperties(HinhThucDaoTao existingEntity, HinhThucDaoTao newEntity)
        {
            existingEntity.MaHinhThuc = newEntity.MaHinhThuc;
            existingEntity.TenHinhThuc = newEntity.TenHinhThuc;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 