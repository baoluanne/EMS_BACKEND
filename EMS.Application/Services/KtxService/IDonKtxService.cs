using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IDonKtxService : IBaseService<DonKtx>
    {

        Task<Result<Guid>> AddDonAsync(DonKtxCreateDto dto);
        Task<Result<DonKtxPagingResponse>> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? trangThai = null,
            string? loaiDon = null);

        Task<Result<bool>> DuyetDonVaoOAsync(Guid donId, Guid phongId, Guid giuongId, string? ghiChuDuyet = null);
        Task<Result<bool>> DuyetDonChuyenPhongAsync(Guid donId, Guid phongMoiId, Guid giuongMoiId, DateTime ngayBatDau, DateTime ngayHetHan, string? ghiChuDuyet = null);
        Task<Result<bool>> DuyetDonGiaHanAsync(Guid donId, DateTime ngayHetHanMoi, string? ghiChuDuyet = null);
        Task<Result<bool>> DuyetDonRoiKtxAsync(Guid donId, string? ghiChuDuyet = null);
        Task<Result<bool>> TuChoiDonAsync(Guid donId, string lyDoTuChoi);
    }
}
