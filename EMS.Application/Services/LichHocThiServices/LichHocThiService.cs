using EMS.Application.Services.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;

namespace EMS.Application.Services.LichHocThiServices
{
    public class LichHocThiService : BaseService<LichHocThi>, ILichHocThiService
    {
        public LichHocThiService(IUnitOfWork unitOfWork, ILichHocThiRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(LichHocThi existingEntity, LichHocThi newEntity)
        {
            existingEntity.IdDotHoc = newEntity.IdDotHoc;
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.LoaiLich = newEntity.LoaiLich;
            existingEntity.IdLopHocPhan = newEntity.IdLopHocPhan;
            existingEntity.NgayThi = newEntity.NgayThi;
            existingEntity.TenPhong = newEntity.TenPhong;
            
            return Task.CompletedTask;
        }
    }
}