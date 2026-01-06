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
    public class LoaiThietBiService : BaseService<TSTBLoaiThietBi>, ILoaiThietBiService
    {
        public LoaiThietBiService(
            IUnitOfWork unitOfWork,
            ILoaiThietBiRepository repository)
            : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBLoaiThietBi existingEntity, TSTBLoaiThietBi newEntity)
        {
            existingEntity.TenLoai = newEntity.TenLoai;
            existingEntity.MoTa = newEntity.MoTa;
            existingEntity.IsActive = newEntity.IsActive;
            return Task.CompletedTask;
        }
    }
}
