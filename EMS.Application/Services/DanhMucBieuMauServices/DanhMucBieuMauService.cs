using EMS.Application.Services.Base;
using EMS.Application.Services.DanhMucBieuMauServices;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services
{
    public class DanhMucBieuMauService : BaseService<DanhMucBieuMau>, IDanhMucBieuMauService
    {
        public DanhMucBieuMauService(IUnitOfWork unitOfWork, IDanhMucBieuMauRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucBieuMau existingEntity, DanhMucBieuMau newEntity)
        {
            existingEntity.MaBieuMau = newEntity.MaBieuMau;
            existingEntity.TenBieuMau = newEntity.TenBieuMau;
            existingEntity.LoaiFile = newEntity.LoaiFile;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdKhoaQuanLy = newEntity.IdKhoaQuanLy;
            return Task.CompletedTask;
        }
    }
}


