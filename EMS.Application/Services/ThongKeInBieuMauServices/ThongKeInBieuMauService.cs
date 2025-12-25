using EMS.Application.Services.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;

namespace EMS.Application.Services.ThongKeInBieuMauServices
{
    public class ThongKeInBieuMauService : BaseService<ThongKeInBieuMau>, IThongKeInBieuMauService
    {
        public ThongKeInBieuMauService(
            IUnitOfWork unitOfWork,
            IThongKeInBieuMauRepository thongKeInBieuMauRepository) : base(unitOfWork, thongKeInBieuMauRepository)
        {
        }

        protected override async Task UpdateEntityProperties(ThongKeInBieuMau entity, ThongKeInBieuMau entityFromDb)
        {
            entityFromDb.IdBieuMau = entity.IdBieuMau;
            entityFromDb.IdNguoiIn = entity.IdNguoiIn;
            entityFromDb.NgayIn = entity.NgayIn;
            entityFromDb.GhiChu = entity.GhiChu;
            
            await Task.CompletedTask;
        }
    }
}