using EMS.Application.Services.Base;
using EMS.Application.Services.PhongHocServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models.Import;
using FluentValidation;

namespace EMS.Application.Services.PhongHocServices
{
    public class PhongHocService : BaseService<PhongHoc>, IPhongHocService
    {
        private readonly IValidator<PhongHocImportDto> _validator;

        public PhongHocService(IUnitOfWork unitOfWork,
            IPhongHocRepository phongHocRepository,
            IValidator<PhongHocImportDto> validator)
            : base(unitOfWork, phongHocRepository)
        {
            _validator = validator;
        }

        protected override Task UpdateEntityProperties(PhongHoc existingEntity, PhongHoc newEntity)
        {
            existingEntity.MaPhong = newEntity.MaPhong;
            existingEntity.TenPhong = newEntity.TenPhong;
            existingEntity.SoBan = newEntity.SoBan;
            existingEntity.SoChoNgoi = newEntity.SoChoNgoi;
            existingEntity.SoChoThi = newEntity.SoChoThi;
            existingEntity.IsNgungDungMayChieu = newEntity.IsNgungDungMayChieu;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdDayNha = newEntity.IdDayNha;
            existingEntity.IdTCMonHoc = newEntity.IdTCMonHoc;
            existingEntity.IdLoaiPhong = newEntity.IdLoaiPhong;
            return Task.CompletedTask;
        }
        public async Task<ImportResultResponse<PhongHocImportDto>> ImportAsync(byte[] fileBytes)
        {
            var dayNhaRepo = UnitOfWork.GetRepository<IDayNhaRepository>();
            var loaiPhongRepo = UnitOfWork.GetRepository<ILoaiPhongRepository>();
            var tcMonHocRepo = UnitOfWork.GetRepository<ITinhChatMonHocRepository>();

            var dayNhas = await dayNhaRepo.ListAsync();
            var loaiPhongs = await loaiPhongRepo.ListAsync();
            var tcMonHocs = await tcMonHocRepo.ListAsync();

            var result = await base.ImportAsync(
                fileBytes,
                dto =>
                {
                    var dayNha = dayNhas.FirstOrDefault(x =>
                        x.MaDayNha.Trim().Equals(dto.TenDayNha?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenDayNha.Trim().Equals(dto.TenDayNha?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var loaiPhong = loaiPhongs.FirstOrDefault(x =>
                        x.MaLoaiPhong.Trim().Equals(dto.TenLoaiPhong?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenLoaiPhong.Trim().Equals(dto.TenLoaiPhong?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var tcMonHoc = tcMonHocs.FirstOrDefault(x =>
                        x.MaTinhChatMonHoc.Trim().Equals(dto.TenTCMonHoc?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenTinhChatMonHoc.Trim().Equals(dto.TenTCMonHoc?.Trim(), StringComparison.OrdinalIgnoreCase));

                    return Task.FromResult(new PhongHoc
                    {
                        MaPhong = dto.MaPhong,
                        TenPhong = dto.TenPhong,
                        SoBan = dto.SoBan,
                        SoChoNgoi = dto.SoChoNgoi,
                        SoChoThi = dto.SoChoThi,
                        IsNgungDungMayChieu = dto.IsNgungDungMayChieu,
                        GhiChu = dto.GhiChu,

                        IdDayNha = dayNha?.Id ?? Guid.Empty,
                        IdLoaiPhong = loaiPhong?.Id ?? Guid.Empty,
                        IdTCMonHoc = tcMonHoc?.Id ?? Guid.Empty,
                    });
                },
                _validator
            );

            return result;
        }

    }
}