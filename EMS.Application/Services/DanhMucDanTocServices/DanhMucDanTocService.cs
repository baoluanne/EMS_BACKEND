using EMS.Application.Services.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Category;

namespace EMS.Application.Services.DanhMucDanTocServices
{
    public class DanhMucDanTocService : BaseService<DanhMucDanToc>, IDanhMucDanTocService
    {
        public DanhMucDanTocService(IUnitOfWork unitOfWork, IDanhMucDanTocRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucDanToc existingEntity, DanhMucDanToc newEntity)
        {
            existingEntity.MaDanToc = newEntity.MaDanToc;
            existingEntity.TenDanToc = newEntity.TenDanToc;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
