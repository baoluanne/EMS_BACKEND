using EMS.Application.Services.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Category;

namespace EMS.Application.Services.DanhMucTonGiaoServices
{
    public class DanhMucTonGiaoService : BaseService<DanhMucTonGiao>, IDanhMucTonGiaoService
    {
        public DanhMucTonGiaoService(IUnitOfWork unitOfWork, IDanhMucTonGiaoRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucTonGiao existingEntity, DanhMucTonGiao newEntity)
        {
            existingEntity.MaTonGiao = newEntity.MaTonGiao;
            existingEntity.TenTonGiao = newEntity.TenTonGiao;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}