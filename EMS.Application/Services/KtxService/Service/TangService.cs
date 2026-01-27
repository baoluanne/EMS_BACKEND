using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service
{
    public class TangService : BaseService<KtxTang>, ITangService
    {
        private readonly ITangRepository _repository;
        private readonly IToaNhaKtxRepository _toaNhaRepo;

        public TangService(IUnitOfWork unitOfWork, ITangRepository repository, IToaNhaKtxRepository toaNhaRepo)
            : base(unitOfWork, repository)
        {
            _repository = repository;
            _toaNhaRepo = toaNhaRepo;
        }

        public override async Task<Result<KtxTang>> CreateAsync(KtxTang entity)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entity.TenTang))
                {
                    return new Result<KtxTang>(new BadRequestException("Tên tầng là bắt buộc."));
                }

                var toaNha = await _toaNhaRepo.GetByIdAsync(entity.ToaNhaId);
                if (toaNha == null)
                {
                    return new Result<KtxTang>(new NotFoundException("Tòa nhà không tồn tại."));
                }
                if (toaNha.LoaiToaNha == 1 && entity.LoaiTang == "Nam")
                {
                    return new Result<KtxTang>(new BadRequestException("Không thể thêm tầng Nữ vào tòa nhà Nam."));
                }
                if (toaNha.LoaiToaNha == 0 && entity.LoaiTang == "Nu") 
                {
                    return new Result<KtxTang>(new BadRequestException("Không thể thêm tầng Nam vào tòa nhà Nữ."));
                }

                var existingTang = await _repository.GetFirstAsync(
                    predicate: t => t.ToaNhaId == entity.ToaNhaId
                                 && t.TenTang!.ToLower() == entity.TenTang.Trim().ToLower());

                if (existingTang != null)
                {
                    return new Result<KtxTang>(new BadRequestException("Tên tầng đã tồn tại trong tòa nhà này."));
                }
                var tang = new KtxTang()
                {
                    TenTang = entity.TenTang,
                    ToaNha = toaNha,
                    ToaNhaId = entity.ToaNhaId,
                    LoaiTang = entity.LoaiTang,
                    SoLuongPhong = entity.SoLuongPhong,
                };
                _repository.Add(entity);
                await UnitOfWork.CommitAsync();

                return new Result<KtxTang>(entity);
            }
            catch (Exception ex)
            {
                return new Result<KtxTang>(ex.InnerException ?? ex);
            }
        }
        protected override Task UpdateEntityProperties(KtxTang existingEntity, KtxTang newEntity)
        {
            existingEntity.ToaNhaId = newEntity.ToaNhaId;
            existingEntity.TenTang = newEntity.TenTang;
            existingEntity.LoaiTang = newEntity.LoaiTang;
            existingEntity.SoLuongPhong = newEntity.SoLuongPhong;
            return Task.CompletedTask;
        }
    }
}