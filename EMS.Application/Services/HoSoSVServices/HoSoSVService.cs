using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HoSoSVServices
{
    public class HoSoSVService : BaseService<HoSoSV>, IHoSoSVService
    {
        public HoSoSVService(IUnitOfWork unitOfWork, IHoSoSVRepository repository)
            : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(HoSoSV existingEntity, HoSoSV updatedEntity)
        {
            existingEntity.MaHoSo = updatedEntity.MaHoSo;
            existingEntity.TenHoSo = updatedEntity.TenHoSo;
            existingEntity.LoaiHoSo = updatedEntity.LoaiHoSo;
            existingEntity.GhiChu = updatedEntity.GhiChu;
            return Task.CompletedTask;
        }

        // TODO: Implement ImportAsync method if needed
        // public async Task<ImportResult> ImportAsync(IFormFile file)
        // {
        //     // Implementation for importing HoSoSV data
        //     throw new NotImplementedException();
        // }
    }
}