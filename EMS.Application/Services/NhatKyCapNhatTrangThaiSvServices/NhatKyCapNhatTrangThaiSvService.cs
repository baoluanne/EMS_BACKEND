using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices
{
    public class NhatKyCapNhatTrangThaiSvService(
        IUnitOfWork unitOfWork,
        INhatKyCapNhatTrangThaiSvRepository repository,
        IQuyetDinhRepository quyetDinhRepository,
        ISinhVienRepository sinhVienRepository
    ) : BaseService<NhatKyCapNhatTrangThaiSv>(unitOfWork, repository), INhatKyCapNhatTrangThaiSvService
    {
        private readonly INhatKyCapNhatTrangThaiSvRepository _nhatKyCapNhatTrangThaiSvRepository = repository;
        private readonly IQuyetDinhRepository _quyetDinhRepository = quyetDinhRepository;
        private readonly ISinhVienRepository _sinhVienRepository = sinhVienRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        protected override Task UpdateEntityProperties(NhatKyCapNhatTrangThaiSv existingEntity, NhatKyCapNhatTrangThaiSv newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.TrangThaiCu = newEntity.TrangThaiCu;
            existingEntity.TrangThaiMoi = newEntity.TrangThaiMoi;
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            existingEntity.NgayQuyetDinh = newEntity.NgayQuyetDinh;
            existingEntity.IdQuyetDinh = newEntity.IdQuyetDinh;
            existingEntity.NgayHetHan = newEntity.NgayHetHan;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }

        public async Task<Result<PaginationResponse<SinhVien>>> PaginateDistinctSinhVienAsync(PaginationRequest request,
            Expression<Func<NhatKyCapNhatTrangThaiSv, bool>>? filter = null,
            Expression<Func<SinhVien, object>>? orderBy = null,
            bool isDescending = false,
            Func<IQueryable<SinhVien>, IQueryable<SinhVien>>? include = null)
        {
            var result = await _nhatKyCapNhatTrangThaiSvRepository.PaginateDistinctSinhVienAsync(request, filter, orderBy, isDescending, include);
            return new Result<PaginationResponse<SinhVien>>(result);
        }

        public async Task<Result<bool>> CreateNhatKyCapNhatSinhVienAsync(CapNhatTrangThaiSinhVien request)
        {
            var newQuyetDinh = new QuyetDinh { 
                SoQuyetDinh = request.SoQuyetDinh, 
                TenQuyetDinh = "",
                IdLoaiQuyetDinh = request.IdLoaiQuyetDinh,
            };

            var quyetDinh = _quyetDinhRepository.Add(newQuyetDinh);

            var nhatKys = new List<NhatKyCapNhatTrangThaiSv>();

            foreach (var idSinhVienStr in request.IdSinhViens)
            {
                if (!Guid.TryParse(idSinhVienStr, out var idSinhVien))
                    continue;

                var sinhVien = await _sinhVienRepository.GetByIdAsync(idSinhVien);
                if (sinhVien == null)
                    continue;

                var nhatKy = new NhatKyCapNhatTrangThaiSv
                {
                    IdSinhVien = idSinhVien,
                    SinhVien = sinhVien,
                    TrangThaiCu = sinhVien.TrangThai,
                    TrangThaiMoi = request.TrangThaiMoi,
                    SoQuyetDinh = request.SoQuyetDinh,
                    NgayQuyetDinh = request.NgayRaQuyetDinh,
                    IdQuyetDinh = quyetDinh.Id,
                    QuyetDinh = quyetDinh,
                    NgayHetHan = request.NgayHetHan,
                    GhiChu = request.GhiChu
                };

                sinhVien.TrangThai = request.TrangThaiMoi;
                _sinhVienRepository.Update(sinhVien);

                nhatKys.Add(nhatKy);
            }

            _nhatKyCapNhatTrangThaiSvRepository.AddRange(nhatKys);

            await _unitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
    }
}