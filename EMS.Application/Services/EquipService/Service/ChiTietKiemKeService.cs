using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.EquipService.Service
{
    public class ChiTietKiemKeService : BaseService<TSTBChiTietKiemKe>, IChiTietKiemKeService
    {
        public ChiTietKiemKeService(
         IUnitOfWork unitOfWork,
         IChiTietKiemKeRepository repository)
         : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBChiTietKiemKe existingEntity, TSTBChiTietKiemKe newEntity)
        {
            existingEntity.TrangThaiSoSach = newEntity.TrangThaiSoSach;
            existingEntity.TrangThaiThucTe = newEntity.TrangThaiThucTe;
            existingEntity.KhopDot = newEntity.KhopDot;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}
