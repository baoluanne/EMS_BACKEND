using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiGiangVienServices
{
    public class LoaiGiangVienService : BaseService<LoaiGiangVien>, ILoaiGiangVienService
    {
        public LoaiGiangVienService(IUnitOfWork unitOfWork, ILoaiGiangVienRepository loaiGiangVienRepository) 
            : base(unitOfWork, loaiGiangVienRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiGiangVien existingEntity, LoaiGiangVien newEntity)
        {
            existingEntity.MaLoaiGiangVien = newEntity.MaLoaiGiangVien;
            existingEntity.TenLoaiGiangVien = newEntity.TenLoaiGiangVien;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 