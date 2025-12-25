using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;

namespace EMS.Application.Services.NamHocServices;

public class NamHocService : BaseService<NamHoc>, INamHocService
{
    public NamHocService(IUnitOfWork unitOfWork, INamHocRepository namHocRepository)
        : base(unitOfWork, namHocRepository)
    {
    }

    protected override Task UpdateEntityProperties(NamHoc existingEntity, NamHoc newEntity)
    {
        existingEntity.NamHocValue = newEntity.NamHocValue;
        existingEntity.NienHoc = newEntity.NienHoc;
        existingEntity.IsVisible = newEntity.IsVisible;
        existingEntity.TuNgay = newEntity.TuNgay;
        existingEntity.DenNgay = newEntity.DenNgay;
        existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
        existingEntity.GhiChu = newEntity.GhiChu;
        existingEntity.SoTuan = newEntity.SoTuan;

        return Task.CompletedTask;
    }
    public override async Task<Result<NamHoc>> CreateAsync(NamHoc entity)
    {
        try
        {
            var existingNamHoc = await Repository.GetFirstAsync(nh => nh.NamHocValue.Trim() == entity.NamHocValue.Trim());
            if (existingNamHoc != null)
            {
                return new Result<NamHoc>(new Exception($"Năm học '{entity.NamHocValue}' đã tồn tại."));
            }
            Repository.Add(entity);
            await UnitOfWork.CommitAsync();
            return new Result<NamHoc>(entity);
        }
        catch (Exception ex)
        {
            return new Result<NamHoc>(ex);
        }
    }
    public override async Task<Result<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new Result<bool>(new NotFoundException($"Entity with ID '{id}' not found."));
            }
            var hocKyRepo = UnitOfWork.GetRepository<IHocKyRepository>();
            var relatedHocKy = await hocKyRepo.GetFirstAsync(hk => hk.IdNamHoc == id);
            if (relatedHocKy != null)
            {
                return new Result<bool>(new Exception($"Năm học '{entity.NamHocValue}' đang được sử dụng, không thể xóa."));
            }
            Repository.Delete(entity);
            await UnitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(ex);
        }
    }
    public override async Task<Result<bool>> DeleteMultipleAsync(List<Guid> ids)
    {
        try
        {
            var hocKyRepo = UnitOfWork.GetRepository<IHocKyRepository>();

            foreach (var id in ids)
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new Result<bool>(new NotFoundException($"Entity with ID '{id}' not found."));
                }

                var relatedHocKy = await hocKyRepo.GetFirstAsync(hk => hk.IdNamHoc == id);
                if (relatedHocKy != null)
                {
                    return new Result<bool>(
                        new Exception($"Năm học '{entity.NamHocValue}' đang được sử dụng, không thể xóa.")
                    );
                }

                Repository.Delete(entity);
            }

            await UnitOfWork.CommitAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(ex);
        }
    }

}