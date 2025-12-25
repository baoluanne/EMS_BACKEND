using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices
{
    public interface INhatKyCapNhatTrangThaiSvService : IBaseService<NhatKyCapNhatTrangThaiSv>
    {
        Task<Result<PaginationResponse<SinhVien>>> PaginateDistinctSinhVienAsync(PaginationRequest request,
           Expression<Func<NhatKyCapNhatTrangThaiSv, bool>>? filter = null,
           Expression<Func<SinhVien, object>>? orderBy = null,
           bool isDescending = false,
           Func<IQueryable<SinhVien>, IQueryable<SinhVien>>? include = null);

        Task<Result<bool>> CreateNhatKyCapNhatSinhVienAsync(CapNhatTrangThaiSinhVien request);
    }
}