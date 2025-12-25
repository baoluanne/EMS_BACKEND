using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TieuChiTuyenSinhServices
{
    public class TieuChiTuyenSinhService : BaseService<TieuChiTuyenSinh>, ITieuChiTuyenSinhService
    {
        public TieuChiTuyenSinhService(IUnitOfWork unitOfWork, ITieuChiTuyenSinhRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(TieuChiTuyenSinh existingEntity, TieuChiTuyenSinh newEntity)
        {
            // Map all properties from newEntity to existingEntity
            // Note: Additional properties will be mapped when entity properties are confirmed
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
    }
}
