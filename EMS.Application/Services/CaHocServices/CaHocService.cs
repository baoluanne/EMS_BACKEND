using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.ClassManagement;

namespace EMS.Application.Services.CaHocServices
{
    public class CaHocService : BaseService<CaHoc>, ICaHocService
    {
        public CaHocService(IUnitOfWork unitOfWork, ICaHocRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(CaHoc existingEntity, CaHoc newEntity)
        {
            // Map all properties from newEntity to existingEntity
            existingEntity.MaCaHoc = newEntity.MaCaHoc;
            existingEntity.TenCaHoc = newEntity.TenCaHoc;
            existingEntity.Thu = newEntity.Thu;
            existingEntity.Tiet = newEntity.Tiet;
            existingEntity.BuoiHoc = newEntity.BuoiHoc;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
        // public async Task<ImportResultResponse<CaHocImportDto>> ImportAsync(byte[] fileBytes)
        // {
        //     // Implementation for Excel import functionality
        // }
    }
}