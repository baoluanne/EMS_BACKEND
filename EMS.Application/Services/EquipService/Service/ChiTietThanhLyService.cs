using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;

namespace EMS.Application.Services.EquipService.Service
{
    public class ChiTietThanhLyService : BaseService<TSTBChiTietThanhLy>, IChiTietThanhLyService
    {
        public ChiTietThanhLyService(IUnitOfWork unitOfWork,IChiTietThanhLyRepository repository) : base(unitOfWork ,repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBChiTietThanhLy existingEntity, TSTBChiTietThanhLy newEntity)
        {
            existingEntity.GiaTriConLai = newEntity.GiaTriConLai;
            existingEntity.GiaBan = newEntity.GiaBan;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}
