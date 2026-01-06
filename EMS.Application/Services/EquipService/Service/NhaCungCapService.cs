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
    public class NhaCungCapService : BaseService<TSTBNhaCungCap>, INhaCungCapService
    {
        public NhaCungCapService(
        IUnitOfWork unitOfWork,
        INhaCungCapRepository repository)
            : base(unitOfWork, repository) 
        {
        }

        protected override Task UpdateEntityProperties(TSTBNhaCungCap existingEntity, TSTBNhaCungCap newEntity)
        {
            existingEntity.TenNhaCungCap = newEntity.TenNhaCungCap;
            existingEntity.DienThoai = newEntity.DienThoai;
            existingEntity.Email = newEntity.Email;
            existingEntity.DiaChi = newEntity.DiaChi;
            existingEntity.IsActive = newEntity.IsActive;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}
