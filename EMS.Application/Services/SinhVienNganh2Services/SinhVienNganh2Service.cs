using EMS.Application.Services.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.SinhVienNganh2Services
{
    public class SinhVienNganh2Service : BaseService<SinhVienNganh2>, ISinhVienNganh2Service
    {
        public SinhVienNganh2Service(IUnitOfWork unitOfWork, ISinhVienNganh2Repository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(SinhVienNganh2 existingEntity, SinhVienNganh2 newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdLopHoc2 = newEntity.IdLopHoc2;
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            existingEntity.NgayQuyetDinh = newEntity.NgayQuyetDinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.NguoiKy = newEntity.NguoiKy;

            return Task.CompletedTask;
        }

        public override async Task<Result<SinhVienNganh2>> CreateAsync(SinhVienNganh2 entity)
        {
            try
            {
                entity.IdKhoaHoc = entity.IdKhoaHoc2;
                Repository.Add(entity);
                await UnitOfWork.CommitAsync();
                return new Result<SinhVienNganh2>(entity);
            }
            catch (Exception ex)
            {
                return new Result<SinhVienNganh2>(ex);
            }
        }
    }
}