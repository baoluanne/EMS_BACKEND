using EMS.Application.Services.Base;
using EMS.Application.Services.MonHocServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models.Import;
using FluentValidation;

namespace EMS.Application.Services.MonHocServices
{
    public class MonHocService : BaseService<MonHoc>, IMonHocService
    {
        private readonly IValidator<MonHocImportDto> _validator;

        public MonHocService(IUnitOfWork unitOfWork,
            IMonHocRepository monHocRepository,
            IValidator<MonHocImportDto> validator) : base(unitOfWork, monHocRepository)
        {
            _validator = validator;
        }

        protected override Task UpdateEntityProperties(MonHoc existingEntity, MonHoc newEntity)
        {
            existingEntity.MaMonHoc = newEntity.MaMonHoc;
            existingEntity.TenMonHoc = newEntity.TenMonHoc;
            existingEntity.MaTuQuan = newEntity.MaTuQuan;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.TenVietTat = newEntity.TenVietTat;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsKhongTinhTBC = newEntity.IsKhongTinhTBC;
            existingEntity.IdLoaiMonHoc = newEntity.IdLoaiMonHoc;
            existingEntity.IdKhoa = newEntity.IdKhoa;
            existingEntity.IdToBoMon = newEntity.IdToBoMon;
            existingEntity.IdLoaiTiet = newEntity.IdLoaiTiet;
            existingEntity.IdKhoiKienThuc = newEntity.IdKhoiKienThuc;
            existingEntity.IdTinhChatMonHoc = newEntity.IdTinhChatMonHoc;
            existingEntity.SoTinChi = newEntity.SoTinChi;

            return Task.CompletedTask;
        }

        public async Task<ImportResultResponse<MonHocImportDto>> ImportAsync(byte[] fileBytes)
        {
            var loaiMonHocRepo = UnitOfWork.GetRepository<ILoaiMonHocRepository>();
            var khoaRepo = UnitOfWork.GetRepository<IKhoaRepository>();

            var loaiMonHocs = await loaiMonHocRepo.ListAsync();
            var khoas = await khoaRepo.ListAsync();

            var result = await base.ImportAsync(
                fileBytes,
                dto =>
                {
                    var loai = loaiMonHocs.FirstOrDefault(x =>
                        x.MaLoaiMonHoc.Trim().Equals(dto.TenLoaiMonHoc?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenLoaiMonHoc.Trim().Equals(dto.TenLoaiMonHoc?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var khoa = khoas.FirstOrDefault(x =>
                        x.MaKhoa.Trim().Equals(dto.TenKhoa?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenKhoa.Trim().Equals(dto.TenKhoa?.Trim(), StringComparison.OrdinalIgnoreCase));

                    return Task.FromResult(new MonHoc
                    {
                        MaMonHoc = dto.MaMonHoc,
                        TenMonHoc = dto.TenMonHoc,
                        MaTuQuan = dto.MaTuQuan,
                        TenTiengAnh = dto.TenTiengAnh,
                        TenVietTat = dto.TenVietTat,
                        GhiChu = dto.GhiChu,
                        IsKhongTinhTBC = dto.IsKhongTinhTBC,
                        IdLoaiMonHoc = loai.Id,
                        IdKhoa = khoa.Id,
                    });
                },
                _validator
            );
            return result;
        }

    }
}