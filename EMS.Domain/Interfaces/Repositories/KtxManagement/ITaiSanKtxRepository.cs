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
    public interface ITaiSanKtxRepository : IAuditRepository<TaiSanKtx>
    {
        Task<(List<TaiSanKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        string? tinhTrang = null,
        string? searchTerm = null);
    }
}
