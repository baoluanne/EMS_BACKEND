using EMS.Application.Services.Base;
using EMS.Application.Services.GiangVienServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models.Import;
using FluentValidation;

namespace EMS.Application.Services.GiangVienServices
{
    public class GiangVienService : BaseService<GiangVien>, IGiangVienService
    {
        private readonly IValidator<GiangVienImportDto> _validator;

        public GiangVienService(IUnitOfWork unitOfWork,
            IGiangVienRepository giangVienRepository,
            IValidator<GiangVienImportDto> validator) : base(unitOfWork, giangVienRepository)
        {
            _validator = validator;
        }

        protected override Task UpdateEntityProperties(GiangVien existingEntity, GiangVien newEntity)
        {
            existingEntity.MaGiangVien = newEntity.MaGiangVien;
            existingEntity.HoDem = newEntity.HoDem;
            existingEntity.Ten = newEntity.Ten;
            existingEntity.NgaySinh = newEntity.NgaySinh;
            existingEntity.SoDienThoai = newEntity.SoDienThoai;
            existingEntity.DiaChi = newEntity.DiaChi;
            existingEntity.Email = newEntity.Email;
            existingEntity.IdLoaiGiangVien = newEntity.IdLoaiGiangVien;
            existingEntity.IdKhoa = newEntity.IdKhoa;
            existingEntity.IdHocVi = newEntity.IdHocVi;
            existingEntity.IDToBoMon = newEntity.IDToBoMon;
            existingEntity.TenVietTat = newEntity.TenVietTat;
            existingEntity.HSGV_LT = newEntity.HSGV_LT;
            existingEntity.HSGV_TH = newEntity.HSGV_TH;
            existingEntity.PhuongTien = newEntity.PhuongTien;
            existingEntity.NgayChamDutHopDong = newEntity.NgayChamDutHopDong;
            existingEntity.IsCoiThi = newEntity.IsCoiThi;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.IsKhongChamCong = newEntity.IsKhongChamCong;
            existingEntity.IsChamDutHopDong = newEntity.IsChamDutHopDong;
            return Task.CompletedTask;
        }

        public async Task<ImportResultResponse<GiangVienImportDto>> ImportAsync(byte[] fileBytes)
        {
            var loaiGiangVienRepo = UnitOfWork.GetRepository<ILoaiGiangVienRepository>();
            var khoaRepo = UnitOfWork.GetRepository<IKhoaRepository>();
            var hocViRepo = UnitOfWork.GetRepository<IHocViRepository>();
            var toBoMonRepo = UnitOfWork.GetRepository<IToBoMonRepository>();

            var loaiGiangViens = await loaiGiangVienRepo.ListAsync();
            var khoas = await khoaRepo.ListAsync();
            var hocVis = await hocViRepo.ListAsync();
            var toBoMons = await toBoMonRepo.ListAsync();

            var result = await base.ImportAsync(
                fileBytes,
                dto =>
                {
                    var loaiGiangVien = loaiGiangViens.FirstOrDefault(x =>
                        x.MaLoaiGiangVien.Trim().Equals(dto.TenLoaiGiangVien?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenLoaiGiangVien.Trim().Equals(dto.TenLoaiGiangVien?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var khoa = khoas.FirstOrDefault(x =>
                        x.MaKhoa.Trim().Equals(dto.TenKhoa?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenKhoa.Trim().Equals(dto.TenKhoa?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var hocVi = hocVis.FirstOrDefault(x =>
                        x.MaHocVi.Trim().Equals(dto.TenHocVi?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenHocVi.Trim().Equals(dto.TenHocVi?.Trim(), StringComparison.OrdinalIgnoreCase));

                    var toBoMon = toBoMons.FirstOrDefault(x =>
                        x.MaToBoMon.Trim().Equals(dto.TenToBoMon?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                        x.TenToBoMon.Trim().Equals(dto.TenToBoMon?.Trim(), StringComparison.OrdinalIgnoreCase));

                    return Task.FromResult(new GiangVien
                    {
                        MaGiangVien = dto.MaGiangVien,
                        HoDem = dto.HoDem,
                        Ten = dto.Ten,
                        NgaySinh = dto.NgaySinh.HasValue ? dto.NgaySinh.Value.ToUniversalTime() : null,
                        SoDienThoai = dto.SoDienThoai,
                        DiaChi = dto.DiaChi,
                        Email = dto.Email,
                        TenVietTat = dto.TenVietTat,
                        HSGV_LT = dto.HSGV_LT,
                        HSGV_TH = dto.HSGV_TH,
                        PhuongTien = dto.PhuongTien,
                        NgayChamDutHopDong = dto.NgayChamDutHopDong,
                        IsCoiThi = dto.IsCoiThi,
                        IsVisible = dto.IsVisible,
                        IsKhongChamCong = dto.IsKhongChamCong,
                        IsChamDutHopDong = dto.IsChamDutHopDong,

                        IdLoaiGiangVien = loaiGiangVien.Id,
                        IdKhoa = khoa.Id,
                        IdHocVi = hocVi?.Id,
                        IDToBoMon = toBoMon?.Id
                    });
                },
                _validator
            );

            return result;
        }

    }
}