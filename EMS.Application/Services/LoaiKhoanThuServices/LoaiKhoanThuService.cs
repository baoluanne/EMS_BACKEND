using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiKhoanThuServices
{
    public class LoaiKhoanThuService : BaseService<LoaiKhoanThu>, ILoaiKhoanThuService
    {
        public LoaiKhoanThuService(IUnitOfWork unitOfWork, ILoaiKhoanThuRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiKhoanThu existingEntity, LoaiKhoanThu newEntity)
        {
            // Map all properties from newEntity to existingEntity
            // Note: Additional properties will be mapped when entity properties are confirmed
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
    }
}
