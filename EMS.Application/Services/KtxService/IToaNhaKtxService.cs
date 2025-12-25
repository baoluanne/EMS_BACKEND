using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IToaNhaKtxService : IBaseService<ToaNhaKtx>
    {
        Task<Result<ToaNhaKtxPagingResponse>> GetPaginatedAsync(PaginationRequest request);
    }
}
