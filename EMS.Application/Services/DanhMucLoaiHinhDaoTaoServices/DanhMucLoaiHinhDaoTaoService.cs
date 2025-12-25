using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucLoaiHinhDaoTaoServices;

public class DanhMucLoaiHinhDaoTaoService : BaseService<DanhMucLoaiHinhDaoTao>, IDanhMucLoaiHinhDaoTaoService
{
    public DanhMucLoaiHinhDaoTaoService(IUnitOfWork unitOfWork, IDanhMucLoaiHinhDaoTaoRepository danhMucLoaiHinhDaoTaoRepository)
            : base(unitOfWork, danhMucLoaiHinhDaoTaoRepository)
    {
    }

    protected override Task UpdateEntityProperties(DanhMucLoaiHinhDaoTao existingEntity, DanhMucLoaiHinhDaoTao newEntity)
    {
        existingEntity.MaLoaiDaoTao = newEntity.MaLoaiDaoTao;
        existingEntity.TenLoaiDaoTao = newEntity.TenLoaiDaoTao;
        existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
        existingEntity.SoThuTu = newEntity.SoThuTu;
        existingEntity.GhiChu = newEntity.GhiChu;
        existingEntity.IsVisible = newEntity.IsVisible;
        existingEntity.NoiDung = newEntity.NoiDung;
        return Task.CompletedTask;
    }
}
