using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucHoSoHSSVServices
{
    public class DanhMucHoSoHSSVService : BaseService<DanhMucHoSoHSSV>, IDanhMucHoSoHSSVService
    {
        public DanhMucHoSoHSSVService(IUnitOfWork unitOfWork, IDanhMucHoSoHSSVRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucHoSoHSSV existingEntity, DanhMucHoSoHSSV newEntity)
        {
            existingEntity.MaHoSo = newEntity.MaHoSo;
            existingEntity.TenHoSo = newEntity.TenHoSo;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
