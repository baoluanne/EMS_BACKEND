using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienDangKiHocPhanServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.SinhVienDangKiHocPhanServices
{
    public class SinhVienDangKiHocPhanService : BaseService<SinhVienDangKiHocPhan>, ISinhVienDangKiHocPhanService
    {
        public SinhVienDangKiHocPhanService(IUnitOfWork unitOfWork, ISinhVienDangKiHocPhanRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(SinhVienDangKiHocPhan existingEntity, SinhVienDangKiHocPhan newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdLopHocPhan = newEntity.IdLopHocPhan;
            existingEntity.TrangThaiDangKyLHP = newEntity.TrangThaiDangKyLHP;
            existingEntity.HocPhi = newEntity.HocPhi;
            existingEntity.NguonDangKy = newEntity.NguonDangKy;

            return Task.CompletedTask;
        }

        public virtual async Task<Result<PaginationResponse<SinhVienDangKiHocPhan>>> GetSinhVienDangKyHocPhanPaginatedAsync(PaginationRequest request,
        SinhVienDangKiHocPhanFilterRequestDto filter)
        {
            try
            {
                Expression<Func<SinhVienDangKiHocPhan, bool>> filterExpression = q => true;
                if (filter.IdHocKy != null)
                {
                    filterExpression = filterExpression.And(q => q.LopHocPhan!.IdHocKy == filter.IdHocKy);
                }
                if (filter.IdLopHocPhan != null)
                {
                    filterExpression = filterExpression.And(q => q.IdLopHocPhan == filter.IdLopHocPhan);
                }
                if (!string.IsNullOrEmpty(filter.MaLHP))
                {
                    filterExpression = filterExpression.And(q => q.LopHocPhan!.MaLopHocPhan.Contains(filter.MaLHP));
                }
                if (!string.IsNullOrEmpty(filter.TenLHP))
                {
                    filterExpression = filterExpression.And(q => q.LopHocPhan!.TenLopHocPhan.Contains(filter.TenLHP));
                }
                if (filter.TrangThaiDangKyLHP != null)
                {
                    filterExpression = filterExpression.And(q => filter.TrangThaiDangKyLHP.Contains(q.TrangThaiDangKyLHP));
                }
                if (filter.HocPhi != null)
                {
                    filterExpression = filterExpression.And(q => q.HocPhi == filter.HocPhi);
                }
                if (filter.TrangThaiSinhVien != null)
                {
                    filterExpression = filterExpression.And(q => q.SinhVien!.TrangThai == filter.TrangThaiSinhVien);
                }
                if (filter.Nhom != null && filter.Nhom != 0)
                {
                    filterExpression = filterExpression.And(q => q.Nhom == filter.Nhom);
                }

                IQueryable<SinhVienDangKiHocPhan> includeFunc(IQueryable<SinhVienDangKiHocPhan> q)
                {
                    return q.Include(x => x.SinhVien)
                            .Include(x => x.LopHocPhan)
                            .Include(x => x.NguoiDangKy);
                }

                var result = await Repository.PaginateAsync(request, include: includeFunc, filter: filterExpression);

                return new Result<PaginationResponse<SinhVienDangKiHocPhan>>(result);
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<SinhVienDangKiHocPhan>>(ex);
            }
        }
    }
}