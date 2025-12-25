using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;

namespace EMS.Application.Services.QuyetDinhServices
{
    public class QuyetDinhService : BaseService<QuyetDinh>, IQuyetDinhService
    {
        public QuyetDinhService(IUnitOfWork unitOfWork, IQuyetDinhRepository repository)
            : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(QuyetDinh existingEntity, QuyetDinh updatedEntity)
        {
            existingEntity.SoQuyetDinh = updatedEntity.SoQuyetDinh;
            existingEntity.TenQuyetDinh = updatedEntity.TenQuyetDinh;
            existingEntity.NgayRaQuyetDinh = updatedEntity.NgayRaQuyetDinh;
            existingEntity.NgayKyQuyetDinh = updatedEntity.NgayKyQuyetDinh;
            existingEntity.NguoiRaQD = updatedEntity.NguoiRaQD;
            existingEntity.NguoiKyQD = updatedEntity.NguoiKyQD;
            existingEntity.NoiDung = updatedEntity.NoiDung;
            existingEntity.IdLoaiQuyetDinh = updatedEntity.IdLoaiQuyetDinh;

            return Task.CompletedTask;
        }

        public override async Task<Result<QuyetDinh>> CreateAsync(QuyetDinh entity)
        {
            try
            {
                var existingEntity = await Repository.GetFirstAsync(qd => qd.SoQuyetDinh == entity.SoQuyetDinh);
                if (existingEntity != null)
                {
                    return new Result<QuyetDinh>(new Exception($"Số quyết định '{entity.SoQuyetDinh}' đã tồn tại."));
                }
                Repository.Add(entity);
                await UnitOfWork.CommitAsync();
                return new Result<QuyetDinh>(entity);
            }
            catch (Exception ex)
            {
                return new Result<QuyetDinh>(ex.InnerException ?? ex);
            }
        }

        // TODO: Implement ImportAsync method if needed
        // public async Task<ImportResult> ImportAsync(IFormFile file)
        // {
        //     // Implementation for importing QuyetDinh data
        //     throw new NotImplementedException();
        // }
    }
}