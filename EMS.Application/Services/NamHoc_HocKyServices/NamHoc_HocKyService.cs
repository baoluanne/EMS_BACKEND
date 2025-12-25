using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.NamHoc_HocKyServices
{
    public class NamHoc_HocKyService : BaseService<NamHoc_HocKy>, INamHoc_HocKyService
    {
        public NamHoc_HocKyService(IUnitOfWork unitOfWork, INamHoc_HocKyRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(NamHoc_HocKy existingEntity, NamHoc_HocKy newEntity)
        {
            existingEntity.TenDot = newEntity.TenDot;
            existingEntity.STT = newEntity.STT;
            existingEntity.SoTuan = newEntity.SoTuan;
            existingEntity.HeSo = newEntity.HeSo;
            existingEntity.IsActive = newEntity.IsActive;
            existingEntity.IsDangKyHP = newEntity.IsDangKyHP;
            existingEntity.IsDangKyNoiTruTT = newEntity.IsDangKyNoiTruTT;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.TuThang = newEntity.TuThang;
            existingEntity.DenThang = newEntity.DenThang;
            existingEntity.TuNgay = newEntity.TuNgay;
            existingEntity.DenNgay = newEntity.DenNgay;
            existingEntity.TenDayDu = newEntity.TenDayDu;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.NamHoc = newEntity.NamHoc;
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
} 