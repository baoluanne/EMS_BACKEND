using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HocKyServices
{
    public class HocKyService : BaseService<HocKy>, IHocKyService
    {
        public HocKyService(IUnitOfWork unitOfWork, IHocKyRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(HocKy existingEntity, HocKy newEntity)
        {
            existingEntity.IdNamHoc = newEntity.IdNamHoc;
            existingEntity.TenDot = newEntity.TenDot;
            existingEntity.SoThuTu = newEntity.SoThuTu;
            existingEntity.SoTuan = newEntity.SoTuan;
            existingEntity.HeSo = newEntity.HeSo;
            existingEntity.TuThang = newEntity.TuThang;
            existingEntity.DenThang = newEntity.DenThang;
            existingEntity.NamHanhChinh = newEntity.NamHanhChinh;
            existingEntity.TuNgay = newEntity.TuNgay;
            existingEntity.DenNgay = newEntity.DenNgay;
            existingEntity.TenDayDu = newEntity.TenDayDu;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsActive = newEntity.IsActive;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.IsDKHP = newEntity.IsDKHP;
            existingEntity.IsDKNTTT = newEntity.IsDKNTTT;
            return Task.CompletedTask;
        }
    }
} 