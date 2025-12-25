using EMS.Application.Services.Base;
using EMS.Application.Services.MonHocBacDaoTaoServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models.Import;
using FluentValidation;
using LanguageExt.Common;

namespace EMS.Application.Services.MonHocBacDaoTaoServices
{
    public class MonHocBacDaoTaoService(IUnitOfWork unitOfWork,
        IMonHocBacDaoTaoRepository repository,
        IValidator<MonHocBacDaoTaoImportDto> validator) : BaseService<MonHocBacDaoTao>(unitOfWork, repository), IMonHocBacDaoTaoService
    {
        private IMonHocBacDaoTaoRepository _monHocBacDaoTaoRepository = repository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IValidator<MonHocBacDaoTaoImportDto> _validator = validator;

        protected override Task UpdateEntityProperties(MonHocBacDaoTao existingEntity, MonHocBacDaoTao newEntity)
        {
            existingEntity.DVHT_TC = newEntity.DVHT_TC;
            existingEntity.SoTinChi = newEntity.SoTinChi;
            existingEntity.SoTietLyThuyet = newEntity.SoTietLyThuyet;
            existingEntity.SoTietThucHanh = newEntity.SoTietThucHanh;
            existingEntity.TuHoc = newEntity.TuHoc;
            existingEntity.SoLanKTDinhKy = newEntity.SoLanKTDinhKy;
            existingEntity.ThucHanh = newEntity.ThucHanh;
            existingEntity.LyThuyet = newEntity.LyThuyet;
            existingEntity.MoRong = newEntity.MoRong;
            existingEntity.SoTietLTT = newEntity.SoTietLTT;
            existingEntity.SoTietTHBT = newEntity.SoTietTHBT;
            existingEntity.IsLyThuyet = newEntity.IsLyThuyet;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.SoTietTuHoc = newEntity.SoTietTuHoc;
            existingEntity.SoGioThucTap = newEntity.SoGioThucTap;
            existingEntity.SoGioDoAnBTLon = newEntity.SoGioDoAnBTLon;
            existingEntity.SoTietKT = newEntity.SoTietKT;
            existingEntity.DVHT_HP = newEntity.DVHT_HP;
            existingEntity.DVHT_Le = newEntity.DVHT_Le;
            existingEntity.IsKhongTinhDiemTBC = newEntity.IsKhongTinhDiemTBC;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdHinhThucThi = newEntity.IdHinhThucThi;
            existingEntity.IdLoaiHinhGiangDay = newEntity.IdLoaiHinhGiangDay;
            existingEntity.IdLoaiTiet = newEntity.IdLoaiTiet;
            existingEntity.IdMonHoc = newEntity.IdMonHoc;
            existingEntity.IdQuyUocCotDiem_NC = newEntity.IdQuyUocCotDiem_NC;
            existingEntity.IdQuyUocCotDiem_TC = newEntity.IdQuyUocCotDiem_TC;

            return Task.CompletedTask;
        }

        public async Task<Result<bool>> AddBatchAsync(AddMonHocBacDaoTaoRequestDto request)
        {
            try
            {
                foreach (var idMonHoc in request.IdMonHocs)
                {
                    var existingEntity = await _monHocBacDaoTaoRepository.GetFirstAsync(x => x.IdMonHoc == idMonHoc);
                    if (existingEntity != null)
                    {
                        existingEntity.IdBacDaoTao = request.IdBacDaoTao;
                        existingEntity.GhiChu = request.GhiChu;
                        _monHocBacDaoTaoRepository.Update(existingEntity);
                    }
                    else
                    {
                        _monHocBacDaoTaoRepository.Add(new MonHocBacDaoTao
                        {
                            IdMonHoc = idMonHoc,
                            IdBacDaoTao = request.IdBacDaoTao,
                            GhiChu = request.GhiChu,
                        });
                    }
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> UpdateManyAsync(List<MonHocBacDaoTao> monHocBacDaoTaos)
        {
            try
            {
                foreach (var monHocBacDaoTao in monHocBacDaoTaos)
                {
                    var existingEntity = await _monHocBacDaoTaoRepository.GetByIdAsync(monHocBacDaoTao.Id);
                    if (existingEntity == null)
                    {
                        return new Result<bool>(new NotFoundException($"MonHocBacDaoTao with ID {monHocBacDaoTao.Id} not found."));
                    }
                    await UpdateEntityProperties(existingEntity, monHocBacDaoTao);
                    _monHocBacDaoTaoRepository.Update(existingEntity);
                }

                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<ImportResultResponse<MonHocBacDaoTaoImportDto>> ImportAsync(byte[] fileBytes)
        {
            var monHocRepo = _unitOfWork.GetRepository<IMonHocRepository>();
            var bacDaoTaoRepo = _unitOfWork.GetRepository<IBacDaoTaoRepository>();

            var monHocs = await monHocRepo.ListAsync();
            var bacDaoTaos = await bacDaoTaoRepo.ListAsync();
            var monHocBacDaoTaos = await _monHocBacDaoTaoRepository.ListAsync();

            var result = await base.ImportAsync(
                fileBytes,
                dto =>
                {
                    // Tìm MonHoc theo mã và tên
                    var monHoc = monHocs.FirstOrDefault(m =>
                        m.MaMonHoc.Trim().ToLower() == dto.MaMonHoc!.Trim().ToLower() &&
                        m.TenMonHoc.Trim().ToLower() == dto.TenMonHoc!.Trim().ToLower());
                    dto.IdMonHoc = monHoc.Id;

                    // Tìm BacDaoTao theo mã
                    var bacDaoTao = bacDaoTaos.FirstOrDefault(b =>
                        b.MaBacDaoTao.Trim().ToLower() == dto.MaBacDaoTao!.Trim().ToLower() ||
                        b.TenBacDaoTao.Trim().ToLower() == dto.MaBacDaoTao!.Trim().ToLower());
                    dto.IdBacDaoTao = bacDaoTao.Id;

                    // Kiểm tra tồn tại trong MonHocBacDaoTao, không có thì tạo mới
                    var monHocBacDaoTao = monHocBacDaoTaos.FirstOrDefault(mhbdt =>
                        mhbdt.IdMonHoc == monHoc.Id) ?? new MonHocBacDaoTao();

                    // Cập nhật các trường trong MonHocBacDaoTao
                    monHocBacDaoTao.IdMonHoc = monHoc.Id;
                    monHocBacDaoTao.IdBacDaoTao = bacDaoTao.Id;
                    monHocBacDaoTao.GhiChu = dto.GhiChu;

                    return Task.FromResult(monHocBacDaoTao);
                },
                _validator,
                async entities =>
                {
                    foreach (var entity in entities)
                    {
                        if (entity.Id == Guid.Empty)
                        {
                            _monHocBacDaoTaoRepository.Add(entity);
                        }
                        else
                        {
                            _monHocBacDaoTaoRepository.Update(entity);
                        }
                    }
                    await _unitOfWork.CommitAsync();
                }
            );

            return result;
        }

    }
}