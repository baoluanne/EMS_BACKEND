using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.Bang_BangDiem_TNServices
{
    public class Bang_BangDiem_TNService : BaseService<Bang_BangDiem_TN>, IBang_BangDiem_TNService
    {
        public Bang_BangDiem_TNService(IUnitOfWork unitOfWork, IBang_BangDiem_TNRepository bang_BangDiem_TNRepository) 
            : base(unitOfWork, bang_BangDiem_TNRepository)
        {
        }

        protected override Task UpdateEntityProperties(Bang_BangDiem_TN existingEntity, Bang_BangDiem_TN newEntity)
        {
            existingEntity.MaBang_BangDiem = newEntity.MaBang_BangDiem;
            existingEntity.TenBang_BangDiem = newEntity.TenBang_BangDiem;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 