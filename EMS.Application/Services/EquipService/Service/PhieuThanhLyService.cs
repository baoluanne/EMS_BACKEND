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
    public class PhieuThanhLyService : BaseService<TSTBPhieuThanhLy>, IPhieuThanhLyService
    {
        public PhieuThanhLyService(
            IUnitOfWork unitOfWork,
            IPhieuThanhLyRepository repository)
            : base(unitOfWork, repository) 
        {
        }
        protected override Task UpdateEntityProperties(TSTBPhieuThanhLy existingEntity, TSTBPhieuThanhLy newEntity)
        {
            existingEntity.NgayThanhLy = newEntity.NgayThanhLy;
            existingEntity.LyDo = newEntity.LyDo;
            existingEntity.TongTienThuHoi = newEntity.TongTienThuHoi;
            return Task.CompletedTask;
        }
    }
}
