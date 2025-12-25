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
    public interface IDonKtxRepository : IAuditRepository<DonKtx> 
    {
        Task<(List<DonKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? trangThai = null,
            string? loaiDon = null);
    }
}
