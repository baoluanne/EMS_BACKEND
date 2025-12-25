using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ChuanDauRaServices;

public class ChuanDauRaService : BaseService<ChuanDauRa>, IChuanDauRaService
{
    public ChuanDauRaService(IUnitOfWork unitOfWork, IChuanDauRaRepository chuanDauRaRepository)
            : base(unitOfWork, chuanDauRaRepository)
    {
    }

    protected override Task UpdateEntityProperties(ChuanDauRa existingEntity, ChuanDauRa newEntity)
    {
        existingEntity.GhiChu = newEntity.GhiChu;
        existingEntity.IdChungChi = newEntity.IdChungChi;
        existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
        existingEntity.IdLoaiChungChi = newEntity.IdLoaiChungChi;
        existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
        existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
        existingEntity.IdCoSo = newEntity.IdCoSo;
        existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;

        return Task.CompletedTask;
    }
}
