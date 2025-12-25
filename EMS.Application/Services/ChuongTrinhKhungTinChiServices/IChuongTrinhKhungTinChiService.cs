using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.ChuongTrinhKhungNienCheServices.Dtos;
using EMS.Domain.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.ChuongTrinhKhungTinChiServices
{
    public interface IChuongTrinhKhungTinChiService : IBaseService<ChuongTrinhKhungTinChi>
    {
        Task<Result<bool>> UpdateIsBlock(ChuongTrinhKhungIsBlockUpdate request);

        Result<PaginationResponse<ChuongTrinhKhungTinChiResponseDto>> GetPaginatedWithLopHoc(PaginationRequest request,
            Expression<Func<ChuongTrinhKhungTinChi, bool>>? filters,
            Func<IQueryable<ChuongTrinhKhungTinChi>, IQueryable<ChuongTrinhKhungTinChi>>? include);
    }
}