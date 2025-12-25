using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiSinhVienServices
{
    public class LoaiSinhVienService : BaseService<LoaiSinhVien>, ILoaiSinhVienService
    {
        public LoaiSinhVienService(IUnitOfWork unitOfWork, ILoaiSinhVienRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiSinhVien existingEntity, LoaiSinhVien newEntity)
        {
            // Map all properties from newEntity to existingEntity
            // Note: Additional properties will be mapped when entity properties are confirmed
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
    }
}
