using EMS.Application.Services.Base;
using EMS.Application.Services.ChuongTrinhKhungNienCheServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;
using LanguageExt.Pipes;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.ChuongTrinhKhungNienCheServices
{
    public class ChuongTrinhKhungNienCheService : BaseService<ChuongTrinhKhungNienChe>, IChuongTrinhKhungNienCheService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChuongTrinhKhungNienCheRepository _repository;

        public ChuongTrinhKhungNienCheService(IUnitOfWork unitOfWork, IChuongTrinhKhungNienCheRepository repository) 
            : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(ChuongTrinhKhungNienChe existingEntity, ChuongTrinhKhungNienChe newEntity)
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

            return Task.CompletedTask;
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