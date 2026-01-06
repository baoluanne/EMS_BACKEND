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
    public class DotKiemKeService : BaseService<TSTBDotKiemKe>, IDotKiemKeService
    {
        public DotKiemKeService(
            IUnitOfWork unitOfWork,
            IDotKiemKeRepository repository) : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBDotKiemKe existingEntity, TSTBDotKiemKe newEntity)
        {
            existingEntity.TenDotKiemKe = newEntity.TenDotKiemKe;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayKetThuc = newEntity.NgayKetThuc;
            existingEntity.DaHoanThanh = newEntity.DaHoanThanh;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}
