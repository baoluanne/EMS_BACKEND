using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.ChiTietKhungHocKy_TinChiServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.ChiTietKhungHocKy_TinChiServices
{
    public class ChiTietKhungHocKy_TinChiService : BaseService<ChiTietKhungHocKy_TinChi>, IChiTietKhungHocKy_TinChiService
    {
        public ChiTietKhungHocKy_TinChiService(IUnitOfWork unitOfWork, IChiTietKhungHocKy_TinChiRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override async Task UpdateEntityProperties(ChiTietKhungHocKy_TinChi existingEntity, ChiTietKhungHocKy_TinChi newEntity)
        {
            existingEntity.IsBatBuoc = newEntity.IsBatBuoc;
            existingEntity.IdChuongTrinhKhung = newEntity.IdChuongTrinhKhung;
            existingEntity.IdMonHocBacDaoTao = newEntity.IdMonHocBacDaoTao;
            existingEntity.HocKy = newEntity.HocKy;
            // Do not update navigation properties directly
            await Task.CompletedTask;
        }

        public async Task<Result<List<ChiTietKhungHocKy_TinChi>>> GetAllHocKyAsync()
        {
            try
            {
                var entities = await Repository.ListAsync();
                return new Result<List<ChiTietKhungHocKy_TinChi>>([.. entities.DistinctBy(x => x.HocKy)]);
            }
            catch (Exception ex)
            {
                return new Result<List<ChiTietKhungHocKy_TinChi>>(ex);
            }
        }

        public async Task<Result<PaginationResponse<ChiTietKhungHocKy_TinChi>>> GetChuongTrinhKhungMonHocPagination(
            PaginationRequest request,
            SinhVienMienMonHocFilterDto filter)
        {
            try
            {
                var predicates = new List<Expression<Func<ChiTietKhungHocKy_TinChi, bool>>>();

                if (filter.IdCoSo != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdCoSoDaoTao == filter.IdCoSo);
                if (filter.IdKhoaHoc != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdKhoaHoc == filter.IdKhoaHoc);
                if (filter.IdBacDaoTao != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdBacDaoTao == filter.IdBacDaoTao);
                if (filter.IdLoaiDaoTao != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdLoaiDaoTao == filter.IdLoaiDaoTao);
                if (filter.IdNganhHoc != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdNganhHoc == filter.IdNganhHoc);
                if (filter.IdChuyenNganh != null)
                    predicates.Add(q => q.ChuongTrinhKhungTinChi.IdChuyenNganh == filter.IdChuyenNganh);

                Expression<Func<ChiTietKhungHocKy_TinChi, bool>> filterExpression;

                if (predicates.Count == 0)
                {
                    filterExpression = q => false;
                }
                else
                {
                    filterExpression = predicates.Aggregate((a, b) => a.And(b));
                    if (filter.IdSinhVien.HasValue)
                    {
                        var svMienMonHocRepo = UnitOfWork.GetRepository<ISinhVienMienMonHocRepository>();
                        var mienMonHocList = await svMienMonHocRepo.GetListAsync(filter: x => x.IdSinhVien == filter.IdSinhVien.Value);
                        var mienMonHocIds = mienMonHocList.Select(x => x.IdMonHocBacDaoTao).ToList();
                        if (mienMonHocIds.Count > 0)
                        {
                            filterExpression = filterExpression.And(q => !mienMonHocIds.Contains(q.IdMonHocBacDaoTao));
                        }
                    }
                }
                var result = await GetPaginatedAsync(
                    request,
                    include: q => q.AsNoTracking()
                            .Include(x => x.MonHocBacDaoTao).ThenInclude(m => m.MonHoc),
                    filter: filterExpression
                );
                return result;
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<ChiTietKhungHocKy_TinChi>>(ex);
            }
        }
    }
}