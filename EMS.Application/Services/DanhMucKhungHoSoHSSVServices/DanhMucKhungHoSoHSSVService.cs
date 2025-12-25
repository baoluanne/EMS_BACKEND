using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucKhungHoSoHSSVServices
{
    public class DanhMucKhungHoSoHSSVService : BaseService<DanhMucKhungHoSoHSSV>, IDanhMucKhungHoSoHSSVService
    {
        public DanhMucKhungHoSoHSSVService(IUnitOfWork unitOfWork, IDanhMucKhungHoSoHSSVRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucKhungHoSoHSSV existingEntity, DanhMucKhungHoSoHSSV newEntity)
        {
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdHoSoHSSV = newEntity.IdHoSoHSSV;
            existingEntity.STT = newEntity.STT;
            existingEntity.IsBatBuoc = newEntity.IsBatBuoc;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdLoaiSinhVien = newEntity.IdLoaiSinhVien;

            return Task.CompletedTask;
        }
    }
}
