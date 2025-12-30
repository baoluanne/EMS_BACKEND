using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface IPhongKtxRepository  : IAuditRepository<PhongKtx>
    {
        Task<(List<PhongKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? maPhong = null,
            string? toaNhaId = null,
            string? trangThai = null);
    }
}
