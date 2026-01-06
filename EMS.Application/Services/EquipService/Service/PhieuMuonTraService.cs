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
    public class PhieuMuonTraService : BaseService<TSTBPhieuMuonTra>, IPhieuMuonTraService
    {
        public PhieuMuonTraService(
            IUnitOfWork unitOfWork,
            IPhieuMuonTraRepository repository)
            : base(unitOfWork, repository)
        {
        }
            protected override Task UpdateEntityProperties(TSTBPhieuMuonTra existingEntity, TSTBPhieuMuonTra newEntity)
        {
            existingEntity.LoaiDoiTuong = newEntity.LoaiDoiTuong;
            existingEntity.NgayMuon = newEntity.NgayMuon;
            existingEntity.NgayTraDuKien = newEntity.NgayTraDuKien;
            existingEntity.NgayTraThucTe = newEntity.NgayTraThucTe;
            existingEntity.LyDoMuon = newEntity.LyDoMuon;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}
