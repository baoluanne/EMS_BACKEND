using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface IHoaDonKtxRepository : IAuditRepository<HoaDonKtx>
    {
        Task<(List<HoaDonKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
         PaginationRequest request,
         Guid? phongKtxId = null,
         int? thang = null,
         int? nam = null,
         string? trangThai = null);
    }
}
