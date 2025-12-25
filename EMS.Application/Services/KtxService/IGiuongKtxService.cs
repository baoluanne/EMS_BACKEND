using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IGiuongKtxService : IBaseService<GiuongKtx>
    {
        Task<Result<GiuongKtxPagingResponse>> GetPaginatedAsync(PaginationRequest request);
    }
}
