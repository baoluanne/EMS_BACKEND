using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class PhongKtxService : BaseService<PhongKtx>, IPhongKtxService
    {
        private readonly IPhongKtxRepository _phongRepository;
        private readonly IToaNhaKtxRepository _toaNhaRepository;
        private readonly IGiuongKtxRepository _giuongRepository;

        public PhongKtxService(
            IUnitOfWork unitOfWork,
            IPhongKtxRepository phongRepository,
            IToaNhaKtxRepository toaNhaRepository,
            IGiuongKtxRepository giuongRepository)
            : base(unitOfWork, phongRepository)
        {
            _phongRepository = phongRepository;
            _toaNhaRepository = toaNhaRepository;
            _giuongRepository = giuongRepository;
        }

        public async Task<Result<PhongKtxPagingResponse>> GetPaginatedAsync(
            PaginationRequest request,
            string? maPhong = null,
            string? toaNhaId = null,
            string? trangThai = null)
        {
            try
            {
                var (data, total) = await _phongRepository.GetPaginatedWithDetailsAsync(request, maPhong, toaNhaId, trangThai);
                return new Result<PhongKtxPagingResponse>(new PhongKtxPagingResponse { data = data, total = total });
            }
            catch (Exception ex)
            {
                return new Result<PhongKtxPagingResponse>(ex);
            }
        }

        public override async Task<Result<PhongKtx>> UpdateAsync(Guid id, PhongKtx entity)
        {
            try
            {
                var existingPhong = await _phongRepository.GetByIdAsync(id);
                if (existingPhong == null)
                {
                    return new Result<PhongKtx>(new NotFoundException("Không tìm thấy phòng"));
                }

                if (entity.SoLuongGiuong < existingPhong.SoLuongDaO)
                {
                    return new Result<PhongKtx>(new BadRequestException(
                        $"Số lượng giường ({entity.SoLuongGiuong}) không thể nhỏ hơn số giường đã ở ({existingPhong.SoLuongDaO})"));
                }

                if (entity.SoLuongGiuong > existingPhong.SoLuongGiuong)
                {
                    int soGiuongCanThem = entity.SoLuongGiuong - existingPhong.SoLuongGiuong;
                    int soGiuongHienTai = existingPhong.SoLuongGiuong;

                    for (int i = 1; i <= soGiuongCanThem; i++)
                    {
                        var giuongMoi = new GiuongKtx
                        {
                            Id = Guid.NewGuid(),
                            MaGiuong = $"{existingPhong.MaPhong}-{(soGiuongHienTai + i):00}",
                            PhongKtxId = id,
                            TrangThai = TrangThaiGiuongConstants.TRONG
                        };
                        _giuongRepository.Add(giuongMoi);
                    }
                }

                if (entity.SoLuongGiuong < existingPhong.SoLuongGiuong)
                {
                    int soGiuongCanXoa = existingPhong.SoLuongGiuong - entity.SoLuongGiuong;

                    var giuongTrong = await _giuongRepository.GetListAsync(
                        g => g.PhongKtxId == id &&
                             g.TrangThai == TrangThaiGiuongConstants.TRONG &&
                             !g.IsDeleted);

                    if (giuongTrong.Count < soGiuongCanXoa)
                    {
                        return new Result<PhongKtx>(new BadRequestException(
                            $"Không thể giảm số giường. Chỉ có {giuongTrong.Count} giường trống, cần {soGiuongCanXoa} giường trống để xóa"));
                    }

                    var giuongCanXoa = giuongTrong.Take(soGiuongCanXoa).ToList();
                    foreach (var giuong in giuongCanXoa)
                    {
                        await _giuongRepository.ListSoftDeletedAsync();
                    }
                }

                var updateResult = await base.UpdateAsync(id, entity);

                if (updateResult.IsSuccess)
                {
                    await UnitOfWork.CommitAsync();
                }

                return updateResult;
            }
            catch (Exception ex)
            {
                return new Result<PhongKtx>(ex);
            }
        }

        public async Task<Result<CreatePhongKtxResponseDto>> TaoPhongMoiAsync(CreatePhongKtxRequestDto request)
        {
            try
            {
                var toaNha = await _toaNhaRepository.GetFirstAsync(t => t.Id == request.ToaNhaId && !t.IsDeleted);
                if (toaNha == null)
                    return new Result<CreatePhongKtxResponseDto>(new NotFoundException("Tòa nhà không tồn tại"));

                var danhSachMaPhong = new List<string>();
                var danhSachGiuong = new List<string>();

                if (!string.IsNullOrEmpty(request.MaPhongNhapTay))
                {
                    danhSachMaPhong.Add(request.MaPhongNhapTay.Trim());
                }
                else
                {
                    for (int tang = 1; tang <= request.SoTang; tang++)
                    {
                        for (int i = 1; i <= request.SoThuTuPhong; i++)
                        {
                            string maPhong = $"{request.Prefix}{tang:00}{i:00}";
                            danhSachMaPhong.Add(maPhong);
                        }
                    }
                }

                var response = new List<CreatePhongKtxResponseDto>();

                foreach (var maPhong in danhSachMaPhong)
                {
                    var phongTonTai = await Repository.GetFirstAsync(p => p.MaPhong == maPhong && !p.IsDeleted);
                    if (phongTonTai != null)
                        continue;

                    var phong = new PhongKtx
                    {
                        Id = Guid.NewGuid(),
                        MaPhong = maPhong,
                        ToaNhaId = request.ToaNhaId,
                        SoLuongGiuong = request.SoLuongGiuong,
                        SoLuongDaO = 0,
                        TrangThai = request.TrangThai ?? TrangThaiPhongConstants.HOAT_DONG,
                        GiaPhong = request.GiaPhong
                    };

                    Repository.Add(phong);

                    var dsMaGiuong = new List<string>();
                    for (int i = 1; i <= request.SoLuongGiuong; i++)
                    {
                        var giuong = new GiuongKtx
                        {
                            Id = Guid.NewGuid(),
                            MaGiuong = $"{maPhong}-{i:00}",
                            PhongKtxId = phong.Id,
                            TrangThai = TrangThaiGiuongConstants.TRONG
                        };
                        _giuongRepository.Add(giuong);
                        dsMaGiuong.Add(giuong.MaGiuong);
                    }

                    danhSachGiuong.AddRange(dsMaGiuong);

                    response.Add(new CreatePhongKtxResponseDto
                    {
                        PhongId = phong.Id,
                        MaPhong = maPhong,
                        DanhSachMaGiuong = dsMaGiuong
                    });
                }

                await UnitOfWork.CommitAsync();

                if (response.Count == 0)
                    return new Result<CreatePhongKtxResponseDto>(new BadRequestException("Không có phòng mới nào được tạo (có thể đã tồn tại)"));

                return new Result<CreatePhongKtxResponseDto>(response.First());
            }
            catch (Exception ex)
            {
                return new Result<CreatePhongKtxResponseDto>(ex);
            }
        }

        protected override Task UpdateEntityProperties(PhongKtx existingEntity, PhongKtx newEntity)
        {
            existingEntity.MaPhong = newEntity.MaPhong;
            existingEntity.ToaNhaId = newEntity.ToaNhaId;
            existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
            existingEntity.SoLuongDaO = newEntity.SoLuongDaO;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GiaPhong = newEntity.GiaPhong;
            return Task.CompletedTask;
        }
    }
}