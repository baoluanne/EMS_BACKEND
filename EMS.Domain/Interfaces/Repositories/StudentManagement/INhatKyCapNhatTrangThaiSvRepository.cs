using System.Linq.Expressions;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.StudentManagement
{
    public interface INhatKyCapNhatTrangThaiSvRepository : IAuditRepository<NhatKyCapNhatTrangThaiSv>
    {
        Task<PaginationResponse<SinhVien>> PaginateDistinctSinhVienAsync(
            PaginationRequest request,
            Expression<Func<NhatKyCapNhatTrangThaiSv, bool>>? filter = null,
            Expression<Func<SinhVien, object>>? orderBy = null,
            bool isDescending = false,
            Func<IQueryable<SinhVien>, IQueryable<SinhVien>>? include = null);
    }
}