using EMS.Application.Services.Base;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Entities.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class ViPhamNoiQuyKTXService : BaseService<ViPhamNoiQuyKTX>, IViPhamNoiQuyKTXService
    {
        private readonly IViPhamNoiQuyKTXRepository _viPhamRepository;
        private readonly IGiuongKtxRepository _giuongRepository;

        public ViPhamNoiQuyKTXService(
            IUnitOfWork unitOfWork,
            IViPhamNoiQuyKTXRepository viPhamRepository,
            IGiuongKtxRepository giuongRepository)
            : base(unitOfWork, viPhamRepository)
        {
            _viPhamRepository = viPhamRepository;
            _giuongRepository = giuongRepository;
        }

        public async Task<Result<Guid>> CreateViPhamAsync(CreateViPhamNoiQuyKtxDto dto)
        {
            try
            {
                var giuong = await _giuongRepository.GetFirstAsync(g => g.SinhVienId == dto.SinhVienId && !g.IsDeleted);
                if (giuong == null) return new Result<Guid>(new BadRequestException("Sinh viên hiện không cư trú tại KTX."));

                var entity = new ViPhamNoiQuyKTX
                {
                    Id = Guid.NewGuid(),
                    SinhVienId = dto.SinhVienId,
                    NoiDungViPham = dto.NoiDungViPham,
                    HinhThucXuLy = dto.HinhThucXuLy,
                    DiemTru = dto.DiemTru,
                    NgayViPham = dto.NgayViPham
                };

                Repository.Add(entity);
                await UnitOfWork.CommitAsync();
                return new Result<Guid>(entity.Id);
            }
            catch (Exception ex)
            {
                var innerError = ex.InnerException?.Message ?? ex.Message;
                Console.WriteLine($"DB ERROR: {innerError}");
                return new Result<Guid>(new Exception(innerError));
            }
        }

        public async Task<Result<ViPhamNoiQuyKtxPagingResponse>> GetPaginatedAsync(ViPhamFilterRequest request)
        {
            try
            {
                var (data, total) = await _viPhamRepository.GetPaginatedWithDetailsAsync(request);
                return new Result<ViPhamNoiQuyKtxPagingResponse>(new ViPhamNoiQuyKtxPagingResponse { Data = data, Total = total });
            }
            catch (Exception ex) { return new Result<ViPhamNoiQuyKtxPagingResponse>(ex); }
        }

        public async Task<Result<bool>> UpdateViPhamAsync(UpdateViPhamNoiQuyKtxDto dto)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(dto.Id);
                if (entity == null) return new Result<bool>(new NotFoundException("Không tìm thấy bản ghi vi phạm."));

                entity.NoiDungViPham = dto.NoiDungViPham;
                entity.HinhThucXuLy = dto.HinhThucXuLy;
                entity.DiemTru = dto.DiemTru;
                entity.NgayViPham = dto.NgayViPham;

                Repository.Update(entity);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex) { return new Result<bool>(ex); }
        }

        protected override Task UpdateEntityProperties(ViPhamNoiQuyKTX existing, ViPhamNoiQuyKTX newEntity)
        {
            existing.NoiDungViPham = newEntity.NoiDungViPham;
            existing.HinhThucXuLy = newEntity.HinhThucXuLy;
            existing.DiemTru = newEntity.DiemTru;
            existing.NgayViPham = newEntity.NgayViPham;
            return Task.CompletedTask;
        }
    }
}