using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.TiepNhanHoSoSvServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.TiepNhanHoSoSvServices
{
    public class TiepNhanHoSoSvService : BaseService<TiepNhanHoSoSv>, ITiepNhanHoSoSvService
    {
        public TiepNhanHoSoSvService(
            IUnitOfWork unitOfWork,
            ITiepNhanHoSoSvRepository tiepNhanHoSoSvRepository) : base(unitOfWork, tiepNhanHoSoSvRepository)
        {
        }

        protected override async Task UpdateEntityProperties(TiepNhanHoSoSv entity, TiepNhanHoSoSv entityFromDb)
        {
            entityFromDb.IdSinhVien = entity.IdSinhVien;
            entityFromDb.IdHoSoSV = entity.IdHoSoSV;
            entityFromDb.IdNguoiTiepNhan = entity.IdNguoiTiepNhan;
            entityFromDb.NgayTiepNhan = entity.NgayTiepNhan;

            entityFromDb.IdNguoiXuLy = entity.IdNguoiXuLy;
            entityFromDb.NgayXuLy = entity.NgayXuLy;

            entityFromDb.TrangThai = entity.TrangThai;
            entityFromDb.LyDoTuChoi = entity.LyDoTuChoi;
            entityFromDb.InBienNhan = entity.InBienNhan;
            entityFromDb.XemIn = entity.XemIn;
            entityFromDb.SoBanIn = entity.SoBanIn;
            entityFromDb.CongNoHocPhi = entity.CongNoHocPhi;
            entityFromDb.KhoanThuKhac = entity.KhoanThuKhac;
            entityFromDb.MaVach = entity.MaVach;

            await Task.CompletedTask;
        }

        public async Task<Result<PaginationResponse<TiepNhanHoSoSv>>> GetListPaginatedAsync(
            PaginationRequest request,
            TiepNhanHoSoSvFilterRequestDto filter)
        {
            Expression<Func<TiepNhanHoSoSv, bool>> filterExpression = ex => ex.IdSinhVien == filter.IdSinhVien;
            if (!string.IsNullOrWhiteSpace(filter.MaSinhVien))
            {
                filterExpression = ex => ex.SinhVien != null && ex.SinhVien.MaSinhVien == filter.MaSinhVien;
            }
            IQueryable<TiepNhanHoSoSv> includeFunc(IQueryable<TiepNhanHoSoSv> q)
            {
                return q.AsNoTracking().Include(x => x.SinhVien)
                .Include(x => x.HoSoSV)
                .Include(x => x.NguoiTiepNhan);
            }
            var result = await GetPaginatedAsync(request, include: includeFunc, filter: filterExpression);
            return result;
        }

        public async Task<Result<string>> UpdateHoSoAsync(
            List<HoSoSVModel> danhSachTiepNhanHoSo
            )
        {
            try
            {
                var danhSachHoSoIds = danhSachTiepNhanHoSo.Select(x => x.IdHoSoSV).ToList();
                var hosoDaTiepNhans = await Repository.GetListAsync(x => danhSachHoSoIds.Contains(x.Id));
                foreach (var hoso in hosoDaTiepNhans)
                {
                    var updateDto = danhSachTiepNhanHoSo.FirstOrDefault(x => x.IdHoSoSV == hoso.Id);
                    hoso.NgayXuLy = DateTime.UtcNow;
                    hoso.TrangThai = updateDto.IsTiepNhan == true ? TrangThaiHoSoEnum.DaNhan : TrangThaiHoSoEnum.TuChoi;
                    if (updateDto.IsTiepNhan == false)
                    {
                        hoso.LyDoTuChoi = updateDto.LyDoTuChoi;
                    }
                    hoso.GhiChu = updateDto.GhiChu;
                    Repository.Update(hoso);
                }
                await UnitOfWork.CommitAsync();
                return new Result<string>("true");
            }
            catch (Exception ex)
            {
                return new Result<string>(ex.Message);
            }
        }
    }
}