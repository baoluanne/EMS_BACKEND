using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.ChuongTrinhKhungNienCheServices.Dtos;
using EMS.Domain.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models;
using LanguageExt.Common;
using LanguageExt.Pipes;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.ChuongTrinhKhungTinChiServices
{
    public class ChuongTrinhKhungTinChiService(IUnitOfWork unitOfWork, IChuongTrinhKhungTinChiRepository repository) : BaseService<ChuongTrinhKhungTinChi>(unitOfWork, repository), IChuongTrinhKhungTinChiService
    {
        private IChuongTrinhKhungTinChiRepository _repository = repository;
        private IUnitOfWork _unitOfWork = unitOfWork;

        public Result<PaginationResponse<ChuongTrinhKhungTinChiResponseDto>> GetPaginatedWithLopHoc(PaginationRequest request,
            Expression<Func<ChuongTrinhKhungTinChi, bool>>? filters = null,
            Func<IQueryable<ChuongTrinhKhungTinChi>, IQueryable<ChuongTrinhKhungTinChi>>? include = null)
        {
            try
            {
                return _repository.GetPaginatedDtoResponse(request, filters, include);
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<ChuongTrinhKhungTinChiResponseDto>>(ex.InnerException ?? ex);
            }
        }
        public override async Task<Result<ChuongTrinhKhungTinChi>> UpdateAsync(Guid id, ChuongTrinhKhungTinChi entity)
        {
            try
            {
                var existingEntity = await _repository.GetFirstAsync(x => x.Id == id, q => q.Include(x => x.ChiTietKhungHocKy_TinChis));
                if (existingEntity == null)
                {
                    return new Result<ChuongTrinhKhungTinChi>(new NotFoundException($"Entity with ID {id} not found."));
                }

                await UpdateEntityProperties(existingEntity, entity);
                _repository.Update(existingEntity);
                await _unitOfWork.CommitAsync();

                return new Result<ChuongTrinhKhungTinChi>(existingEntity);
            }
            catch (Exception ex)
            {
                return new Result<ChuongTrinhKhungTinChi>(ex);
            }
        }

        protected override async Task UpdateEntityProperties(ChuongTrinhKhungTinChi existingEntity, ChuongTrinhKhungTinChi newEntity)
        {
            existingEntity.MaChuongTrinh = newEntity.MaChuongTrinh;
            existingEntity.TenChuongTrinh = newEntity.TenChuongTrinh;
            existingEntity.IsBlock = newEntity.IsBlock;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.GhiChuTiengAnh = newEntity.GhiChuTiengAnh;
            existingEntity.IdCoSoDaoTao = newEntity.IdCoSoDaoTao;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdNganhHoc = newEntity.IdNganhHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;

            SetEntityCollectionState(
                _unitOfWork.GetDbContext(),
                existingEntity.ChiTietKhungHocKy_TinChis,
                newEntity.ChiTietKhungHocKy_TinChis,
                getId: x => x.Id,
                copyProperties: (oldItem, newItem) =>
                {
                    oldItem.Id = newItem.Id;
                    oldItem.IdChuongTrinhKhung = newItem.IdChuongTrinhKhung;
                    oldItem.IdMonHocBacDaoTao = newItem.IdMonHocBacDaoTao;
                    oldItem.IsBatBuoc = newItem.IsBatBuoc;
                    oldItem.HocKy = newItem.HocKy;
                }
            );

            await Task.CompletedTask;
        }

        private static void SetEntityCollectionState(
            DbContext context,
            ICollection<ChiTietKhungHocKy_TinChi> oldItems,
            ICollection<ChiTietKhungHocKy_TinChi> newItems,
            Func<ChiTietKhungHocKy_TinChi, Guid> getId,
            Action<ChiTietKhungHocKy_TinChi, ChiTietKhungHocKy_TinChi>? copyProperties = null
        )
        {
            oldItems ??= new List<ChiTietKhungHocKy_TinChi>();
            newItems ??= new List<ChiTietKhungHocKy_TinChi>();

            var oldDict = oldItems.ToDictionary(getId);
            var newDict = newItems.ToDictionary(getId);

            // Add or Update
            foreach (var newItem in newDict.Values)
            {
                var id = getId(newItem);

                if (oldDict.TryGetValue(id, out var oldTrackedItem))
                {
                    // Update properties manually
                    copyProperties?.Invoke(oldTrackedItem, newItem);
                    context.Entry(oldTrackedItem).State = EntityState.Modified;
                }
                else
                {
                    // Add new (not tracked yet)
                    context.Entry(newItem).State = EntityState.Added;
                }
            }

            // Delete
            foreach (var oldItem in oldDict.Values)
            {
                var id = getId(oldItem);
                if (!newDict.ContainsKey(id))
                {
                    context.Entry(oldItem).State = EntityState.Deleted;
                }
            }
        }

        public async Task<Result<bool>> UpdateIsBlock(ChuongTrinhKhungIsBlockUpdate request)
        {
            var entity = await _repository.GetFirstAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                return new Result<bool>(new Exception("Không tìm thấy chương trình khung"));
            }

            entity.IsBlock = request.IsBlock;
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}