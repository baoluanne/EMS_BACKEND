using EMS.Application.Services.Base;
using EMS.Application.Services.ChiTietKhungHocKy_TinChiServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.ChiTietKhungHocKy_TinChiServices
{
    public interface IChiTietKhungHocKy_TinChiService : IBaseService<ChiTietKhungHocKy_TinChi>
    {
        // Add custom methods here if needed
        Task<Result<List<ChiTietKhungHocKy_TinChi>>> GetAllHocKyAsync();
        Task<Result<PaginationResponse<ChiTietKhungHocKy_TinChi>>> GetChuongTrinhKhungMonHocPagination(
            PaginationRequest request,
            SinhVienMienMonHocFilterDto filter);
    }
}