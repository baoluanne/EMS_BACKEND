using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.BangDiemChiTietServices
{
    public class BangDiemChiTietService : BaseService<BangDiemChiTiet>, IBangDiemChiTietService
    {
        public BangDiemChiTietService(IUnitOfWork unitOfWork, IBangDiemChiTietRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(BangDiemChiTiet existingEntity, BangDiemChiTiet newEntity)
        {
            return Task.CompletedTask;
        }
    }
}