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
    public class PhieuBaoTriService : BaseService<TSTBPhieuBaoTri>, IPhieuBaoTriService
    {
        public PhieuBaoTriService(
        IUnitOfWork unitOfWork,
        IPhieuBaoTriRepository repository)
            : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBPhieuBaoTri existingEntity, TSTBPhieuBaoTri newEntity)
        {
            existingEntity.LoaiBaoTri = newEntity.LoaiBaoTri;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayKetThuc = newEntity.NgayKetThuc;
            existingEntity.NoiDungBaoTri = newEntity.NoiDungBaoTri;
            existingEntity.KetQuaXuLy = newEntity.KetQuaXuLy;
            existingEntity.ChiPhi = newEntity.ChiPhi;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.HinhAnhUrl = newEntity.HinhAnhUrl;
            return Task.CompletedTask;
        }
    }
}
