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
    public class ChiTietPhieuMuonService : BaseService<TSTBChiTietPhieuMuon>, IChiTietPhieuMuonService
    {
        public ChiTietPhieuMuonService
            (IUnitOfWork unitOfWork,
            IChiTietPhieuMuonRepository repository) 
            : base(unitOfWork ,repository)
        {
        }

        protected override Task UpdateEntityProperties(TSTBChiTietPhieuMuon existingEntity, TSTBChiTietPhieuMuon newEntity)
        {
            existingEntity.TinhTrangKhiMuon = newEntity.TinhTrangKhiMuon;
            existingEntity.TinhTrangKhiTra = newEntity.TinhTrangKhiTra;
            existingEntity.GhiChuChiTiet = newEntity.GhiChuChiTiet;
            return Task.CompletedTask;
        }
    }

}
