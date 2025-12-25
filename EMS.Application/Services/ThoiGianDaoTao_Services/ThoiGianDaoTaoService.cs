using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ThoiGianDaoTao_Services;

public class ThoiGianDaoTaoService : BaseService<ThoiGianDaoTao>, IThoiGianDaoTaoService
{
    public ThoiGianDaoTaoService(IUnitOfWork unitOfWork, IThoiGianDaoTaoRepository thoiGianDaoTaoRepository) 
        : base(unitOfWork, thoiGianDaoTaoRepository)
    {
    }

    protected override Task UpdateEntityProperties(ThoiGianDaoTao existingEntity, ThoiGianDaoTao newEntity)
    {
        existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
        existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
        existingEntity.IdBangTotNghiep = newEntity.IdBangTotNghiep;
        existingEntity.IdBangDiemTN = newEntity.IdBangDiemTN;
        existingEntity.ThoiGianKeHoach = newEntity.ThoiGianKeHoach;
        existingEntity.ThoiGianToiThieu = newEntity.ThoiGianToiThieu;
        existingEntity.ThoiGianToiDa = newEntity.ThoiGianToiDa;
        existingEntity.GhiChu = newEntity.GhiChu;
        existingEntity.IDKhoiNganh = newEntity.IDKhoiNganh;
        existingEntity.HanCheDKHP = newEntity.HanCheDKHP;
        existingEntity.KyTuMaSV = newEntity.KyTuMaSV;
        existingEntity.HeSoDaoTao = newEntity.HeSoDaoTao;
        existingEntity.GiayBaoTrungTuyen = newEntity.GiayBaoTrungTuyen;
        
        return Task.CompletedTask;
    }
} 