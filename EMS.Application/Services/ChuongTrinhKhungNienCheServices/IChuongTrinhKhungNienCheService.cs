using EMS.Application.Services.Base;
using EMS.Application.Services.ChuongTrinhKhungNienCheServices.Dtos;
using EMS.Domain.Entities;
using LanguageExt.Common;

namespace EMS.Application.Services.ChuongTrinhKhungNienCheServices
{
    public interface IChuongTrinhKhungNienCheService : IBaseService<ChuongTrinhKhungNienChe>
    {
        Task<Result<bool>> UpdateIsBlock(ChuongTrinhKhungIsBlockUpdate request);
    }
} 